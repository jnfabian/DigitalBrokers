using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;
using admin.DigitalBrokers.pe.Security;


namespace admin.DigitalBrokers.pe.Controllers
{
    [SegurutyBase]
    public class PlataformaController : Controller
    {
        // GET: Plataforma
        public ActionResult home()
        {
            return View();
        }
        public ActionResult Out()
        {
            Session["CodigoUsuario"] = null;
            Session["emailUsuario"] = null;
            Session["UsuarioNombres"] = null;
            
            Session.Abandon();
            return RedirectToAction("Login", "Usuario");
        }
        public JsonResult GetCotizacionesDashboard()
        {
            try
            {
                LNCotizacion olnCoti = new LNCotizacion();
                List<ENCotizacion> lbeCotizacion = olnCoti.GetCotizacionesDashboard();
                return Json(lbeCotizacion, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetCotizacionesDashboardFiltro(string FechaInicio, string FechaFin)
        {
            try
            {
                LNCotizacion olnCoti = new LNCotizacion();
                List<ENCotizacion> lbeCotizacion = olnCoti.GetCotizacionesDashboardFiltro(FechaInicio,FechaFin);
                return Json(lbeCotizacion, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult GetCotizacionesSaludDashboard()
        {
            try
            {
                LNCotizacionSalud olnCoti = new LNCotizacionSalud();
                List<ENCotizacionSalud> lbeCotizacion = olnCoti.GetCotizacionesSaludDashboard();
                return Json(lbeCotizacion, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult GetCotizacionesSaludDashboardFiltro(string FechaInicio, string FechaFin)
        {
            try
            {
                LNCotizacionSalud olnCoti = new LNCotizacionSalud();
                List<ENCotizacionSalud> lbeCotizacion = olnCoti.GetCotizacionesSaludDashboardFiltro(FechaInicio,FechaFin);
                return Json(lbeCotizacion, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}