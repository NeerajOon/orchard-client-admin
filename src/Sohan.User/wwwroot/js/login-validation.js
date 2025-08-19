$(document).ready(function () {

    $("#userloginForm").validate({
        rules: {
            usernameEmail: {
                required: true,
                minlength: 3
            },
            password: {
                required: true,
                minlength: 6
            }
        },
        messages: {
            usernameEmail: {
                required: "Please enter your username or email",
                minlength: "Must be at least 3 characters"
            },
            password: {
                required: "Please enter your password",
                minlength: "Password must be at least 6 characters"
            }
        },
        errorElement: 'div',
        errorClass: 'invalid-feedback',
        highlight: function (element) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element) {
            $(element).removeClass('is-invalid');
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent()); 
            } else {
                error.insertAfter(element);
            }
        }
    });
});
