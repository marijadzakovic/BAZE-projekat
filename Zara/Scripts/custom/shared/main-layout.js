$(document).ready(function () {
    let zarauser = localStorage.getItem('zarauser');
    if (!zarauser) {
        $('#list-item-login').show();
        $('#list-item-logout').hide();

    } else {
        $('#list-item-login').hide();
        $('#list-item-logout').show();
    }
})