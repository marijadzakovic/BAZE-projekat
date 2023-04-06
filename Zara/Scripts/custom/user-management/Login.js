$(document).ready(function () {
    $('#btn-login').click(function (ev) {
        let username = $('#username').val();
        let password = $('#password').val();

        //AJAX
        if (!username || !password) {
            alert("Please insert all data!");
        } else {
            //AJAX POZIV
            $.ajax({
                type: "POST",
                url: "http://localhost:54772/api/user/login",
                data: { Username: username, Password: password },
                success: function (data) {
                    if (data) {
                        localStorage.setItem('zarauser', JSON.stringify(data));
                        let url = `${window.location.origin}/Home/Index`
                        window.location.href = url;
                    } else {
                        alert('Try again!');
                    }

                }
            })

        }

        })
    })
