const registrationForm = document.querySelector("#registrationForm");
const registrationSubmitBtn = document.querySelector("#submit-registration");


async function registrationSendData(){
    let data = new FormData(registrationForm);
    const password =data.get('password');
    const confirmPassword = data.get('confirmPassword');
    const username = data.get("username");
    if( password !== confirmPassword){
         document.getElementById('errorMessage').style.display = 'block'; 
         errorMessage.style.display = 'block';
    }
    else{
        let obj ={"username":username, "password":password};

        const response = await fetch("https://localhost:7075/User",{
        method: "POST",
        headers: {
            Accept: "application/json, text/plain, */*",
            "Content-Type": "application/json",
            },
            body: JSON.stringify(obj),
        })

        if(response.ok){
            const responseMessage = await response.json(); 
            var myModal = new bootstrap.Modal(document.getElementById('myModal'));
            document.getElementById("modal-message").innerHTML = responseMessage.message;
            document.getElementById("modal-header").innerHTML = responseMessage.statusCode;
            myModal.show();
            myModal._element.addEventListener('hidden.bs.modal', function () {
                window.location.href = 'index.html';
            });
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
   
}


registrationSubmitBtn.addEventListener("click", (e)=>{
    e.preventDefault();
    registrationSendData();
});

