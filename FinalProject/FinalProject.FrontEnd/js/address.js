const addressForm = document.querySelector("#adress-form");
const addressSubmitBtn = document.querySelector("#address-submit-btn");

function getCookieValue(cookieName) {
    const cookies = document.cookie.split(';');
    for (const cookie of cookies) {
        const [name, value] = cookie.trim().split('=');
        if (name === cookieName) {
            return decodeURIComponent(value);
        }
    }
    return null;
}

async function addressSendData(){
    let data = new FormData(addressForm);
    const city = data.get('city');
    const street = data.get('street');
    const apartmentNumber = data.get("apartmentNumber");
    const buildingNumber = data.get("buildingNumber");
    const personalInformationId = getCookieValue("personalInformationId");
    let obj ={
        "city": city,
        "street":street,
        "apartmentNumber":apartmentNumber,
        "buildingNumber":buildingNumber,
        "personalInformationId":personalInformationId
    };
 
        const response = await fetch("https://localhost:7075/Address",{
        method: "POST",
        headers: {
            Accept: "application/json, text/plain, */*",
            "Content-Type": "application/json",
            },
            body: JSON.stringify(obj),
        })

        if(response.ok){
            const responseMessage = await response.json(); 
            const message = responseMessage.message;
            const statusCode = responseMessage.statusCode;
            var myModal = new bootstrap.Modal(document.getElementById('myModal'));
            document.getElementById("modal-message").innerHTML = message;
            document.getElementById("modal-header").innerHTML = statusCode;
            myModal.show();
        }
        else{
        const jsonResponse = await response.json(); 
        const message = jsonResponse.message;
        const statusCode = jsonResponse.statusCode;
            var myModal = new bootstrap.Modal(document.getElementById('myModal'));
            document.getElementById("modal-message").innerHTML = message;
            document.getElementById("modal-header").innerHTML = statusCode;
            myModal.show();
        
        }
   
}

addressSubmitBtn.addEventListener("click", (e)=>{
    e.preventDefault();
    addressSendData();
});