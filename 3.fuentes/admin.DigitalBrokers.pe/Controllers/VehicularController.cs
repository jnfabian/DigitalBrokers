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
    public class VehicularController : Controller
    {
        // GET: Vehicular
        public ActionResult Lista()
        {
            return View();
        }
        public ActionResult Agregar() 
        {
            return View();
        
        }
        public ActionResult Editar(int idMarca, int idModelo, int Anio)
        {
            ViewBag.idMarca = idMarca;
            ViewBag.idModelo = idModelo;
            ViewBag.Anio = Anio;

            return View();
        }


        public JsonResult GetMarcasVehiculos()
        {
            try
            {
                LNMarcaVehiculo oLNMarcas = new LNMarcaVehiculo();
                List<ENMarcaVehiculo> lbeMarcas = oLNMarcas.GetMarcasVehiculo();
                return Json(lbeMarcas, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetVehiculosPorMarcaAnio(int idMarca, int Anio)
        {
            try
            {
                LNVehiculo oLNVehiculos = new LNVehiculo();
                List<ENVehiculo> lbeVehiculos = oLNVehiculos.GetvehiculosListadoMarca(idMarca,Anio);
                return Json(lbeVehiculos, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetVehiculo(int idMarca, int idModelo, int Anio)
        {
            try
            {
                ENVehiculoCompleto ovehiculo = null;
                LNVehiculo olnVehiculo= new LNVehiculo();
                ovehiculo = olnVehiculo.GetVehiculo(idMarca,idModelo,Anio);
                return Json(ovehiculo, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Actualizacion de Vehiculos
        public JsonResult SaveVehiculo(ENVehiculoCompleto oVehiculo)
        {

            try
            {
                int intRes = 0;
                //GUARDAR VEHICULO
                LNVehiculo olnVehiculo = new LNVehiculo();
                intRes = olnVehiculo.SaveVehiculo_TRANS(oVehiculo);

                if (intRes > 0) return Json(new { intVehiculo = intRes });
                else return Json(new { success = false });

            }
            catch (Exception)
            {

                throw;
            }

        }

        //New Vehicle

        public JsonResult SaveNewVehiculo(ENVehiculoCompleto oVehiculo)
        {

            try
            {
                int intRes = 0;
                //GUARDAR VEHICULO
                LNVehiculo olnVehiculo = new LNVehiculo();
                intRes = olnVehiculo.SaveNewVehiculo_TRANS(oVehiculo);

                if (intRes > 0) return Json(new { intVehiculo = intRes });
                else return Json(new { success = false });

            }
            catch (Exception)
            {

                throw;
            }

        }

    }


}