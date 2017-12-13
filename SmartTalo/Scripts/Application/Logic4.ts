/// <reference path="../typings/jquery/jquery.d.ts" />

class SaunanLuontiModel {
    public Koodi: string;
    public Tyyppi: string;
    public Tila: string;
    public Lampotila: number;

}

function initSaunanLuonti() {
    $("#AsetaButton4").click(function () {

        var koodi: string = $("#Koodi").val();
        var tyyppi: string = $("#Tyyppi").val();
        var tila: string = $("#Tila").val();
        var lampotila: number = $("#Lampotila").val();

        alert("koodi: " + koodi + ", tyyppi: " + tyyppi + ", tila: " + tila + ", lampotila: " + lampotila);

        var data: SaunanLuontiModel = new SaunanLuontiModel();
        data.Koodi = koodi;
        data.Tyyppi = tyyppi;
        data.Tila = tila;
        data.Lampotila = lampotila;



        //lähetetään json-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/SaunanLuonti/SaunanLuonti",
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