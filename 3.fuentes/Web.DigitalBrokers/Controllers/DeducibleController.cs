using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;

namespace Web.DigitalBrokers.Controllers
{
    public class DeducibleController : Controller
    {
        // GET: Deducible
        //public JsonResult GetDeduciblesCategoria(int idAseguradora, string Categoria)
        //{
        //    try
        //    {
        //        //Verificar Categoria de Deducible
        //        //ENCotizacion oCotizacion = null;
        //        //LNCotizacion olnCotizacion = new LNCotizacion();
        //        //oCotizacion = olnCotizacion.GetCotizacionCabecera(idCotizacion);

        //        //string RIMAC = oCotizacion.RIMAC_Categoria;
        //        //string POSITIVA = oCotizacion.POSITIVA_Categoria;
        //        //string PACIFICO = oCotizacion.PACIFICO_Categoria;
        //        //string MAPFRE = oCotizacion.MAPFRE_Categoria;
        //        //string HDI = oCotizacion.HDI_Categoria;


        //        //LNDeducibles olnDeducible = new LNDeducibles();
        //        //List<ENDeducibles> lbeDeducible = olnDeducible.GetDeduciblesCategoria(RIMAC,MAPFRE,PACIFICO,POSITIVA,HDI);
        //        return Json(lbeDeducible, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public JsonResult GetDeduciblesCategoria(int idAseguradora, string Categoria)
        {
            try
            {
               
                //Traer los Deducibles por Compañia
                LNDeducibles olnDeducible = new LNDeducibles();
                List<ENDeducibles> lbeDeducible = olnDeducible.GetDeduciblesCompaniaAseguradora(idAseguradora, Categoria);
                return Json(lbeDeducible, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}