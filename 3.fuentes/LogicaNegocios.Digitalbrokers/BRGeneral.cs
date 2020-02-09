using System;
using System.Configuration;
using General.EntidadesNegocio;
using General.Librerias.CodigoUsuario;


namespace LogicaNegocios.Digitalbrokers
{
    public class BRGeneral
    {
        public string CadenaConexion { get; set; }
        //CADENA DE CONEXION DE BD GESPO
        public string CadenaConexionGespo { get; set; }
        public string CadenaConexionBaan68 { get; set; }
        private string rutaLog;

        public BRGeneral()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["ConDigitalBrokers"].ConnectionString;
            //CadenaConexionGespo = ConfigurationManager.ConnectionStrings["conGespo"].ConnectionString;
            //CadenaConexionBaan68 = ConfigurationManager.ConnectionStrings["conBaan68"].ConnectionString;
            rutaLog = ConfigurationManager.AppSettings["rutaLog"];
        }

        public void GrabarLog(Exception ex)
        {
            BELog obeLog = new BELog();
            obeLog.MensajeError = ex.Message;
            obeLog.DetalleError = ex.StackTrace;
            string archivo = string.Format("{0}Logerror_{1}_2_{3}.txt", rutaLog, DateTime.Now.Year, DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Day.ToString().PadLeft(2, '0'));
            ucObjeto.Grabar(obeLog, archivo);
        }
    }
}
