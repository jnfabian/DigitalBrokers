$(document).ready(function () {
    var idCotizacion = document.getElementById('son');
    if (idCotizacion.value != "") {
        getCotizacionCliente();
        getCotizacionClienteDetalle();
    } else {
        window.location = "../../Vehicular"
    }
   
    //Desarrollo Llamando ahora a la validación
    $('#buy').click(validateFormBuy);

    //Validacion DNI
    $('#Dni').keyup(function () {
        if ($(this).val().length > 7)  {
            $("#buy").prop("disabled", false);
        } else {
            $("#buy").prop("disabled", true);
        }
    });
});

function getCotizacionCliente() {
    var idCotizacion = document.getElementById('son').value;
    
    
    $.ajax({
        type: 'GET',
        url: "../../Cotizacion/GetCotizacionClienteCabecera?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            //Asignar Datos Ingresados
            $('#Email').val(resultado.Mail_Cliente);
            $('#Telefono').val(resultado.TelefonoCliente);
        },
        error: function () {
            //alert("Oh no! :(");

        },
    });

}

function getCotizacionClienteDetalle() {
    var idCotizacion = document.getElementById('son').value;
    $.ajax({
        type: 'GET',
        url: "../../Cotizacion/GetCotizacionClienteDetalle?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            //Prueba Objeto
            console.log(resultado.idMarca);
            //Primas Resultado
            //Agregar los Montos de la cotización en la Compra
            $("#Aseguradora").empty();
         
            $("#Aseguradora").append("<option value='2'>" + ' RIMAC - $' + resultado.Prima_LaPositiva + "</option>");
            $("#Aseguradora").append("<option value='4'>" + ' PACIFICO - $' + resultado.Prima_Pacifico + "</option>");
            $("#Aseguradora").append("<option value='3'>" + ' MAPFRE - $' + resultado.Prima_Mafre + "</option>");
            $("#Aseguradora").append("<option value='1'>" + ' LA POSITIVA- $' + resultado.Prima_LaPositiva + "</option>");
            $("#Aseguradora").append("<option value='5'>" + ' HDI - $' + resultado.Prima_HDI + "</option>");

        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

function Buy() {

    var Nombres = document.getElementById("Nombres").value;
    var Apellido_Paterno = document.getElementById("ApePaterno").value;
    var Apellido_Materno = document.getElementById("ApeMaterno").value;
    var DNI = document.getElementById("Dni").value;
    var Sexo = document.getElementById("sexo").value;
    var Email = document.getElementById("Email").value;
    var Telefono = document.getElementById("Telefono").value;
    var Domicilio = document.getElementById("domicilio").value;
    var Ciudad = document.getElementById("ciudad").value;
    var idAseguradora = document.getElementById("Aseguradora").value;


    $('#buy').val('Generando su Orden de Compra');
    $("#buy").prop("disabled", true);

    var ClienteObjeto = {
        Nombres:Nombres,
        Apellido_Paterno:Apellido_Paterno,
        Apellido_Materno:Apellido_Materno,
        DNI:DNI,
        Sexo:Sexo,
        Email:Email,
        Telefono:Telefono,
        Domicilio:Domicilio,
        Ciudad: Ciudad,
        idAseguradora: idAseguradora
   
    };

    $.ajax({
        url: "../../Compra/GenerarComprar",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(ClienteObjeto),
        success: function (response) {
            $('#buy').val('Estamos listos...');
            $("#buy").prop("disabled", true);
            window.location = '../Compra/thankyou';
        },

        error: function () {
            $.toast('Lamentamos los inconvenientes, intenta de nuevo.', { 'duration': 3000, 'type': 'danger' });
        },


    });


}

function validateFormBuy() {
    var Nombres = document.getElementById('Nombres');
    var ApellidoPaterno = document.getElementById('ApePaterno');
    var ApellidoMaterno = document.getElementById('ApeMaterno');
    var DNI = document.getElementById('Dni');
    var Domicilio = document.getElementById('domicilio');
    var Email = document.getElementById('Email');
    var Telefono = document.getElementById('Telefono');

    var Valido = 0;

    //Nombres
    if (Nombres.value.length < 3) {
        $.toast('Por Favor completa tus Nombres', { 'duration': 3000, 'type': 'danger' });
        Nombres.focus();
        Nombres.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    //Apellido Paterno
    if (ApellidoPaterno.value.length < 3) {
        $.toast('Por Favor completa tu Apellido Paterno', { 'duration': 3000, 'type': 'danger' });

        ApellidoPaterno.focus();
        ApellidoPaterno.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    //Apellido Materno
    if (ApellidoMaterno.value.length < 3) {
        $.toast('Por Favor completa tu Apellido Materno', { 'duration': 3000, 'type': 'danger' });

        ApellidoMaterno.focus();
        ApellidoMaterno.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    //DNI
    if (DNI.value.length < 8) {
        $.toast('Por favor Ingresa tu Nro. de DNI', { 'duration': 3000, 'type': 'danger' });

        DNI.focus();
        DNI.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    //Docimilio
    if (Domicilio.value.length < 7) {
        $.toast('Completa el campo Domicilio para continuar', { 'duration': 3000, 'type': 'danger' });

        Domicilio.focus();
        Domicilio.className += ' invalido';
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
        Buy();
    }
}