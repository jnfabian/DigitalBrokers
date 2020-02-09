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
    public class ComprasController : Controller
    {
        // GET: Compras VIew
        public ActionResult Lista()
        {
            return View();
        }

        //GET COMPRAS LISTADO
        public JsonResult GetComprasCliente()
        {
            try
            {
                LNCompras oLNMCompras = new LNCompras();
                List<ENCompraDesc> lbeCompras = oLNMCompras.GetComprasClientes();
                return Json(lbeCompras, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}