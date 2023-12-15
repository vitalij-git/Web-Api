
function cookieExists(cookieName) {
    return document.cookie.split(';').some(cookie => {
        const [name] = cookie.trim().split('=');
        return name === cookieName;
    });
}

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

const usernameExists = cookieExists('username');

if (usernameExists) {
    const cookieValue = getCookieValue("username");
     const userStatus = document.querySelector("#user-status-block");
    userStatus.innerHTML = `<div style="align-self: flex-end;">
    <p>Welcome, ${cookieValue}!</p>
    <div class="logout-block">
    <button type="button" id="logout-btn"class="btn btn-outline-danger">
    Logout
    </button></div>`;
} else {
    window.location.href ="index.html";
}

function removeCookie(sKey, sPath, sDomain) {
    document.cookie = encodeURIComponent(sKey) + 
    "=; expires=Thu, 01 Jan 1970 00:00:00 GMT" + 
    (sDomain ? "; domain=" + sDomain : "") + 
    (sPath ? "; path=" + sPath : "");
}

const logoutBtn = document.querySelector("#logout-btn");

logoutBtn.addEventListener("click", function(){
        removeCookie("username");
        removeCookie("role");
        removeCookie("personalInformationId");
        removeCookie("userId");
        window.location.href= 'index.html';
    });



