$(document).ready(function () {
    getVehiculoDetalle();
    //saveVehicular
    $('#btnSave').click(saveVehicular);
    
});

function getVehiculoDetalle() {
    var idMarca = document.getElementById('idMarca').value;
    var idModelo = document.getElementById('idModelo').value;
    var Anio = document.getElementById('Anio').value;

    var ruta = "../Vehicular/GetVehiculo?idMarca=" + idMarca + "&idModelo=" + idModelo + "&Anio=" + Anio;
    $.ajax({
        type: 'GET',
        url: ruta,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            
            document.getElementById('Marca').innerHTML = resultado.Marca;
            document.getElementById('Modelo').value = resultado.Descripcion_Modelo;

            document.getElementById('carroceria').value = resultado.Carroceria;
            document.getElementById('puertas').value = resultado.Puertas;
            document.getElementById('asientos').value = resultado.Asientos;
            document.getElementById('traccion').value = resultado.Traccion;
            document.getElementById('desplazamiento').value = resultado.Desplazamiento;
            document.getElementById('potencia').value = resultado.Potencia;
            document.getElementById('carburante').value = resultado.Carburante;
            document.getElementById('VRN').value = resultado.VRN;
            document.getElementById('precio').value = resultado.PrecioAnio;

            //CLASIFICACION
            document.getElementById('claslapositiva').value = resultado.Clasificacion_LaPositiva;
            document.getElementById('clasmapfre').value = resultado.Clasificacion_Mapfre;
            document.getElementById('claspacifico').value = resultado.Clasificacion_Pacifico;
            document.getElementById('clasrimac').value = resultado.Clasificacion_Rimac;
            document.getElementById('clasHDI').value = resultado.Clasificacion_HDI;

            //GPS
            document.getElementById('gpslapositiva').value = resultado.GPS_LaPositiva;
            document.getElementById('gpsmapfre').value = resultado.GPS_Mapfre;
            document.getElementById('gpspacifico').value = resultado.GPS_Pacifico;
            document.getElementById('gpsrimac').value = resultado.GPS_Rimac;
            document.getElementById('gpsHDI').value = resultado.GPS_HDI;



        },
        error: function () {
            alert("No se logró cargar el vehiculo :(");
        },
    });

}

function saveVehicular() {

    var idMarca = document.getElementById('idMarca').value;
    var idModelo = document.getElementById('idModelo').value;
    var Descripcion_Modelo = document.getElementById('Modelo').value;
    var Carroceria = document.getElementById('carroceria').value;
    var Puertas = document.getElementById('puertas').value;
    var Asientos = document.getElementById('asientos').value;
    var Traccion = document.getElementById('traccion').value;
    var Desplazamiento = document.getElementById('desplazamiento').value;
    var Potencia = document.getElementById('potencia').value;
    var Carburante = document.getElementById('carburante').value;
    var VRN =document.getElementById('VRN').value;
    var PrecioAnio = document.getElementById('precio').value;
    var Anio = document.getElementById('Anio').value;

    //CLASIFICACION DATA
    var Clas_Positiva = document.getElementById('claslapositiva').value;
    var Clas_Mapfre = document.getElementById('clasmapfre').value;
    var Clas_Pacifico = document.getElementById('claspacifico').value;
    var Clas_Rimac = document.getElementById('clasrimac').value;
    var Clas_HDI = document.getElementById('clasHDI').value;

    //GPS DATA
    var GPS_Positiva = document.getElementById('gpslapositiva').value;
    var GPS_Mapfre = document.getElementById('gpsmapfre').value;
    var GPS_Pacifico = document.getElementById('gpspacifico').value;
    var GPS_Rimac = document.getElementById('gpsrimac').value;
    var GPS_HDI = document.getElementById('gpsHDI').value;

    //Desabilitar Boton de Guardado
    $("#btnSave").prop("disabled", true);
    var VehiuculoData = {
        idMarca: idMarca,
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
        PrecioAnio: PrecioAnio,
        Anio: Anio,
        Clasificacion_LaPositiva: Clas_Positiva,
        Clasificacion_Mapfre: Clas_Mapfre,
        Clasificacion_Pacifico: Clas_Pacifico,
        Clasificacion_Rimac: Clas_Rimac,
        Clasificacion_HDI: Clas_HDI,
        GPS_LaPositiva: GPS_Positiva,
        GPS_Mapfre: GPS_Mapfre,
        GPS_Pacifico: GPS_Pacifico,
        GPS_Rimac: GPS_Rimac,
        GPS_HDI: GPS_HDI
    };

    $.ajax({
        url: "../../vehicular/SaveVehiculo",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(VehiuculoData),
        success: function (response) {
            $.toast('Se actualizó la información del Vehículo.', { 'duration': 3000, 'type': 'danger' });
        },

        error: function (result) {
            $.toast('La Sesion ha finalizado, vuelve a loguerte para guardar los cambios', { 'duration': 3000, 'type': 'danger' });
        }

    });

}