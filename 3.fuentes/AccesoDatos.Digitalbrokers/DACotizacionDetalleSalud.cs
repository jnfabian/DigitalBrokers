using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Entidades.Digitalbrokers;
using System.Data.Common;
namespace AccesoDatos.Digitalbrokers
{
    public class DACotizacionDetalleSalud
    {
        public ENCotizacionDetalleSalud GetCotizacionSaludDetalle(SqlConnection con, int idCotizacion)
        {

            ENCotizacionDetalleSalud obeCotizacionDetalle = new ENCotizacionDetalleSalud();
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCotizacionSaludDetalle", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@idCotizacion";
            param.Value = idCotizacion;
            cmd.Parameters.Add(param);



            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                while (drd.Read())
                {
                    if (!drd.IsDBNull(0)) { obeCotizacionDetalle.idCotizacionSalud = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCotizacionDetalle.Rimac = drd.GetDecimal(1); };
                    if (!drd.IsDBNull(2)) { obeCotizacionDetalle.Pacifico = drd.GetDecimal(2); };
                    if (!drd.IsDBNull(3)) { obeCotizacionDetalle.Mapfre = drd.GetDecimal(3); };

                }
                drd.Close();
            }
            return obeCotizacionDetalle;
        }
    }
}
