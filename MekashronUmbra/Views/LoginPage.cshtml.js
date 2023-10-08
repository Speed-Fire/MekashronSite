var loginButton = document.getElementById('loginButton');
var registerButton = document.getElementById('registerButton');

loginButton.onclick = function () {
    var credentials = {
        username: document.getElementById('loginInput').value,
        password: document.getElementById('passwordInput').value
    }

    fetch("/umbraco/api/login/login", {
        method: 'POST',
        type: 'POST',
        headers: {
            'Accept': 'application/json, plain/text',
            'Contet-Type': 'application/json; charset=utf-8'
        },
        body: JSON.stringify(credentials)
    }).then(res => {
        if (res.status == 200) {

            res.json().then(e => {
                Swal.fire({
                    title: 'Login success',
                    text: UserInfo(e),
                    icon: 'success',
                    confirmButtonText: 'Ok'
                });
            })
        }
        else {
            res.json().then(e => {
                Swal.fire({
                    title: 'Access denied',
                    text: e.detail,
                    icon: 'error',
                    confirmButtonText: 'Ok'
                })
            })
        }
    })
};

function UserInfo(e) {
    let res = '';
    res += 'First name: ' + e.FirstName + ';\n';
    res += 'Last name: ' + e.LastName + ';\n';
    res += 'Mobile: ' + e.Mobile + ';\n';
    res += 'Email: ' + e.Email;

    return res;
};

registerButton.onclick = function () {
    fetch("/umbraco/api/login/register", {
        method: 'POST',
        type: 'POST',
        headers: {
            'Accept': 'application/json, plain/text',
            'Contet-Type': 'application/json; charset=utf-8'
        },
    }).then(res => {
        if (res.status == 200) {

            res.text().then(e => {
                Swal.fire({
                    title: 'Register success',
                    text: e,
                    icon: 'success',
                    confirmButtonText: 'Ok'
                });
            })
        }
        else {
            res.json().then(e => {
                Swal.fire({
                    title: 'Access denied',
                    text: e.detail,
                    icon: 'error',
                    confirmButtonText: 'Ok'
                })
            })
        }
    })
}