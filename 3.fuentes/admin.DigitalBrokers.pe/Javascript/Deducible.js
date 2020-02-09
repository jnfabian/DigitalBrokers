$(document).ready(function () {
    getAseguradorasAll();
    //getCoberturaTipoAll();
    $('#btnFiltrar').click(getDeduciblesListaAll);


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

function getDeduciblesListaAll() {
    var idAseguradora = document.getElementById('aseguradora').value;

    var ruta = '../deducible/GetDeduciblesListaAll?idAseguradora=' + idAseguradora;

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
                row += "<td><a class='btn btn-success' href='../deducible/Editar/" + item.idDeducible + "'>Editar</a>";
                row += "<td>" + item.idDeducible + "</td>";
                row += "<td>" + item.Categoria + "</td>";
                row += "<td>" + item.Descripcion + "</td>";

                row += "</tr>";
            });
            $("#deducibles").html(row);

        },
        error: function () {
            alert("Falla en listado de Coberturas tipos :(");
        },
    });

}
//GetDeduciblesListaAll
