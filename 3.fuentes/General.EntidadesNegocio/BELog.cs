using System;
using System.Web;
namespace General.EntidadesNegocio
{
    public class BELog
    {

        public DateTime FechaHora { get; set; }
        public string MensajeError { get; set; }
        public string DetalleError { get; set; }
        public string Aplicación { get; set; }
        public string Usuario { get; set; }

        public BELog()
        {
            FechaHora = DateTime.Now;
            //Si es llamado por una App Web

            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["infoApp"] != null)
                {
                    BEInfoApp obeInfoApp = (BEInfoApp)HttpContext.Current.Session["InfoApp"];
                    Aplicación = obeInfoApp.Aplicacion;
                    Usuario = obeInfoApp.Usuario;
                }
            }

        }
    }
}
