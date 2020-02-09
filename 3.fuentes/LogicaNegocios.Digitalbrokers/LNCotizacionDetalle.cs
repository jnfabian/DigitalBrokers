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
    public class LNCotizacionDetalle:BRGeneral
    {
        //GetCotizacionDetalle
        public ENCotizacionDetalle GetCotizacionDetalle(int idCotizacion)
        {
            ENCotizacionDetalle beCotizacionDetalle = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACotizacionDetalle odaCotizacionDetalle = new DACotizacionDetalle();
                    beCotizacionDetalle = odaCotizacionDetalle.GetCotizacionDetalle(con, idCotizacion);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }

                return beCotizacionDetalle;
            }
        }
    }
}
