using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;

namespace admin.DigitalBrokers.pe.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Login()
        {
            return View();
        }

        public string GetSessionUserPlatform(string usuario, string clave)
        {
            string rpta = "";
            LNUsuario obrUsuario = new LNUsuario();
            ENUsuario obeUsuarioExiste = obrUsuario.GetUsuarioLoginEmail(usuario,clave);
            if (obeUsuarioExiste.idUsuario == 0) { return "Usuario no existe"; }

            ENUsuario obeUsuario = obrUsuario.GetUsuarioLoginEmail(usuario, clave);
            if (obeUsuario.idUsuario != 0)
            {

                    
                    string Usuario = obeUsuario.vchNombres;
                    Session["CodigoUsuario"] = obeUsuario.idUsuario;
                    Session["emailUsuario"] = obeUsuario.vchEmail;
                    Session["UsuarioNombres"] = Usuario;
                    rpta = "Bienvenido " + Usuario;
                
                
            }
            else rpta = "Password incorrecto. Intenta de nuevo";
            return rpta;
        }

    }
}