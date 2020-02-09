$(document).ready(function () {
    getCotizacionCliente();
    getCotizacionClienteDetalle();


});

$(document).on("click", ".deducible", function () {
    var Compania = $(this).data('id');
    var Categoria = $(this).data('categoria');
   
    //$('#EdicionNumero').val(ActividadIdE);
    getDeduciblesCategoria(Compania,Categoria);

});


function getCotizacionCliente() {
    var idCotizacion = document.getElementById('son').value;
    $.ajax({
        type: 'GET',
        url: "../../../Cotizacion/GetCotizacionClienteCabecera?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            //Prueba Objeto
            console.log(resultado.idMarca);
            document.getElementById("0001").innerHTML = "Hola " + resultado.Mail_Cliente + ", aqui tienes tu cotización para tu vehículo "+ resultado.Descripcion_Modelo + " del Año  " + resultado.Anio;
            //document.getElementById("0002").innerHTML = "<strong>Sr(a):</strong>" + resultado.Mail_Cliente + ",<strong>Telf: </strong>" + resultado.TelefonoCliente;
            //Categoria de Vehiculo
            document.getElementById('scategoria').value = resultado.UsoVehiculo;


            //Botones de Accion
            document.getElementById("btndeducibleRimac").setAttribute("data-categoria", resultado.RIMAC_Categoria);
            document.getElementById("btndeduciblePacifico").setAttribute("data-categoria", resultado.PACIFICO_Categoria);
            document.getElementById("btndeducibleMapfre").setAttribute("data-categoria", resultado.MAPFRE_Categoria);
            document.getElementById("btndeducibleHDI").setAttribute("data-categoria", resultado.HDI_Categoria);
            document.getElementById("btndeduciblePositiva").setAttribute("data-categoria", resultado.POSITIVA_Categoria);
            
            
        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

function getCotizacionClienteDetalle() {
    var idCotizacion = document.getElementById('son').value;
    $.ajax({
        type: 'GET',
        url: "../../../Cotizacion/GetCotizacionClienteDetalle?idCotizacion=" + idCotizacion,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            //Prueba Objeto

            //Primas Resultado
            if (resultado.Prima_Rimac == 0 ? document.getElementById("prima_rimac").innerHTML = "Consultar Prima" : document.getElementById("prima_rimac").innerHTML = "USD$" + resultado.Prima_Rimac);
            if (resultado.Prima_Pacifico == 0 ? document.getElementById("prima_pacifico").innerHTML = "Consultar Prima" : document.getElementById("prima_pacifico").innerHTML = "USD$" + resultado.Prima_Pacifico);
            if (resultado.Prima_Mafre == 0 ? document.getElementById("prima_mafre").innerHTML = "Consultar Prima" : document.getElementById("prima_mafre").innerHTML = "USD$" + resultado.Prima_Mafre);
            if (resultado.Prima_LaPositiva == 0 ? document.getElementById("prima_LaPositiva").innerHTML = "Consultar Prima" : document.getElementById("prima_LaPositiva").innerHTML = "USD$" + resultado.Prima_LaPositiva);
            if (resultado.Prima_HDI == 0 ? document.getElementById("prima_HDI").innerHTML = "Consultar Prima" : document.getElementById("prima_HDI").innerHTML = "USD$" + resultado.Prima_HDI);

            //REQUIERE GPS
            document.getElementById("Rimac_GPS").innerHTML = "<strong>REQUIERE GPS:</strong> <i class='material-icons'>room</i>" + resultado.GPS_Rimac
            document.getElementById("Pacifico_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  <i class='material-icons'>room</i>" + resultado.GPS_Pacifico
            document.getElementById("Mafre_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  <i class='material-icons'>room</i>" + resultado.GPS_Mafre
            document.getElementById("HDI_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  <i class='material-icons'>room</i>" + resultado.GPS_HDI
            document.getElementById("LaPositiva_GPS").innerHTML = "<strong>REQUIERE GPS:</strong>  <i class='material-icons'>room</i>" + resultado.GPS_LaPositiva

            if (resultado.Prima_HDI == 0) { document.getElementById("btndeducibleHDI").hidden = true; }
            if (resultado.Prima_Rimac == 0) { document.getElementById("btndeducibleRimac").hidden = true; }
            if (resultado.Prima_Pacifico == 0) { document.getElementById("btndeduciblePacifico").hidden = true; }
            if (resultado.Prima_Mafre == 0) { document.getElementById("btndeducibleMapfre").hidden = true; }
            if (resultado.Prima_LaPositiva == 0) { document.getElementById("btndeduciblePositiva").hidden = true; }
            
            
            
            //document.getElementById("prima_rimac").innerHTML = "USD$" + resultado.Prima_Rimac
            //document.getElementById("prima_pacifico").innerHTML = "USD$" + resultado.Prima_Pacifico
            //document.getElementById("prima_mafre").innerHTML = "USD$" + resultado.Prima_Mafre
            //document.getElementById("prima_LaPositiva").innerHTML = "USD$" + resultado.Prima_LaPositiva
            //document.getElementById("prima_HDI").innerHTML = "USD$" + resultado.Prima_HDI

          
        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

function getDeduciblesCategoria(idAseguradora, Categoria) {
    $.ajax({
        type: 'GET',
        url: "../../../Deducible/GetDeduciblesCategoria?idAseguradora=" + idAseguradora + "&Categoria=" + Categoria,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
            //Aqui Pintar la tabla
            var row = "";
            var rowmapfre = "";
            $.each(resultado, function (index, item) {

                //row += "<tr>";
                //row += "<td></td>";
                //row += "<td class='mdl-data-table__cell--non-numeric'>" + item.Descripcion + "</td>";
                //row += "</tr>";
                //row += "<tr>";
                row += "<li>";
                row += item.Descripcion;
                row += "</li>";

            });


            $('#deduciblestbl').html(row);
            if (idAseguradora == 1) { document.getElementById('tituloDeducible').innerHTML = 'Deducibles para LA POSITIVA Seguros'; }
            if (idAseguradora == 2) { document.getElementById('tituloDeducible').innerHTML = 'Deducibles para RIMAC Seguros'; }
            if (idAseguradora == 4) { document.getElementById('tituloDeducible').innerHTML = 'Deducibles para PACIFICO Seguros'; }
            if (idAseguradora == 3) { document.getElementById('tituloDeducible').innerHTML = 'Deducibles para MAPFRE Seguros'; }
            if (idAseguradora == 5) { document.getElementById('tituloDeducible').innerHTML = 'Deducibles para HDI Seguros'; }



        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

