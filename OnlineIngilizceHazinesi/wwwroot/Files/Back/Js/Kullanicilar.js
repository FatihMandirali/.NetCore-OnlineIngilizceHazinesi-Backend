alert("İçerde");
var app = angular.module("KullaniciList", []);


app.controller("kullaniciList", function ($scope, $http) {
   alert("içerde");
    $http({
        method: "GET",
        url: "/api/Yonetim/GetKullanicilarList"
    }).then(function mySuccess(response) {
        $scope.kullanici = response.data;
        }, function myError(response) {
            if (response.data == "Mesaj")
                window.location = "/Home/Index/";
            else
                $scope.kullanici = response.statusText;
    });
});