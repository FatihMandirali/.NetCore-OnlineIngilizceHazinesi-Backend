$(document).on("click", "#btnGirisYap", function () {
    var kadi = $("#username").val();
    var sifre = $("#password").val();
    alert(kadi);
    var emp = {
        "username": kadi,
        "password": sifre
    };
    $.ajax({
        method: "POST",
        url: "/Yonetim/AdminLogin/",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(emp),
    }).done(function (response, statusText, jqXHR) {


        if (response.isOkey == true)
            window.location = "/Yonetim/Kullanicilar/";
        else
            alert("Kullanıcı Adı veya Şifre Yanlış");


    });
});