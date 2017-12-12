/// <reference path="../typings/jquery/jquery.d.ts" />

class ValonLuontiModel {
    public Koodi: string;
    public Tyyppi: string;
    public Tila: string;
    public Valonmaara: number;

}

function initValonLuonti() {
    $("#AsetaButton3").click(function () {

        var koodi: string = $("#Koodi").val();
        var tyyppi: string = $("#Tyyppi").val();
        var tila: string = $("#Tila").val();
        var valonmaara: number = $("#Valonmaara").val();

        alert("k: " + koodi + ", t: " + tyyppi + "ti: " + tila + "V: " + valonmaara);

        var data: ValonLuontiModel = new ValonLuontiModel();
        data.Koodi = koodi;
        data.Tyyppi = tyyppi;
        data.Tila = tila;
        data.Valonmaara = valonmaara;



        //lähetetään json-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/ValonLuonti/ValonLuonti",
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