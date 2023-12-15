const personalIformationSubmitBtn = document.querySelector("#personal-information-submit-btn");
const personalInformationForm = document.querySelector("#personal-information-form");

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

async function personalInformationSendData(){
    let data = new FormData(personalInformationForm);
    const firstName = data.get('firstName');
    const lastName = data.get('lastName');
    const email = data.get("email");
    const telNumber = data.get("telNumber");
    const personalCode = data.get("personalCode");
    const userId = getCookieValue("userId");
    let obj ={
        "firstName": firstName,
        "lastName":lastName,
        "email":email,
        "telNumber":telNumber,
        "personalCode":personalCode,
        "userId":userId
    };
 
        const response = await fetch("https://localhost:7075/PersonalInformation",{
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

personalIformationSubmitBtn.addEventListener("click", (e)=>{
    e.preventDefault();
    personalInformationSendData();
});


async function getPersonalInforamtion(){

    const userId = getCookieValue("userId");
    const headers = new Headers();
    headers.append("userId", userId)
    const response = await fetch("https://localhost:7075/PersonalInformation",{
        method: "GET",
        headers: { "userId": userId }
        })

        if(response.ok){
            const responseData = await response.json(); 
            document.cookie = `personalInformationId=${encodeURIComponent(responseData.personalInformationId)};`;
        }
        
}

//getPersonalInforamtion();