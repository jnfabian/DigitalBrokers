using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Digitalbrokers;
using Entidades.Digitalbrokers;
using System.Data.SqlClient;


namespace LogicaNegocios.Digitalbrokers
{
    public class LNSolicitudCotizacion: BRGeneral
    {
        public int SaveCotizacionCliente(ENSolicitudCotizacion oSolicitud)
        {

            DASolicitudCotizacion data = new DASolicitudCotizacion();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveCotizacionCliente(con, oSolicitud);
                }
                catch (Exception ex)
                {

                    GrabarLog(ex);
                }
            }

            return Resultado;

        }

        public int SaveSolicitudAtencionTelefonica(ENSolicitudComunicacion oSolicitud)
        {

            DASolicitudCotizacion data = new DASolicitudCotizacion();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveSolicitudAtencionTelefonica(con, oSolicitud);
                }
                catch (Exception ex)
                {

                    GrabarLog(ex);
                }
            }

            return Resultado;

        }
        
    }
}
