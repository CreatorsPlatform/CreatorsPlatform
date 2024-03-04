

class loginform {
    constructor() {
        this.ele = document.createElement("p");
        this.ele.innerHTML = "test<br>test2";
    }
}

// document.getElementById("switchBtn").appendChild(loginForm);

//const test = new loginform().ele;
//window.onload = () => {
//    console.log(document.querySelector('#switchBtns'));
//    document.querySelector('#switchBtns').addEventListener('mouseover', () => {
//        document.getElementById("entrance").appendChild(test.ele);
//    });
//}

$("#member").mousedown(function () {
    $("#entrance").fadeIn();
});
$("#container").mouseleave(function () {
    $("#entrance").fadeOut();
});


$("#loginBtn").mousedown(async function () {
    await $("#RegisterForm").fadeOut();
    await $("#RegisterForm").hide();
    $("#LoginForm").fadeIn();
    
});
$("#container").mouseleave(function () {
    $("#LoginForm").fadeOut();
});


$("#RegisterBtn").mousedown(async function () {
    await $("#LoginForm").fadeOut();
    await $("#LoginForm").hide();
    $("#RegisterForm").fadeIn();
    
});
$("#container").mouseleave(function () {
    $("#RegisterForm").fadeOut();
});
