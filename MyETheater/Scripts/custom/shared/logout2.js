$(document).ready(function () {
    $('#logout').click(function (ev) {
        if (confirm("Are you sure that you want to logout?")) {
            localStorage.removeItem('myetheatreuser');
            let url = `${window.location.origin}/Home/Index`
            window.location.href = url;
        }
    })
})