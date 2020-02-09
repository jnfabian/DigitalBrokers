$(document).ready(function () {
    getVehiculos();
    $('#marcasvehiculos').change(getModelosvehiculos);
    $('#anofab').change(getModelosvehiculos);
    $('#ModeloVh').change(getvalorReferencialVehiculo);
    $('#btnCotiza').click(validateFormCotizacion);
    $('#llamada').click(validateForm);

    //Validacion de Existencia de Correo
    $('#Email').keyup(function () {
        if ($(this).val().length > 7 && $("#Telefono").val().length == 6) {
            $("#btnCotiza").prop("disabled", false);
        } else {
            $("#btnCotiza").prop("disabled", true);
        }
    });

    $('#Telefono').keyup(function () {
        if ($(this).val().length > 6 && $("#Email").val().length > 7) {
            $("#btnCotiza").prop("disabled", false);
        } else {
            $("#btnCotiza").prop("disabled", true);
        }
    });

    //Cotizararriba
    var scrollTo = function (top) {
        var content = $(".mdl-layout__content");
        var target = top ? 0 : $(".page-content").height();
        content.stop().animate({ scrollTop: target }, "slow");
    };

    var scrollToTop = function () {
        scrollTo(true);
    };

    var scrollToBottom = function () {
        scrollTo(false);
    };

    $(function () {
        $("#scrollToTop").click(scrollToTop);
        $("#scrollToTopse").click(scrollToTop);
   
    });
   
});


function getVehiculos() {

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
                alert("Oh no! :(");
            },
        });

}

function getModelosvehiculos() {
    //Hola
    var idMarca = document.getElementById('marcasvehiculos').value;
    var idAnio = document.getElementById('anofab').value;
    
    var URLMethod = '/vehicular/GetModelosVehiculos?idMarca=' + idMarca + '&idAnio=' + idAnio;
    $.ajax({
        type: 'GET',
        url: URLMethod,
        contentType: JSON,
        processData: false,
        success: function (results) {
            $("#ModeloVh").empty();

            $.each(results, function (i, modeloVH) {
                $("#ModeloVh").append("<option value='" + modeloVH.idModelo + "--" + modeloVH.AnioVehiculoPrecio + "'>" + modeloVH.Descripcion_Modelo + "</option>");
            });
            //Actualizar el valor Referencial
            getvalorReferencialVehiculo();

        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

function getvalorReferencialVehiculo() {
    var Modelo = $("#ModeloVh option:selected").val();
    var ValorReferencial = Modelo.toString().split('--')[1].toString();
    // var Valor = ValorReferencial[1].toString();
    //$("#valorVehiculo").append("<option selected value='" + ValorReferencial + "'>" + ValorReferencial + "</option>");
    document.getElementById("valorVehiculo").value = Math.round(ValorReferencial);
    console.log(ValorReferencial);
}

function SolicitudCotizacion() {
    
        //Generacion de la Solicitud de Cotizacion
        var idMarca = document.getElementById("marcasvehiculos").value;
        var idModelo = document.getElementById("ModeloVh").value;
        var Modelo = $("#ModeloVh option:selected").html();
        var Marca = $("#marcasvehiculos option:selected").html();
        var Anio = document.getElementById("anofab").value;
        var decValorRef = document.getElementById("valorVehiculo").value;
        //var UsoVehiculo = document.getElementById("usoVehiculo").value;
        var Email = document.getElementById("Email").value;
        var Telefono = document.getElementById("Telefono").value;
        var Res = 'HTTP';
        //$("#cotizaForm").html('');
        //$("#cotizaForm").html("<div id='demo' class='mdl-progress mdl-js-progress mdl-progress__indeterminate'></div>");
        
        //Obteniendo el IDModelo para la cotización
        idModelo = idModelo.toString().split('--')[0].toString();
        console.log('ID Modelo para la cotización es:' + idModelo)


        $('#btnCotiza').val('Procesando su Cotización');
        $("#btnCotiza").prop("disabled", true);
        $.toast('<i class="material-icons">hourglass_empty</i> Estamos buscando las mejores opciones para ti.', { 'duration': 5000, 'type': 'danger' });
        var SolicitudObjeto = {
            idMarca: idMarca,
            IdModelo: idModelo,
            Desccripcion_Marca:Marca + " " + Modelo,
            Anio:Anio,
            ValorReferencial:decValorRef,
            UsoVehiculo: 'PA',
            Descripcion_Modelo:Marca + " " +  Modelo,
            EmailSolicitante:Email,
            TelefonoSolicitante:Telefono,
            httpResponseURLEncode:Res

        };

        $.ajax({
            url: "../Cotizacion/SaveCotizacionCliente",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(SolicitudObjeto),
            success: function (response) {

                $('#btnCotiza').val('Estamos listos...');
                $("#btnCotiza").prop("disabled", true);
                window.location = '../Cotizacion/GenerarCotizacion';
            }

        });

    
}

function SolicitudLlamada() {

    //Generacion de la Solicitud de Cotizacion
    var intTipoSolicitud = 1;
    var Nombres = document.getElementById("soNombres").value;
    var Email = document.getElementById("soEmail").value;
    var Telefono = document.getElementById("soTelefono").value;
    var Res = 'HTTP';


    $('#llamada').val('Estamos Contactando con tu broker.');
    $("#llamada").prop("disabled", true);

    var SolicitudObjeto = {
        intTipoSolicitud: intTipoSolicitud,
        Nombres:Nombres,
        EmailSolicitante: Email,
        TelefonoSolicitante: Telefono,
        httpResponseURI: Res

    };

    $.ajax({
        url: "../Cotizacion/SolicitudCotizacionVehicular",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(SolicitudObjeto),
        success: function (response) {
            $('#llamada').val('Hecho');
            window.location = '../Vehicular/Gracias';
        }

    });


}

function validateForm() {
    var Nombres = document.getElementById('soNombres');
    var Email = document.getElementById('soEmail');
    var Telefono = document.getElementById('soTelefono');

    var Valido = 0;

    if (Nombres.value.length < 3) {
        $.toast('Completa Tu nombre para continuar', { 'duration': 3000, 'type': 'danger' });
        Nombres.focus();
        Nombres.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }


    if (Email.value.length < 3) {
        $.toast('Necesitamos un Email para comunicarnos contigo.', { 'duration': 3000, 'type': 'danger' });

        Email.focus();
        Email.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    if (Telefono.value.length < 8) {
        $.toast('Nos comunicaremos al numero que indiques.', { 'duration': 3000, 'type': 'danger' });

        Telefono.focus();
        Telefono.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

   
    if (Valido != 0) {
        SolicitudLlamada();
    }
}

function validateFormCotizacion() {

    var Email = document.getElementById('Email');
    var Telefono = document.getElementById('Telefono');
    var ValorReferencial = document.getElementById('valorVehiculo');

    var Valido = 0;




    if (Email.value.length <5) {
        $.toast('Necesitamos un Email válido para comunicarnos contigo.', { 'duration': 3000, 'type': 'danger' });

        Email.focus();
        Email.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    if (Telefono.value.length < 8) {
        $.toast('Nos comunicaremos al numero que indiques.', { 'duration': 3000, 'type': 'danger' });

        Telefono.focus();
        Telefono.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    if (ValorReferencial.value.length < 4) {
        $.toast('No parece ser un valor referencial válido.', { 'duration': 3000, 'type': 'danger' });

        ValorReferencial.focus();
        ValorReferencial.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }


    if (Valido != 0) {
        SolicitudCotizacion();
    }
}