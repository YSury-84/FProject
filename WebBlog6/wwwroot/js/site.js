// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function UserPass(u, p) {
    valid = true;
    if (u == "" || p == "") { 
        alert("Логин и Пароль должны быть обязательно заполнены.");
        valid = false;
    }
    return valid;
}
function Pass(a,b) { 
    valid = true;
    if (a != b) {
        alert("Пароль и Подтверждене пароля не совпадают.");
        valid = false;
    }
    if (valid == true && a.length < 4) {
        alert("Пароль должен быть не менее 4-х символов.");
        valid = false;
    }
    return valid;
}
function RegValid(u, p1, p2) {
    valid = true;
    valid = UserPass(u, p1);
    if (valid == ture) {
        valid = Pass(p1, p2);
    }
    return valid;
}
function TegName(a) {
    valid = true;
    if (a == "" || a.length < 5) {
        alert("Длина Тега должна быть не менее 5-ти символов.");
        valid = false;
    }
    return valid;
}
function BlogData(t, b) {
    valid = true;
    if (t == "" || b == "") {
        alert("Тема и Содержание должны быть обязательно заполнены.");
        valid = false;
    }
    return valid;
}

function filterContent() {
    let elements = document.getElementsByClassName('blog-container');

    for (let i = 0; i <= elements.length; i++) {
        let blogText = elements[i].getElementsByTagName('p')[0].innerText;

        if (!blogText.toLowerCase().includes(document.getElementById('findtxt').value.toLowerCase())) {
            elements[i].style.display = 'none';
        } else {
            elements[i].style.display = 'inline-block';
        }
    }
}