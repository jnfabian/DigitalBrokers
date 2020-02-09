$(document).ready(function () {
    getTasaVehicular();
    $('#btnSave').click(saveTasabyCorrelativo);

});

function getTasaVehicular() {
    var idCorrelativo = document.getElementById('idCorrelativo').value;
    $.ajax({
        type: 'GET',
        url: "../../Tasas/GetTasaVehicularByID?idCorrelativo=" + idCorrelativo,
        contentType: JSON,
        processData: false,
        success: function (resultado) {

            document.getElementById('aseguradora').innerHTML = resultado.DescAseguradora;
            document.getElementById('clasificacion').innerHTML = resultado.Clasificacion;
            document.getElementById('provincia').innerHTML = resultado.Provincia;
            document.getElementById('anio').innerHTML = resultado.Anio;
            document.getElementById('tasa').innerHTML = resultado.Tasa;
            //categoria tasavehicular


        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

//UPD Tasa by Correlativo
function saveTasabyCorrelativo() {
    var idCorrelativo = document.getElementById('idCorrelativo').value;
    var Tasa = document.getElementById('tasa').innerHTML;

    //Desabilitar Boton de Guardado
    $("#btnSave").prop("disabled", true);
    var TasaData = {
        idCorrelativo: idCorrelativo,
        Tasa: Tasa

    };

    $.ajax({
        url: "../../Tasas/UPDTasaBYCorrelativo?idCorrelativo=" + idCorrelativo + "&Tasa=" + Tasa,
        type: "GET",
        contentType: "application/json",
        data: JSON.stringify(TasaData),
        success: function (response) {
            $.toast('Se actualizó la información de la Tasa.', { 'duration': 3000, 'type': 'danger' });
        },

        error: function (result) {
            $.toast('No se logró actualizar la Tasa', { 'duration': 3000, 'type': 'danger' });
        }

    });

}
