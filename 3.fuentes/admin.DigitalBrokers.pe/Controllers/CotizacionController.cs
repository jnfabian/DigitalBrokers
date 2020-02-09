using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;
using admin.DigitalBrokers.pe.Security;
using System.Text;

namespace admin.DigitalBrokers.pe.Controllers
{
    [SegurutyBase]
    public class CotizacionController : Controller
    {
        // GET: Cotizacion
        public ActionResult Detalle(int id)
        {
            ViewBag.idCotizacion = id;
            return View();
        }

        public ActionResult DetalleSalud(int id)
        {
            ViewBag.idCotizacionSalud = id;
            return View();
        }
        //VEHICULAR COTIZACION
        public JsonResult GetCotizacionClienteDetalle(int idCotizacion)
        {
            try
            {
                ENCotizacionDetalle oCotizacionDetalle = null;
                LNCotizacionDetalle olnCotizacionDetalle = new LNCotizacionDetalle();
                oCotizacionDetalle = olnCotizacionDetalle.GetCotizacionDetalle(idCotizacion);
                return Json(oCotizacionDetalle, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetCotizacionClienteCabecera(int idCotizacion)
        {
            try
            {
                ENCotizacion oCotizacion = null;
                LNCotizacion olnCotizacion = new LNCotizacion();
                oCotizacion = olnCotizacion.GetCotizacionCabecera(idCotizacion);
                return Json(oCotizacion, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }


        //SALUD COTIZACION
        public JsonResult GetCotizacionSaludcabecera(int idCotizacion)
        {
            try
            {
                ENCotizacionSalud oCotizacion = null;
                LNCotizacionSalud olnCotizacion = new LNCotizacionSalud();
                oCotizacion = olnCotizacion.GetCotizacionSaludCabecera(idCotizacion);
                return Json(oCotizacion, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetCotizacionSaludDetalle(int idCotizacion)
        {
            try
            {
                ENCotizacionDetalleSalud oCotizacionDetalle = null;
                LNCotizacionDetalleSalud olnCotizacionDetalle = new LNCotizacionDetalleSalud();
                oCotizacionDetalle = olnCotizacionDetalle.GetCotizacionSaludDetalle(idCotizacion);
                return Json(oCotizacionDetalle, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //DOWNLOADS
        public FileResult DownloadPDFVehicular(string id)
        {

            //DESCARGAR LOS BENEFICIOS DE ACUERDO AL TIPO DE COTIZACION
            try
            {
                string idCotizacion = id;

                byte[] fileBytes = System.IO.File.ReadAllBytes(@"G:/PleskVhosts/digitalbrokers.pe/app.digitalbrokers.pe/Cotizaciones/PDF/COT-" + idCotizacion + ".pdf");
                string fileName = "COT-" + RandomString(12, false) + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            }
            catch (Exception ex)
            {

                byte[] fileBytes = System.IO.File.ReadAllBytes(@"G:/PleskVhosts/digitalbrokers.pe/documentos/PDFNoexiste.pdf");
                string fileName = "COT-" + RandomString(12, false) + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            finally
            {
                RedirectToAction("Plataforma", "home");
            }
          

        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToUpper();
            return builder.ToString().ToUpper();
        }
    }
}