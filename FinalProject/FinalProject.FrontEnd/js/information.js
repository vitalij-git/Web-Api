const showInformationBtn = document.querySelector("#show-information-button");

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
            console.log(responseData);
            document.cookie = `personalInformationId=${encodeURIComponent(responseData.personalInformationId)};`;
           
        }
        
}

showInformationBtn.addEventListener("click",()=>{
    getPersonalInforamtion();
});