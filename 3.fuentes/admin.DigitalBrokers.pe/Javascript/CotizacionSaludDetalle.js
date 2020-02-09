$(document).ready(function () {
    getCotizacionCabecera();
    getCotizacionClienteDetalle();

});

function getCotizacionCabecera() {
    var idCotizacion = document.getElementById('idCotizacion').value;
    $.ajax({
        type: 'GET',
        url: "../../Cotizacion/GetCotizacionSaludcabecera?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
          

            document.getElementById("idCotizacions").innerHTML = "Detalle de Cotización - Sr(a). " + resultado.Nombres + " " + resultado.Apellidos;
            document.getElementById("Titulo").innerHTML = "Cotizacion Nro:" + resultado.idCotizacionSalud;

            document.getElementById("Nombres").innerHTML = resultado.Nombres + " " + resultado.Apellidos;
            document.getElementById("Edad").innerHTML = resultado.Edad;
            document.getElementById("DNI").innerHTML = resultado.DNI;
            document.getElementById("Email").innerHTML = resultado.Email;
            document.getElementById("Telefono").innerHTML = resultado.Telefono;
         

        },
        error: function () {
            alert("Error cargando el detalle de la cotización");
        },
    });

}

function getCotizacionClienteDetalle() {
    var idCotizacion = document.getElementById('idCotizacion').value;
    $.ajax({
        type: 'GET',
        url: "../../Cotizacion/GetCotizacionSaludDetalle?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {


            //RIMAC
            if (resultado.Rimac == 0 ? document.getElementById("RIMAC").innerHTML = "Consultar Prima" : document.getElementById("RIMAC").innerHTML = "S/. " + resultado.Rimac);


            //PACIFICO
            if (resultado.Pacifico == 0 ? document.getElementById("PACIFICO").innerHTML = "Consultar Prima" : document.getElementById("PACIFICO").innerHTML = "S/. " + resultado.Pacifico);


            //MAPFRE
            if (resultado.Mapfre == 0 ? document.getElementById("MAPFRE").innerHTML = "Consultar Prima" : document.getElementById("MAPFRE").innerHTML = "S/. " + resultado.Mapfre);

        },
        error: function () {
            alert("Se produjo un error obteniendo el detalle de la cotización.");
        },
    });

}