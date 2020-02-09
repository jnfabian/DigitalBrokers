using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;

namespace Web.DigitalBrokers.Controllers
{
    public class CoberturaController : Controller
    {
        // GET: Cobertura
        public JsonResult GetCoberturasAseguradoras(int idCotizacion)
        {
            try
            {
                int tipoCobertura = 1;
                //Verificar Cobertura Tipo de la Cotizacion
                ENCotizacion oCotizacion = null;
                LNCotizacion olnCotizacion = new LNCotizacion();
                oCotizacion = olnCotizacion.GetCotizacionCabecera(idCotizacion);

                if (oCotizacion.UsoVehiculo == "PARTICULAR")
                {
                    tipoCobertura = 1;
                }

                if (oCotizacion.UsoVehiculo == "CHINOS")
                {
                    tipoCobertura = 2;
                }

                LNCobertura olnCoberturas = new LNCobertura();
                List<ENCobertura> lbeCobertura = olnCoberturas.GetCoberturaTipoAseguradora(tipoCobertura,0);
                return Json(lbeCobertura, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult GetCoberturasSalud()
        {
            try
            {
                LNCoberturaSalud olnCoberturas = new LNCoberturaSalud();
                List<ENCoberturaSalud> lbeCobertura = olnCoberturas.GetCoberturasSalud();
                return Json(lbeCobertura, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}