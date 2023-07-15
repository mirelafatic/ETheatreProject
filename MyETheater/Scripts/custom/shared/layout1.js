$(document).ready(function () {

    let myetheatreuser = localStorage.getItem('myetheatreuser');
    if (!myetheatreuser) {
        $('#list-item-login').show();
        $('#list-item-logout').hide();
    }
    else {
        $('#list-item-login').hide();
        $('#list-item-logout').show();
    }
})