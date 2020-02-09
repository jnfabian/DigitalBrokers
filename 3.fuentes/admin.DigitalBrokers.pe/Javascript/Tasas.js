$(document).ready(function () {
    getAseguradorasAll();   
    $('#btnFiltrar').click(getTasasVehiculares);

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

function getTasasVehiculares() {
    var idAseguradora = document.getElementById('aseguradora').value;
    var Anio = document.getElementById('anio').value;
    var ruta = '../Tasas/GetTasasVehiculares?idAseguradora=' + idAseguradora + '&Anio=' + Anio;

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
                row += "<td><a class='btn btn-success' href='../Tasas/Editar/" + item.idCorrelativo + "'>Editar</a>";
                row += "<td>" + item.idCorrelativo + "</td>";
                row += "<td>" + item.DescAseguradora + "</td>";
                row += "<td>" + item.Clasificacion + "</td>";
                row += "<td>" + item.Provincia + "</td>";
                row += "<td>" + item.Anio + "</td>";
                row += "<td class='success'><strong>" + item.Tasa + " %</strong></td>";



                row += "</tr>";
            });
            $("#tasas").html(row);

        },
        error: function () {
            alert("Falla en listado de Tasas vehiculares :(");
        },
    });

}
