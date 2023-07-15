$(document).ready(function () {

    let myetheatreuser = localStorage.getItem('myetheatreuser');
    if (!myetheatreuser) {
        $('.reservation').hide();
        $('.delete').hide();
        $('#newplay').hide();
        $('#addshowing').hide();
        $('#map').hide();
    }
    else {
        $('.reservation').show();
        $('.delete').show();
        $('#newplay').show();
        $('#addshowing').show();
        $('#map').show();
    }
})