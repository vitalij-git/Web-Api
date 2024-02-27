
async function getGW2Wallet(){

    const response = await fetch("https://localhost:7144/Account/Wallet" ,{
        method: "GET"
    })
    
    if(response.ok){
        const responseWalletData = await response.json();
        getGW2Currency(responseWalletData);
    }
    else{
        console.log("neveikia");
    }
}
async function getGW2Currency(responseWalletData){
    const request = await fetch("https://api.guildwars2.com/v2/currencies?ids=all",{
        headers:{
            'Accept': 'application/json'
        },
        
    })
    let currencieQuantity;
    const responseCurrenciesData = await request.json();
    let currenciesId = 1;
    let currenciesTable = document.querySelector("#currency-table").getElementsByTagName('tbody')[0];
    for(let i=0; i<responseCurrenciesData.length;i++){
        let obj = responseCurrenciesData[i];
        currencieQuantity = responseWalletData.find(id => id.id === obj.id)
        if(currencieQuantity === undefined){
           console.log(currencieQuantity);
        }
        else if(currencieQuantity.id === 1){
            let gold = Math.floor(currencieQuantity.value / 10000);
            let silver = Math.floor((currencieQuantity.value % 10000)/100);
            let copper = currencieQuantity.value % 100
            let row = currenciesTable.insertRow(-1);
            let cell1 = row.insertCell(0);
            let cell2 = row.insertCell(1);
            let cell3 = row.insertCell(2);
            row.classList.add('underline-row');
            cell1.innerHTML = `<img src=${obj.icon} alt=${obj.name} class='currency-icon' height="35px">`;
            cell2.innerHTML = `<div><b>${obj.name}</b></div><div class='currency-description'>${obj.description}</div>`;
            cell3.innerHTML = `<div class="quantity-block">
            <span>${gold}</span><i><img src=${obj.icon} alt=${obj.name} height="17px" class="quantity-icon" ></img></i>
            <span>${silver}</span><img src="https://wiki.guildwars2.com/images/3/3c/Silver_coin.png" alt="silver" height="17px" class="quantity-icon" ></img></i>
            <span>${copper}</span><img src="https://wiki.guildwars2.com/images/e/eb/Copper_coin.png" alt="copper" height="17px" class="quantity-icon" ></img></i>
            </div>`;
        }
        else{
            
            let row = currenciesTable.insertRow(-1);
            let cell1 = row.insertCell(0);
            let cell2 = row.insertCell(1);
            let cell3 = row.insertCell(2);
            row.classList.add('underline-row');
            cell1.innerHTML = `<img src=${obj.icon} alt=${obj.name} class='currency-icon' height="35px">`;
            cell2.innerHTML = `<div><b>${obj.name}</b></div><div class='currency-description'>${obj.description}</div>`;
            cell3.innerHTML = `<div class="quantity-block"><span>${currencieQuantity.value}</span><i><img src=${obj.icon} alt=${obj.name} height="17px" class="quantity-icon" ></img></i></div>`;
            
        }
            currenciesId++;
    }
        
}
getGW2Wallet();
