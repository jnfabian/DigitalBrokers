$(document).ready(function () {

    getAseguradorasAll();
    getCoberturaTipoAll();
    getCoberturaDetalle();
    $('#btnSave').click(saveCobertura);
});

function getAseguradorasAll() {

    $.ajax({
        type: 'GET',
        url: "../../cobertura/GetAseguradorasListaAll",
        contentType: JSON,
        processData: false,
        success: function (results) {
            $("#aseguradora").empty();
            $("#aseguradora").empty();
            $.each(results, function (i, Aseguradora) {
                $("#aseguradora").append("<option value='" + Aseguradora.idAseguradora + "'>" + Aseguradora.vchDescripcion + "</option>");
            });

        },
        error: function () {
            alert("La carga de Aseguradoras presentó un problema.");
        },
    });

}

function getCoberturaTipoAll() {

    $.ajax({
        type: 'GET',
        url: "/cobertura/GetCoberturaTipoListaAll",
        contentType: JSON,
        processData: false,
        success: function (results) {
            $("#cobTipo").empty();
            $("#cobTipo").empty();
            $.each(results, function (i, data) {
                $("#cobTipo").append("<option value='" + data.idCoberturaTipo + "'>" + data.Descripcion + "</option>");
            });

        },
        error: function () {
            alert("La carga de Tipos de Cobertura presentó un problema.");
        },
    });

}

function getCoberturaDetalle() {
    var idCobertura = document.getElementById('idCobertura').value;
    $.ajax({
        type: 'GET',
        url: "../../Cobertura/getCobertura_xID?idCobertura=" + idCobertura,
        contentType: JSON,
        processData: false,
        success: function (resultado) {

            document.getElementById('cobTipo').innerHTML = resultado.idCoberturaTipo;
            document.getElementById('aseguradora').value = resultado.idAseguradora;
            document.getElementById('descripcion').value = resultado.Descripcion;
            document.getElementById('valrconvenio').value = resultado.ValorConvenio;
            //categoria


        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

//Update Cobertura
function saveCobertura() {
    var idCobertura = document.getElementById("idCobertura").value;
    var Descripcion = document.getElementById("descripcion").value;
    var ValorConvenio = document.getElementById("valrconvenio").value;

    //Desabilitar Boton de Guardado
    $("#btnSave").prop("disabled", true);
    var CoberturaData = {
        idCobertura: idCobertura,
        Descripcion: Descripcion,
        ValorConvenio: ValorConvenio,
        Estado: 1
    };

    $.ajax({
        url: "../../Cobertura/SaveCobertura_ID",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(CoberturaData),
        success: function (response) {
            $.toast('Se actualizó la información de la Cobertura.', { 'duration': 3000, 'type': 'danger' });
        },

        error: function (result) {
            $.toast('La Sesion ha finalizado, vuelve a loguerte para guardar los cambios', { 'duration': 3000, 'type': 'danger' });
        }

    });

}