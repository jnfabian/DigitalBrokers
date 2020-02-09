$(document).ready(function () {
    getMarcasVehiculos();
    $('#anofab').change(getVehiculosMarcaModeloAnio);
    $('#marcasvehiculos').change(getVehiculosMarcaModeloAnio);
});


function getMarcasVehiculos() {

    $.ajax({
        type: 'GET',
        url: "/vehicular/GetMarcasVehiculos",
        contentType: JSON,
        processData: false,
        success: function (results) {
            $("#ModeloVh").empty();
            $("#marcasvehiculos").empty();
            $("#marcasvehiculos").append("<option selected value='0'>.::Seleccione Marca ::.</option>");
            $.each(results, function (i, vehiculo) {
                $("#marcasvehiculos").append("<option value='" + vehiculo.idMarca + "'>" + vehiculo.Descripcion + "</option>");
            });

        },
        error: function () {
            alert("La caraga de marcas ha presentado un inconveniente.");
        },
    });

}

function getVehiculosMarcaModeloAnio() {
    var idMarca = document.getElementById('marcasvehiculos').value;
    var Anio = document.getElementById('anofab').value;
    var ruta = '../../Vehicular/GetVehiculosPorMarcaAnio?idMarca=' + idMarca + '&Anio=' + Anio;
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
                row += "<td><a class='btn btn-success' href='../Vehicular/Editar?idMarca=" + item.idMarca + "&idModelo=" + item.idModelo + "&Anio="  +Anio +"'>Editar</a>";
                row += "<td>" + item.idMarca + "</td>";
                row += "<td>" + item.Marca + "</td>";
                row += "<td>" + item.Descripcion_Modelo + "</td>";
                row += "<td>" + item.Carroceria + "</td>";
                row += "<td>" + item.Puertas + "</td>";
                row += "<td>" + item.Asientos + "</td>";
                row += "<td>" + item.Traccion + "</td>";
                row += "<td>" + item.Desplazamiento + "</td>";
                row += "<td>" + item.Potencia + "</td>";
                row += "<td>" + item.Carburante + "</td>";
                row += "<td>USD$" + item.VRN + "</td>";
                row += "<td class='success'><strong>USD$" + item.PrecioAnio + "<strong></td>";


                row += "</tr>";
            });
            $("#vehiculos").html(row);

        },
        error: function () {
            alert("Algo no planeado sucedió :(");
        },
    });

}