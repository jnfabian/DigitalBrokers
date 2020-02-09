$(document).ready(function () {
    getComprasLista();
  
    //$('#btnFiltrar').click(getCoberturasFiltrado);

    ////$('#anofab').change(getVehiculosMarcaModeloAnio);

});

function getComprasLista() {
   
    var ruta = '../../Compras/GetComprasCliente';

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
                row += "<td>" + item.idCompra + "</td>";
                row += "<td class='warning'><a href='../../Cotizacion/Detalle/" + item.idCotizacion + "'>" + item.idCotizacion + "</a></td>";
                row += "<td>" + item.Nombres + "</td>";
                row += "<td>" + item.Apellido_Paterno + "</td>";
                row += "<td>" + item.Apellido_Materno + "</td>";
                row += "<td>" + item.DNI + "</td>";
                row += "<td  class='success'>" + item.Telefono + "</td>";
                row += "<td>" + item.Domicilio + "</td>";
                row += "<td>" + item.Seguro + "</td>";
                row += "<td>" + ToJavaScriptDate(item.FechaCompra) + "</td>";
                row += "<td>" + item.Estado + "</td>";



                row += "</tr>";
            });
            $("#compras").html(row);

        },
        error: function () {
            alert("Problemas detectados :(");
        },
    });

}

function ToJavaScriptDate(Jsonfecha) {
    var date = new Date(parseInt(Jsonfecha.substr(6)));
    var formatted = ("0" + date.getDate()).slice(-2) + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + date.getFullYear();

    return formatted;

}