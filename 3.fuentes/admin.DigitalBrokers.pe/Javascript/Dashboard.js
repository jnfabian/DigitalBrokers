$(document).ready(function () {
    getCotizacionesDashboard();
    //getCotizacionesSaludDashboard();
    setInterval(getCotizacionesDashboard, 60000);
    document.getElementById('chkVivo').onchange = function () {

        if (document.getElementById('chkVivo').checked == true)
        {

            document.getElementById('lblVivo').innerText = '(Cotizaciones En vivo)';
            $("#txtdesde").prop("disabled", true);
            $("#txthasta").prop("disabled", true);
            $("#btnFiltrar").prop("disabled", true);
        }
        if (document.getElementById('chkVivo').checked == false) {

            document.getElementById('lblVivo').innerText = 'Filtrar';
            $("#txtdesde").prop("disabled", false);
            $("#txthasta").prop("disabled", false);
            $("#btnFiltrar").prop("disabled", false);
        }
    };
    $('#btnFiltrar').click(filtrar);

});

function getCotizacionesDashboard() {
    $.ajax({
        type: 'GET',
        url: "../Plataforma/GetCotizacionesDashboard",
        contentType: JSON,
        processData: false,
        success: function (data) {
            //Leer Cotizaciones de la tabla
            var row = "";
            $.each(data, function (index, item) {


                row += "<tr>";
                row += "<td><a class='btn btn-success' href='../Cotizacion/Detalle/" + +item.idCotizacion + "'>(+)</a>";
                row += "<td><a href='../cotizacion/DownloadPDFVehicular?id=" + item.idCotizacion + "'><img src='../images/pdf.png' alt='Descarga Cotización en PDF'/></a></td>";
                row += "<td>" + item.idCotizacion + "</td>";
                row += "<td>" + item.Descripcion_Modelo + "</td>";
                row += "<td>" + item.Mail_Cliente + "</td>";
                row += "<td>" + item.TelefonoCliente + "</td>";
                row += "<td class='success'>USD$" + item.ValorReferencial + "</td>";
                row += "<td>" + ToJavaScriptDate(item.FechaCreacion) + "</td>";
                row += "</tr>";
            });
            $("#Cotizaciones").html(row);
            
            document.getElementById('vehicularUpdate').innerHTML = 'Actualizado:' + formatAMPM();
        },
        error: function () {
            //alert("Su Sesión ha finalizado. Inicie Sesión en la plataforma :(");
            window.location = '../../Usuario/Login';
        },
    });

}

function getCotizacionesSaludDashboard() {
    $.ajax({
        type: 'GET',
        url: "../Plataforma/GetCotizacionesSaludDashboard",
        contentType: JSON,
        processData: false,
        success: function (data) {
            //Leer Cotizaciones de la tabla
            var row = "";
            $.each(data, function (index, item) {


                row += "<tr>";
                row += "<td><a class='btn btn-success' href='../Cotizacion/DetalleSalud/" + +item.idCotizacionSalud + "'>(+)</a>";
                row += "<td>" + item.idCotizacionSalud + "</td>";
                row += "<td>" + item.Nombres +  " " + item.Apellidos + "</td>";
                row += "<td>" + item.Edad + "</td>";
                row += "<td class='warning'>" + item.DNI + "</td>";
                row += "<td>" + item.Telefono + "</td>";
                row += "<td>" + ToJavaScriptDate(item.FechaSolicitud) + "</td>";
                row += "</tr>";
            });
            $("#CotizacionesSalud").html(row);

        },
        error: function () {
            alert("Algo no planeado sucedió :(");
        },
    });

}

//FILTROS
function filtrar() {
    getCotizacionesDashboardFiltro();
    getCotizacionesSaludDashboardFiltro();
}
function getCotizacionesDashboardFiltro() {
    var FechaInicio = document.getElementById('txtdesde').value;
    var FechaFin = document.getElementById('txthasta').value;
    var URL = "../Plataforma/GetCotizacionesDashboardFiltro?FechaInicio=" + FechaInicio + "&FechaFin=" + FechaFin;
    $.ajax({
        type: 'GET',
        url: URL,
        contentType: JSON,
        processData: false,
        success: function (data) {
            //Leer Cotizaciones de la tabla
            var row = "";
            $.each(data, function (index, item) {


                row += "<tr>";
                row += "<td><a class='btn btn-success' href='../Cotizacion/Detalle/" + +item.idCotizacion + "'>(+)</a>";
                row += "<td>" + item.idCotizacion + "</td>";
                row += "<td>" + item.Descripcion_Modelo + "</td>";
                row += "<td>" + item.Mail_Cliente + "</td>";
                row += "<td>" + item.TelefonoCliente + "</td>";
                row += "<td class='success'>USD$" + item.ValorReferencial + "</td>";
                row += "<td>" + ToJavaScriptDate(item.FechaCreacion) + "</td>";
                row += "</tr>";
            });
            $("#Cotizaciones").html(row);

            document.getElementById('vehicularUpdate').innerHTML = 'Actualizado:' + formatAMPM();
        },
        error: function () {
            alert("Al parecer los datos ingresados no son correctos :(");
            //window.location = '../../Usuario/Login';
        },
    });

}

function getCotizacionesSaludDashboardFiltro() {
    var FechaInicio = document.getElementById('txtdesde').value;
    var FechaFin = document.getElementById('txthasta').value;
    var URL = "../Plataforma/GetCotizacionesSaludDashboardFiltro?FechaInicio=" + FechaInicio + "&FechaFin=" + FechaFin;
    $.ajax({
        type: 'GET',
        url:URL,
        contentType: JSON,
        processData: false,
        success: function (data) {
            //Leer Cotizaciones de la tabla
            var row = "";
            $.each(data, function (index, item) {


                row += "<tr>";
                row += "<td><a class='btn btn-success' href='../Cotizacion/DetalleSalud/" + +item.idCotizacionSalud + "'>(+)</a>";
                row += "<td>" + item.idCotizacionSalud + "</td>";
                row += "<td>" + item.Nombres + " " + item.Apellidos + "</td>";
                row += "<td>" + item.Edad + "</td>";
                row += "<td class='warning'>" + item.DNI + "</td>";
                row += "<td>" + item.Telefono + "</td>";
                row += "<td>" + ToJavaScriptDate(item.FechaSolicitud) + "</td>";
                row += "</tr>";
            });
            $("#CotizacionesSalud").html(row);

        },
        error: function () {
            alert("Algo no planeado sucedió :(");
        },
    });

}

function ToJavaScriptDate(Jsonfecha) {
    var date = new Date(parseInt(Jsonfecha.substr(6)));
    var formatted = ("0" + date.getDate()).slice(-2) + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + date.getFullYear();

    return formatted;

}

function formatAMPM() {
    var date =  new Date();
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}