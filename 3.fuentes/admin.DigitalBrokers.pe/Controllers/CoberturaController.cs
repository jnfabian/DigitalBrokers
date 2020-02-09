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
    public class CoberturaController : Controller
    {
        // GET: Cobertura
        public ActionResult Lista()
        {
            return View();
        }
        public ActionResult Editar(int? id)
        {
            ViewBag.idCobertura = id;
            return View();
        }
        //Obtener Cobertura por ID
        public JsonResult getCobertura_xID(int idCobertura)
        {
            try
            {
                ENCobertura oCobertura = null;
                LNCobertura olnCobertura = new LNCobertura();
                oCobertura = olnCobertura.getCobertura_ByID(idCobertura);
                return Json(oCobertura, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Obtener Lista de Aseguradoras
        public JsonResult GetAseguradorasListaAll()
        {
            try
            {
                LNAseguradora oLNAseguradoras = new LNAseguradora();
                List<ENAseguradora> lbeAseguradoras = oLNAseguradoras.GetAseguradorasLista();
                return Json(lbeAseguradoras, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Obtener Lista de Tipos de Cobertura
        public JsonResult GetCoberturaTipoListaAll()
        {
            try
            {
                LNCoberturaTipo oLNCobeTipo = new LNCoberturaTipo();
                List<ENCoberturaTipo> lbeCobTipo = oLNCobeTipo.GetCoberturaTipoLista();
                return Json(lbeCobTipo, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //OBtener Coberturas Filtrado GetCobTipobyAseguradoraTipoCob
        public JsonResult GetCobTipobyAseguradoraTipoCobertura(int idAseguradora, int idCoberturaTipo)
        {
            try
            {
                LNCobertura oLNCobertura = new LNCobertura();
                List<ENCobertura> lbeCoberturas = oLNCobertura.GetCobTipobyAseguradoraTipoCob(idAseguradora, idCoberturaTipo);
                return Json(lbeCoberturas, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
        //SaveCobertura_TRANS
        public JsonResult SaveCobertura_ID(ENCobertura oCobertura)
        {

            try
            {
                int intRes = 0;
                //GUARDAR DEDUCIBLE
                LNCobertura oLNCobertura = new LNCobertura();
                intRes = oLNCobertura.SaveCobertura_TRANS(oCobertura);

                if (intRes > 0) return Json(new { intCobertura = intRes });
                else return Json(new { success = false });

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}