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
    public class TasasController : Controller
    {
        // GET: Tasas
        public ActionResult Lista()
        {
            return View();
        }
        public ActionResult Editar(int? id)
        {
            ViewBag.idCorrelativo = id;
            return View();
        }

        public JsonResult GetTasasVehiculares(int idAseguradora, string Anio)
        {
            try
            {
                LNAseguradoraTasas olnTasas = new LNAseguradoraTasas();
                List<ENAseguradoraTasas> ListaTasas = olnTasas.GetTasasAseguradora_ByAseguradora(idAseguradora,Anio);
                return Json(ListaTasas, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult GetTasaVehicularByID(int idCorrelativo)
        {
            try
            {
                ENAseguradoraTasas oTasa = null;
                LNAseguradoraTasas olnTasa = new LNAseguradoraTasas();
                oTasa = olnTasa.GetTasabyidCorrelativo(idCorrelativo);
                return Json(oTasa, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult UPDTasaBYCorrelativo(int idCorrelativo, decimal Tasa)
        {
            try
            {
                int oTasa = 0;
                LNAseguradoraTasas olnTasa = new LNAseguradoraTasas();
                oTasa = olnTasa.UPD_TASA_ByCorrelativo_TRANS(idCorrelativo,Tasa);
                return Json(oTasa, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}