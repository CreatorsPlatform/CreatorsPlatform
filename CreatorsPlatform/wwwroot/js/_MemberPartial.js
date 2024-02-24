

class loginform {
    constructor() {
        this.ele = document.createElement("p");
        this.ele.innerHTML = "test<br>test2";
    }
}

// document.getElementById("switchBtn").appendChild(loginForm);

const test = new loginform();
window.onload = () => {
    console.log(document.querySelector('#switchBtns'));
    document.querySelector('#switchBtns').addEventListener('click', () => {
        document.getElementById("entrance").appendChild(test.ele);
    });
}

