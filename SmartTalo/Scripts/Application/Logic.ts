/// <reference path="../typings/jquery/jquery.d.ts" />

    class ValoTaloonModel {
    public SijaintiKoodi: string;
    public ValoKoodi: string;       
    }

function initValoAsetus() {
    $("#AsetaButton").click(function () {
        
        var sijaintiKoodi: string = $("#SijaintiKoodi").val();
        var valoKoodi: string = $("#ValoKoodi").val();
               
        alert("S: " + sijaintiKoodi + ", V: " + valoKoodi);

        var data: ValoTaloonModel = new ValoTaloonModel();
        data.SijaintiKoodi = sijaintiKoodi;
        data.ValoKoodi = valoKoodi;        
      


        //lähetetään json-muotoista dataa palvelimelle
        $.ajax({
            type: "POST",
            url: "/Valo/AsetaValoTaloon",
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