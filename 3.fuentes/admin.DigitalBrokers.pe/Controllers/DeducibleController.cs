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
    public class DeducibleController : Controller
    {
        // GET: Deducible
        public ActionResult Lista()
        {
            return View();
        }
        public ActionResult Editar(int? id)
        {
            ViewBag.idDeducible = id;
            return View();
        }
        //Obtener Deduciles Listado Filtrado
        public JsonResult GetDeduciblesListaAll(int idAseguradora)
        {
            try
            {
                string Tipo = "PARTICULAR";
                LNDeducibles oLNDeducibles = new LNDeducibles();
                List<ENDeducibles> lbeDeducibles = oLNDeducibles.GetDeduciblesCompania_xAseguradora(idAseguradora);
                return Json(lbeDeducibles, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public JsonResult getDeducible_ById(int idDeducible)
        {
            try
            {
                ENDeducibles oDeducible = null;
                LNDeducibles olnDeducible = new LNDeducibles();
                oDeducible = olnDeducible.getDeducible_ByID(idDeducible);
                return Json(oDeducible, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Actualizacion de Deducibles por IDDeducible
        public JsonResult SaveDeducible_ID(ENDeducibles oDeducible)
        {

            try
            {
                int intRes = 0;
                //GUARDAR DEDUCIBLE
                LNDeducibles oLNDeducible = new LNDeducibles();
                intRes = oLNDeducible.SaveDeducible_TRANS(oDeducible.idDeducible, oDeducible.Descripcion);

                if (intRes > 0) return Json(new { intDeducible = intRes });
                else return Json(new { success = false });

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}