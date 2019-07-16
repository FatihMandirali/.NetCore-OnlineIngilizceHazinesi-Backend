$(document).ready(function(){
    $("#txtSearch").on("keyup", function() {
    var value = $(this).val().toLowerCase();
        $("#KullanicilarTable tr").filter(function() {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
    });
  });
});