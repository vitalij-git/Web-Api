let charactersTable = document.querySelector("#characters-table").getElementsByTagName('tbody')[0];;
async function getGW2Characters(){
    const response = await fetch("https://localhost:7144/Account/Characters" ,{
        method: "GET"
    })

    if(response.ok){
        const responseCharactersData = await response.json();
        showCharactersName(responseCharactersData);
        
    }
}

function showCharactersName(responseCharactersData){
    for(let i=0; i<responseCharactersData.length; i++){
        let row = charactersTable.insertRow(-1);
        let cell1 = row.insertCell(0);
        cell1.innerHTML = responseCharactersData[i]
        
    }
    
}
getGW2Characters();