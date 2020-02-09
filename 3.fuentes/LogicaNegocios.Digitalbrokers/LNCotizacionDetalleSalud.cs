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
    public class LNCotizacionDetalleSalud:BRGeneral
    {
        public ENCotizacionDetalleSalud GetCotizacionSaludDetalle(int idCotizacion)
        {
            ENCotizacionDetalleSalud beCotizacionDetalle = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACotizacionDetalleSalud odaCotizacionDetalle = new DACotizacionDetalleSalud();
                    beCotizacionDetalle = odaCotizacionDetalle.GetCotizacionSaludDetalle(con, idCotizacion);
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
