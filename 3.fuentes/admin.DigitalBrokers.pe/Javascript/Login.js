

function validarCampo(Tex, Mensaje) {
    var Texto = document.getElementById(Tex);
    if (Texto != null) {
        if (Texto.value.replace(/^\s+|\s+$/g, "").length == 0) {
            alert('¡¡¡ Favor de Ingresar ' + Mensaje);
            Texto.focus();
            return false;
        }
        if (Texto.value.match(/([\<])([^\>]{1,})*([\>])/i) != null) {
            alert(Mensaje + ' No debe contener etiquetas html: <etiqueta>');
            Texto.select();
            Texto.focus();
            return false;
        }
        if (Texto.value.match(/[,;]+/) != null) {
            alert(Mensaje + ' No debe contener , o ;');
            Texto.select();
            Texto.focus();
            return false;
        }
    }
    return true;
}

function iniciarLogin() {
    window.onload = function () {
        var btnAceptar = document.getElementById("btnAceptar");
        btnAceptar.value = 'Acceso';
    
        btnAceptar.onclick = function () {
            document.getElementById('Logueo').innerHTML = 'Procesando <img src="../images/loading.gif" alt="Cargando" />';
            if (validarCampo("txtUsuario", "Usuario") == false) return false;
            if (validarCampo("txtClave", "Clave") == false) return false;
            var txtUsuario = document.getElementById("txtUsuario");
            var txtClave = document.getElementById("txtClave");
            //MD5 PARA PASSWORD
            txtClave.value = CryptoJS.MD5(txtClave.value);
            var url = "../Usuario/GetSessionUserPlatform/?usuario=" + txtUsuario.value + "&clave=" + txtClave.value;
            var xhr = new XMLHttpRequest();
            xhr.open("get", url, true);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var rpta = xhr.responseText;
                    document.getElementById('resultado').innerHTML = rpta;
                    btnAceptar.value = 'Ingresar';
                    if (rpta.substring(0, 10) == "Bienvenido") {
                        url = "../Plataforma/home";
                        window.location = url;
                    }
                    else {
                        document.getElementById('Logueo').innerHTML = '';
                    }
                }
            }
            xhr.send();
        }
    }
}



