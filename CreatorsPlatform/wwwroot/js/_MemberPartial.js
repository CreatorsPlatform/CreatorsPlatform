

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

$("#member").mouseenter(function () {
    $("#entrance").slideDown();
});
$("#container").mouseleave(function () {
    $("#entrance").slideUp();
});


$("#loginBtn").mouseenter(function () {
    $("#LoginForm").slideDown();
    $("#RegisterForm").slideUp();
});
$("#container").mouseleave(function () {
    $("#LoginForm").slideUp();
});


$("#RegisterBtn").mouseenter(function () {
    $("#RegisterForm").slideDown();
    $("#LoginForm").slideUp();
});
$("#container").mouseleave(function () {
    $("#RegisterForm").slideUp();
});
