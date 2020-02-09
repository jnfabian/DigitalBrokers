
$(document).ready(function () {
    getCotizacionCliente();
    getCotizacionClienteDetalle();
    getCoberturasAseguradoras();

});
function getCotizacionCliente() {
    var idCotizacion = document.getElementById('son').value;
    $.ajax({
        type: 'GET',
        url: "../Salud/GetCotizacionClienteCabecera?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            //Prueba Objeto
            console.log(resultado.idMarca);
            document.getElementById("0001").innerHTML = "<i class='material-icons'>face</i> Hola " + resultado.Nombres + " " + resultado.Apellidos + ", Edad: " + resultado.Edad + " DNI:" + resultado.DNI + ", aquí tienes tu cotización";
          // document.getElementById("0002").innerHTML = "Edad: " + resultado.Edad + " DNI:" + resultado.DNI;
        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

function getCotizacionClienteDetalle() {
    var idCotizacion = document.getElementById('son').value;
    $.ajax({
        type: 'GET',
        url: "../Salud/GetCotizacionClienteDetalle?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {

            //AGREGANDO EL IGV INCLUIDO
            var strIVA = " (Pago Anual inc. IGV)";
            console.log(resultado.idMarca);
            //Primas Resultado
            if (resultado.Prima_Rimac == 0 ? document.getElementById("prima_rimac").innerHTML = "Consultar Prima" : document.getElementById("prima_rimac").innerHTML = "S/." + resultado.Rimac + strIVA);
            if (resultado.Prima_Pacifico == 0 ? document.getElementById("prima_pacifico").innerHTML = "Consultar Prima" : document.getElementById("prima_pacifico").innerHTML = "S/." + resultado.Pacifico + strIVA);
            if (resultado.Prima_Mafre == 0 ? document.getElementById("prima_mafre").innerHTML = "Consultar Prima" : document.getElementById("prima_mafre").innerHTML = "S/." + resultado.Mapfre + strIVA);
           

          
        },
        error: function () {
            alert("Oh no! no eres tu, somos nosotros :(");
        },
    });

}

function getCoberturasAseguradoras() {

    $.ajax({
        type: 'GET',
        url: "../Cobertura/GetCoberturasSalud",
        contentType: JSON,
        processData: false,
        success: function (data) {
            //Get Coberturas Rimac
            var RimacCoberturaItem = "";
            var PacificoCoberturaItem = "";
            var MafreCoberturaItem = "";
            

            $.each(data, function (index, item) {



                //RIMAC
                if (item.idAseguradora == 2) {
                    RimacCoberturaItem += "	<li><strong>" + item.Descripcion + ":</strong> " + item.Valor + "</li><br>";

                }

                //MAFRE
                if (item.idAseguradora == 3) {
                    MafreCoberturaItem += "	<li><strong>" + item.Descripcion + ":</strong> " + item.Valor + "</li><br>";

                }

                //PACIFICO
                if (item.idAseguradora == 4) {
                    PacificoCoberturaItem += "	<li><strong>" + item.Descripcion + ":</strong> " + item.Valor + "</li><br>";

                }

            

            });

          
            $("#RimacCobertura").html(RimacCoberturaItem);
            $("#PacificoCobertura").html(PacificoCoberturaItem);
            $("#MafreCobertura").html(MafreCoberturaItem);

        },
        error: function () {
            alert("Oh no!algo no va bien :(");
        },
    });

}