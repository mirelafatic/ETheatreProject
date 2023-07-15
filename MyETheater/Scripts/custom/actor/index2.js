$(document).ready(function () {

    let myetheatreuser = localStorage.getItem('myetheatreuser');
    if (!myetheatreuser) {
        $('#map').hide();
        $('#addactor').hide();
        $('#removeactor').hide();
    }
    else {
        $('#addactor').show();
        $('#removeactor').show();
        $('#map').show();
    }
})