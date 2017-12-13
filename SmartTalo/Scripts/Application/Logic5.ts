/// <reference path="../typings/jquery/jquery.d.ts" />

class SijainninLuontiModel {
    public Koodi: string;
    public Nimi: string;
    public Osoite: string;
}

function initSijainninLuonti() {
    $("#AsetaButton5").click(function () {

        var koodi: string = $("#Koodi").val();
        var nimi: string = $("#Nimi").val();
        var osoite: string = $("#Osoite").val();
        

        alert("koodi: " + koodi + ", nimi: " + nimi + "osoite: " + osoite);

        var data: SijainninLuontiModel = new SijainninLuontiModel();
        data.Koodi = koodi;
        data.Nimi = nimi;
        data.Osoite = osoite;
      



        //lähetetään json-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/SijainninLuonti/SijainninLuonti",
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