$(document).ready(function () {
    getCoberturasAseguradoras();
    

});

function getCoberturasAseguradoras() {
    var idCotizacion = document.getElementById('son').value;
    $.ajax({
        type: 'GET',
        url: "../../../Cobertura/GetCoberturasAseguradoras?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (data) {
            //Get Coberturas Rimac
            var RimacCoberturaItem = "";
            var PacificoCoberturaItem = "";
            var MafreCoberturaItem = "";
            var HDICoberturaItem = "";
            var LaPositivaCoberturaItem = "";

            $.each(data, function (index, item) {

                //LA POSITIVA
                if (item.idAseguradora == 1) {
                    LaPositivaCoberturaItem += "	<li><strong>" + item.Descripcion + ":</strong> " + item.ValorConvenio + "</li><br>";

                }

                //RIMAC
                if (item.idAseguradora == 2) {
                    RimacCoberturaItem += "	<li><strong>" + item.Descripcion + ":</strong> " + item.ValorConvenio + "</li><br>";
      
                }

                //MAFRE
                if (item.idAseguradora == 3) {
                    MafreCoberturaItem += "	<li><strong>" + item.Descripcion + ":</strong> " + item.ValorConvenio + "</li><br>";

                }

                //PACIFICO
                if (item.idAseguradora == 4) {
                    PacificoCoberturaItem += "	<li><strong>" + item.Descripcion + ":</strong> " + item.ValorConvenio + "</li><br>";

                }

                //HDI
                if (item.idAseguradora == 5) {
                    HDICoberturaItem += "	<li><strong>" + item.Descripcion + ":</strong> " + item.ValorConvenio + "</li><br>";

                }
     
            });

            $("#LaPositivaCobertura").html(LaPositivaCoberturaItem);
            $("#RimacCobertura").html(RimacCoberturaItem);
            $("#PacificoCobertura").html(PacificoCoberturaItem);
            $("#MafreCobertura").html(MafreCoberturaItem);
            $("#HDICobertura").html(HDICoberturaItem);
          
        },
        error: function () {
            alert("Oh no!algo no va bien :(");
        },
    });

}