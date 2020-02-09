$(document).ready(function () {
    getAseguradorasAll();
    getCoberturaTipoAll();
    $('#btnFiltrar').click(getCoberturasFiltrado);

    //$('#anofab').change(getVehiculosMarcaModeloAnio);

});

function getAseguradorasAll() {

    $.ajax({
        type: 'GET',
        url: "/cobertura/GetAseguradorasListaAll",
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

function getCoberturasFiltrado() {
    var idAseguradora = document.getElementById('aseguradora').value;
    var idCoberturaTipo = document.getElementById('cobTipo').value;
    var ruta = '../../Cobertura/GetCobTipobyAseguradoraTipoCobertura?idAseguradora=' + idAseguradora + '&idCoberturaTipo=' + idCoberturaTipo;

    $.ajax({
        type: 'GET',
        url: ruta,
        contentType: JSON,
        processData: false,
        success: function (data) {
            //Leer Cotizaciones de la tabla
            var row = "";
            $.each(data, function (index, item) {
                row += "<tr>";
                row += "<td><a class='btn btn-success' href='../cobertura/Editar/" + item.idCobertura + "'>Editar</a>";
                row += "<td>" + item.idCobertura + "</td>";
                row += "<td>" + item.Descripcion + "</td>";
                row += "<td>" + item.ValorConvenio + "</td>";
                row += "<td>" + item.Estado + "</td>";
               


                row += "</tr>";
            });
            $("#coberturas").html(row);

        },
        error: function () {
            alert("Falla en listado de Coberturas tipos :(");
        },
    });

}