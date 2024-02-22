function validateForm() {
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;

    if (username === 'admin' && password === 'admin') {
        alert('Ви успішно увійшли в систему!');
        window.location.href = 'index.html';
        return false;
    } else {
        alert('Невірний логін або пароль');
        return false;
    }
}