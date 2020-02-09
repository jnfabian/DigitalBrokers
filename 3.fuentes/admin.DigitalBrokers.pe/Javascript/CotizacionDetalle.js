$(document).ready(function () {
    getCotizacionCabecera();
    getCotizacionClienteDetalle();


});

function getCotizacionClienteDetalle() {
    var idCotizacion = document.getElementById('idCotizacion').value;
    $.ajax({
        type: 'GET',
        url: "../../Cotizacion/GetCotizacionClienteDetalle?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            //Prueba Objeto





            ////Primas Resultado
            //if (resultado.Prima_Rimac == 0 ? document.getElementById("prima_rimac").innerHTML = "Consultar Prima" : document.getElementById("prima_rimac").innerHTML = "USD$" + resultado.Prima_Rimac);
            //if (resultado.Prima_Pacifico == 0 ? document.getElementById("prima_pacifico").innerHTML = "Consultar Prima" : document.getElementById("prima_pacifico").innerHTML = "USD$" + resultado.Prima_Pacifico);
            //if (resultado.Prima_Mafre == 0 ? document.getElementById("prima_mafre").innerHTML = "Consultar Prima" : document.getElementById("prima_mafre").innerHTML = "USD$" + resultado.Prima_Mafre);
            //if (resultado.Prima_LaPositiva == 0 ? document.getElementById("prima_LaPositiva").innerHTML = "Consultar Prima" : document.getElementById("prima_LaPositiva").innerHTML = "USD$" + resultado.Prima_LaPositiva);
            //if (resultado.Prima_HDI == 0 ? document.getElementById("prima_HDI").innerHTML = "Consultar Prima" : document.getElementById("prima_HDI").innerHTML = "USD$" + resultado.Prima_HDI);

            ////REQUIERE GPS
            //document.getElementById("Rimac_GPS").innerHTML = "<strong>REQUIERE GPS:</strong> <i class='material-icons'>room</i>" + resultado.GPS_Rimac
            //document.getElementById("Pacifico_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  <i class='material-icons'>room</i>" + resultado.GPS_Pacifico
            //document.getElementById("Mafre_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  <i class='material-icons'>room</i>" + resultado.GPS_Mafre
            //document.getElementById("HDI_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  <i class='material-icons'>room</i>" + resultado.GPS_HDI
            //document.getElementById("LaPositiva_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  <i class='material-icons'>room</i>" + resultado.GPS_LaPositiva

            //if (resultado.Prima_HDI == 0) { document.getElementById("btndeducibleHDI").hidden = true; }
            //if (resultado.Prima_Rimac == 0) { document.getElementById("btndeducibleRimac").hidden = true; }
            //if (resultado.Prima_Pacifico == 0) { document.getElementById("btndeduciblePacifico").hidden = true; }
            //if (resultado.Prima_Mafre == 0) { document.getElementById("btndeducibleMapfre").hidden = true; }
            //if (resultado.Prima_LaPositiva == 0) { document.getElementById("btndeduciblePositiva").hidden = true; }

            //RIMAC
            if (resultado.Prima_Rimac == 0 ? document.getElementById("prima_rimac").innerHTML = "Consultar Prima" : document.getElementById("prima_rimac").innerHTML = "USD$" + resultado.Prima_Rimac);
            document.getElementById("Rimac_GPS").innerHTML = "<strong>REQUIERE GPS:</strong> " + resultado.GPS_Rimac
            if (resultado.Prima_Rimac == 0 ? document.getElementById("tdRIMAC").innerHTML = "Consultar Prima" : document.getElementById("tdRIMAC").innerHTML = "USD$" + resultado.Prima_Rimac);
            document.getElementById("TDGPS_RIMAC").innerHTML = "<strong>REQUIERE GPS:</strong> " + resultado.GPS_Rimac
            

            //PACIFICO
            if (resultado.Prima_Pacifico == 0 ? document.getElementById("prima_pacifico").innerHTML = "Consultar Prima" : document.getElementById("prima_pacifico").innerHTML = "USD$" + resultado.Prima_Pacifico);
            document.getElementById("Pacifico_GPS").innerHTML = "<strong>REQUIERE GPS:</strong> " + resultado.GPS_Pacifico
            if (resultado.Prima_Pacifico == 0 ? document.getElementById("tdPACIFICO").innerHTML = "Consultar Prima" : document.getElementById("tdPACIFICO").innerHTML = "USD$" + resultado.Prima_Pacifico);
            document.getElementById("TDGPS_PACIFICO").innerHTML = "<strong>REQUIERE GPS:</strong> " + resultado.GPS_Pacifico
            

            //MAPFRE
            if (resultado.Prima_Mafre == 0 ? document.getElementById("prima_mafre").innerHTML = "Consultar Prima" : document.getElementById("prima_mafre").innerHTML = "USD$" + resultado.Prima_Mafre);
            document.getElementById("Mafre_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  " + resultado.GPS_Mafre;
            if (resultado.Prima_Mafre == 0 ? document.getElementById("tdMAPFRE").innerHTML = "Consultar Prima" : document.getElementById("tdMAPFRE").innerHTML = "USD$" + resultado.Prima_Mafre);
            document.getElementById("TDGPS_MAPFRE").innerHTML = "<strong>REQUIERE GPS:</strong>  " + resultado.GPS_Mafre;
            

            //LA POSITIVA
            if (resultado.Prima_LaPositiva == 0 ? document.getElementById("prima_LaPositiva").innerHTML = "Consultar Prima" : document.getElementById("prima_LaPositiva").innerHTML = "USD$" + resultado.Prima_LaPositiva);
            document.getElementById("LaPositiva_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  " + resultado.GPS_LaPositiva;
            if (resultado.Prima_LaPositiva == 0 ? document.getElementById("tdLAPOSITIVA").innerHTML = "Consultar Prima" : document.getElementById("tdLAPOSITIVA").innerHTML = "USD$" + resultado.Prima_LaPositiva);
            document.getElementById("TDGPS_LAPOSITIVA").innerHTML = "<strong>REQUIERE GPS:</strong>  " + resultado.GPS_LaPositiva;
            
            

            //HDI
            if (resultado.Prima_HDI == 0 ? document.getElementById("prima_HDI").innerHTML = "Consultar Prima" : document.getElementById("prima_HDI").innerHTML = "USD$" + resultado.Prima_HDI);
            document.getElementById("HDI_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  " + resultado.GPS_HDI;
            if (resultado.Prima_HDI == 0 ? document.getElementById("tdHDI").innerHTML = "NO CALIFICA" : document.getElementById("tdHDI").innerHTML = "USD$" + resultado.Prima_HDI);
            document.getElementById("TDGPS_HDI").innerHTML = "<strong>REQUIERE GPS:</strong>  " + resultado.GPS_HDI;
            
            
        },
        error: function () {
            alert("Se produjo un error obteniendo el detalle de la cotización.");
        },
    });

}


function getCotizacionCabecera() {
    var idCotizacion = document.getElementById('idCotizacion').value;
    $.ajax({
        type: 'GET',
        url: "../../Cotizacion/GetCotizacionClienteCabecera?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            //Prueba Objeto
            console.log(resultado.idMarca);
            //document.getElementById("0001").innerHTML = "Hola " + resultado.Mail_Cliente + ", aqui tienes tu cotización para tu vehículo " + resultado.Descripcion_Modelo + " del Año  " + resultado.Anio;
            ////document.getElementById("0002").innerHTML = "<strong>Sr(a):</strong>" + resultado.Mail_Cliente + ",<strong>Telf: </strong>" + resultado.TelefonoCliente;
            ////Categoria de Vehiculo
            //document.getElementById('scategoria').value = resultado.UsoVehiculo;


            ////Botones de Accion
            //document.getElementById("btndeducibleRimac").setAttribute("data-categoria", resultado.RIMAC_Categoria);
            //document.getElementById("btndeduciblePacifico").setAttribute("data-categoria", resultado.PACIFICO_Categoria);
            //document.getElementById("btndeducibleMapfre").setAttribute("data-categoria", resultado.MAPFRE_Categoria);
            //document.getElementById("btndeducibleHDI").setAttribute("data-categoria", resultado.HDI_Categoria);
            //document.getElementById("btndeduciblePositiva").setAttribute("data-categoria", resultado.POSITIVA_Categoria);

            document.getElementById("idCotizacions").innerHTML = "Detalle de la Cotización Nro:" + resultado.idCotizacion + ", vehículo " + resultado.Descripcion_Modelo;
            document.getElementById("descModelo").innerHTML = resultado.Descripcion_Modelo;
            document.getElementById("Anio").innerHTML = resultado.Anio;
            document.getElementById("cliente").innerHTML = resultado.Mail_Cliente;
            document.getElementById("valorref").innerHTML = "USD$" + resultado.ValorReferencial;
            
            //CATEGORIAS
            document.getElementById("catRIMAC").innerHTML = "<strong> " + resultado.RIMAC_Categoria + "</strong>";
            document.getElementById("catPACIFICO").innerHTML = "<strong> " + resultado.PACIFICO_Categoria + "</strong>";
            document.getElementById("catMAPFRE").innerHTML = "<strong> " + resultado.MAPFRE_Categoria + "</strong>";
            document.getElementById("catLAPOSITIVA").innerHTML = "<strong> " + resultado.POSITIVA_Categoria + "</strong>";
            document.getElementById("catHDI").innerHTML = "<strong> " + resultado.HDI_Categoria + "</strong>";

        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}
