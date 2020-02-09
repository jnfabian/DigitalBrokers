$(document).ready(function () {
    getAseguradorasAll();
    getDeducibleDetalle();
    //getCoberturaTipoAll();
    $('#btnSave').click(saveDeducible);


});

function getAseguradorasAll() {

    $.ajax({
        type: 'GET',
        url: "../../cobertura/GetAseguradorasListaAll",
        contentType: JSON,
        processData: false,
        success: function (results) {
            $("#aseguradora").empty();
            $("#aseguradora").empty();
            $.each(results, function (i, Aseguradora) {
                $("#aseguradora").append("<option value='" + Aseguradora.idAseguradora + "'>" + Aseguradora.vchDescripcion + "</option>");
            });

        },
        error: function () {
            alert("La carga de Aseguradoras presentó un problema.");
        },
    });

}

function getDeducibleDetalle() {
    var idDeducible = document.getElementById('idDeducible').value;
    $.ajax({
        type: 'GET',
        url: "../../Deducible/getDeducible_ById?idDeducible=" + idDeducible,
        contentType: JSON,
        processData: false,
        success: function (resultado) {
          
            document.getElementById('id').innerHTML = resultado.idDeducible;
            document.getElementById('descripcion').value = resultado.Descripcion;
            document.getElementById('aseguradora').value = resultado.idAseguradora;
            document.getElementById('categoria').innerHTML = '<strong>' + resultado.Categoria + '</strong>';
            //categoria
          

        },
        error: function () {
            alert("Oh no! :(");
        },
    });

}

function saveDeducible() {
    var idDeducible = document.getElementById("idDeducible").value;
    var Descripcion = document.getElementById("descripcion").value;
    //Desabilitar Boton de Guardado
    $("#btnSave").prop("disabled", true);
    var DeducibleData = {
        idDeducible: idDeducible,
        Descripcion: Descripcion
  
    };

    $.ajax({
        url: "../../Deducible/SaveDeducible_ID",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(DeducibleData),
        success: function (response) {
            $.toast('Se actualizó la información deducible.', { 'duration': 3000, 'type': 'danger' });
        },

        error: function (result) {
            $.toast('La Sesion ha finalizado, vuelve a loguerte para guardar los cambios', { 'duration': 3000, 'type': 'danger' });
        }

    });
    
}
