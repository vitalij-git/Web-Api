
const loginForm = document.querySelector("#login-Form");
const loginSubmitBtn = document.querySelector("#submit-Login");


async function sendData(){
    let data = new FormData(loginForm);
    let obj ={};
    data.forEach((value, key) => {
        obj[key] = value;
      });

    try{
        const response = await fetch("https://localhost:7075/Login", {
            method: "POST",
            headers: {
            Accept: "application/json, text/plain, */*",
            "Content-Type": "application/json",
            },
            body: JSON.stringify(obj),
        })
        if(response.ok){
            const jsonResponse = await response.json(); 

            const username = jsonResponse.username;
            const role = jsonResponse.role;
            const userId = jsonResponse.userId;

            document.cookie = `username=${encodeURIComponent(username)};`;
            document.cookie = `role=${encodeURIComponent(role)};`;
            document.cookie = `userId=${encodeURIComponent(userId)};`;
            
            window.location.href ='home.html';
        }
        else{
            let errorMessage = document.getElementById('errorMessage');
        errorMessage.style.display = 'block';
        errorMessage.innerHTML= `<strong>Error:</strong> The username or password is incorrect. `
        }
        
        
    }catch(error){
        let errorMessage = document.getElementById('errorMessage');
        errorMessage.style.display = 'block';
        errorMessage.innerHTML= `<strong>Error:</strong> ${error.message}`
        }       
}

loginSubmitBtn.addEventListener("click", (e) => {
    e.preventDefault();
    sendData();
  });

