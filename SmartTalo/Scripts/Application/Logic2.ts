/// <reference path="../typings/jquery/jquery.d.ts" />

class SaunaTaloonModel {
    public SijaintiKoodi: string;
    public SaunaKoodi: string;
}
function initSaunaAsetus() {
    $("#AsetaSaunaButton").click(function () {
        var sijaintiKoodi: string = $("#SijaintiKoodi2").val();
        var saunaKoodi: string = $("#SaunaKoodi").val();

        alert("Sijainti: " + sijaintiKoodi + ", Sauna: " + saunaKoodi);
        var data: SaunaTaloonModel = new SaunaTaloonModel();
        data.SijaintiKoodi = sijaintiKoodi;
        data.SaunaKoodi = saunaKoodi;
        //lähetetään json-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/Sauna/AsetaSaunaTaloon",
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {
                if (data.success == true) {
                    alert("Asset successfully assigned.");
                }
                else {
                    alert("There was an error: " + data.error);
                }
            },
            dataType: "json"
        });
    });
}