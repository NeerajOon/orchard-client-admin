$(document).ready(function () {
    // User Login
    $("#userloginForm").on("submit", function (e) {
        e.preventDefault();

        if (!$("#userloginForm").valid()) return;
        var formData = {
            Name: $("#usernameEmail").val(),
            Password: $("#password").val()
        };
        var token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: '/api/User/login',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            credentials: "include",
            headers: {
                'RequestVerificationToken': token
            },
            success: function (response) {
                console.log(" Success:", response);
                alert("Login successful!");
                window.location.href = "/Profile";
            },
            error: function (xhr) {
                console.error(" Error:", xhr.responseText);
                alert("Login failed. Please try again.");
            }
        });
    });

    // User Register

    $("#registrationForm").on("submit", function (e) {
        e.preventDefault(); // stop default form submit

        // Check if form is valid
        if (!$("#registrationForm").valid()) return;

        var formData = {
            Name: $("#name").val(),
            Email: $("#email").val(),
            Username: $("#username").val(),
            Password: $("#password").val(),
            ConfirmPassword: $("#confirmPassword").val()
        };

        var token = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            url: '/api/User/register',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            headers: {
                'RequestVerificationToken': token
            },
            success: function (response) {
                console.log("Success:", response);
                alert("Registration successful!");
            },

            error: function (xhr) {
                console.error("Error:", xhr.responseText);
                alert("Registration failed. Please try again.");
            }
        });
    });
});
var user = {

    get: function () {
        $.ajax({
            url: '/api/User/profile',
            type: "GET",
            contentType: 'application/json',
            success: function (response) {
                console.log("Success:", response);
                alert("data get!");
            },
            error: function (xhr) {
                console.error("Error:", xhr.responseText);
                alert("Failed. Please try again.");
            }
        })
    }
}