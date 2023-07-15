$(document).ready(function () {

    $('#btn-login').click(function (ev) {
        debugger;
        let username = $('#username').val();
        let password = $('#password').val();

        //AJAX
        if (!username || !password) {
            alert("Please insert all data!");
        }
        else  //AJAX poziv
        {
            $.ajax({
                type: "POST",
                url: "http://localhost:62518/api/user/login",
                data: { Username: username, Password: password },
                success: function (data) {
                    if (data) {
                        localStorage.setItem('hobbytoonuser', JSON.stringify(data));
                        let url = `${window.location.origin}/Home/Index`
                        window.location.href = url;
                    }
                    else {
                        alert("Try again...");
                    }
                }
            })
        }
    })

})