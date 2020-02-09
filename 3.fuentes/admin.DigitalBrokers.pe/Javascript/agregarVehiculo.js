$(document).ready(function () {
    getMarcasVehiculos();
    $('#btnSave').click(saveNewVehicular);
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

function saveNewVehicular() {
    //Agregar Vehiculo En Plataforma

    var idMarca = document.getElementById('marcasvehiculos').value;
    var Marca = $("#marcasvehiculos>option:selected").html();
    var idModelo = document.getElementById('idModelo').value;
    var Descripcion_Modelo = document.getElementById('Modelo').value;
    var Carroceria = document.getElementById('carroceria').value;
    var Puertas = document.getElementById('puertas').value;
    var Asientos = document.getElementById('asientos').value;
    var Traccion = document.getElementById('traccion').value;
    var Desplazamiento = document.getElementById('desplazamiento').value;
    var Potencia = document.getElementById('potencia').value;
    var Carburante = document.getElementById('carburante').value;
    var VRN = document.getElementById('VRN').value;

    var P2017 = document.getElementById('P2017').value;
    var P2016 = document.getElementById('P2016').value;
    var P2015 = document.getElementById('P2015').value;
    var P2014 = document.getElementById('P2014').value;
    var P2013 = document.getElementById('P2013').value;
    var P2012 = document.getElementById('P2012').value;


    //CLASIFICACION DATA
    var Clas_Positiva = document.getElementById('positivaclas').value;
    var Clas_Mapfre = document.getElementById('mapfreclas').value;
    var Clas_Pacifico = document.getElementById('pacificoclas').value;
    var Clas_Rimac = document.getElementById('rimacclas').value;
    var Clas_HDI = document.getElementById('hdiclas').value;

    //GPS DATA
    var GPS_Positiva = document.getElementById('positivagps').value;
    var GPS_Mapfre = document.getElementById('mapfregps').value;
    var GPS_Pacifico = document.getElementById('pacificogps').value;
    var GPS_Rimac = document.getElementById('rimacgps').value;
    var GPS_HDI = document.getElementById('hdigps').value;

    //Desabilitar Boton de Guardado
    $("#btnSave").prop("disabled", true);
    var VehiuculoData = {
        idMarca: idMarca,
        Marca: Marca,
        idModelo: idModelo,
        Descripcion_Modelo: Descripcion_Modelo,
        Carroceria: Carroceria,
        Puertas: Puertas,
        Asientos: Asientos,
        Traccion: Traccion,
        Desplazamiento: Desplazamiento,
        Potencia: Potencia,
        Carburante: Carburante,
        VRN: VRN,
        Clasificacion_LaPositiva: Clas_Positiva,
        Clasificacion_Mapfre: Clas_Mapfre,
        Clasificacion_Pacifico: Clas_Pacifico,
        Clasificacion_Rimac: Clas_Rimac,
        Clasificacion_HDI: Clas_HDI,
        GPS_LaPositiva: GPS_Positiva,
        GPS_Mapfre: GPS_Mapfre,
        GPS_Pacifico: GPS_Pacifico,
        GPS_Rimac: GPS_Rimac,
        GPS_HDI: GPS_HDI,
        P2017: P2017,
        P2016: P2016,
        P2015: P2015,
        P2014: P2014,
        P2013: P2013,
        P2012: P2012,
        P2011: P2012,
        P2010: P2012
    };

    $.ajax({
        url: "../../vehicular/SaveNewVehiculo",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(VehiuculoData),
        success: function (response) {
            $.toast('Se Agregó la información del Nuevo Vehículo.', { 'duration': 3000, 'type': 'danger' });
        },

        error: function (result) {
            $.toast('La Sesion ha finalizado, vuelve a loguerte para guardar los cambios', { 'duration': 3000, 'type': 'danger' });
        }

    });

}
