using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;
using General.Librerias.CodigoUsuario;

namespace Web.DigitalBrokers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult CommingSoon()
        {
            return View();
        }
        public ActionResult PreguntasFrecuentes()
        {
            return View();
        }

        //public FileResult Download()
        //{
        //    //PRUEBAS DE ESCRITURA DE COTIZACION EN PDF
        //    int idCotizacion = 4101;

        //    LNCotizacion LNCotizacion = new LNCotizacion();
        //    LNCotizacion.GenerarCotizacionPDF(idCotizacion);

        //    //Produccion G:/PleskVhosts/digitalbrokers.pe/documentos/VEHICULAR-SLIP.PDF
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(@"G:/PleskVhosts/digitalbrokers.pe/documentos/VEHICULAR-SLIP.PDF");
        //    string fileName = "DigitalBrokers-Deducibles.pdf";
        //    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //}
    }
}