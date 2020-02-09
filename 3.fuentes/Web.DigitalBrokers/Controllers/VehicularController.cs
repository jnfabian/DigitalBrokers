using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;

namespace Web.DigitalBrokers.Controllers
{
    public class VehicularController : Controller
    {
        // GET: Vehicular
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gracias()
        {
            return View();
        }

        public JsonResult GetMarcasVehiculos()
        {
            try
            {
                LNMarcaVehiculo oLNMarcas= new LNMarcaVehiculo();
                List<ENMarcaVehiculo> lbeMarcas = oLNMarcas.GetMarcasVehiculo();
                return Json(lbeMarcas, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetModelosVehiculos(int idMarca,string idAnio)
        {
            try
            {
                LNVehiculoModelo olnModelos = new LNVehiculoModelo();
                List<ENVehiculoModelo> lbeModelos = olnModelos.GetModelosVehiculos(idMarca, idAnio);
                return Json(lbeModelos, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}