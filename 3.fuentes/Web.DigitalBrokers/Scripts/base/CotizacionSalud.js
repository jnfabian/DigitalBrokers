$(document).ready(function () {
    $('#btnCotiza').click(validateForm);

});

function CotizacionSalud() {

    //Generacion de la Solicitud de Cotizacion
    
    var Nombres = document.getElementById("Nombres").value;
    var Apellidos = document.getElementById("Apellidos").value;
    var DNI = document.getElementById("DNI").value;
    var Edad = document.getElementById("Edad").value;
    var Email = document.getElementById("Email").value;
    var Telefono = document.getElementById("Telefono").value;
    
    $.toast('<i class="material-icons">hourglass_empty</i> Estamos buscando las mejores opciones para ti.', { 'duration': 5000, 'type': 'danger' });
    $("#btnCotiza").prop("disabled", true);

    var PersonaObjeto = {
        Nombres: Nombres,
        Apellidos: Apellidos,
        DNI: DNI,
        Edad: Edad,
        Email: Email,
        Telefono: Telefono

    };

    $.ajax({
        url: "../Salud/CotizarSalud",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(PersonaObjeto),
        success: function (response) {
            $('#btnCotiza').val('Estamos listos...');
            $("#btnCotiza").prop("disabled", true);
            window.location = '../Salud/Cotizacion';
        }

    });


}

function validateForm()
{
    var Nombres = document.getElementById('Nombres');
    var Apellidos = document.getElementById('Apellidos');
    var DNI = document.getElementById('DNI');
    var Email = document.getElementById('Email');
    var Edad = document.getElementById('Edad');
    var Telefono = document.getElementById('Telefono');
    var Valido = 0;

    if (Nombres.value.length < 3)
    {
        $.toast('Completa Tu nombre para continuar', { 'duration': 3000, 'type': 'danger' });
        Nombres.focus();
        Nombres.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1;}
   

    if (Apellidos.value.length < 3) {
        $.toast('Completa tus Apellidos para continuar', { 'duration': 3000, 'type': 'danger' });

        Apellidos.focus();
        Apellidos.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    if (DNI.value.length < 8) {
        $.toast('Por favor ingresa tu DNI', { 'duration': 3000, 'type': 'danger' });
      
        DNI.focus();
        DNI.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    if (Email.value.length < 3) {
        $.toast('Requerimos una dirección de correo para enviarte la cotización.', { 'duration': 3000, 'type': 'danger' });
        
        Email.focus();
        Email.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    if (Edad.value.length <= 0) {
        $.toast('Necesitamos saber tu edad para realizar la cotzación.', { 'duration': 3000, 'type': 'danger' });

        Edad.focus();
        Edad.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    if (Telefono.value.length <= 8) {
        $.toast('Por favor indicanos tu teléfono.', { 'duration': 3000, 'type': 'danger' });
        Telefono.focus();
        Telefono.className += ' invalido';
        Valido = 0;
        return false;
    } else { Valido = 1; }

    if (Valido != 0) {
        CotizacionSalud();
    }
}