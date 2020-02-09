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
    public class DACotizacionDetalle
    {
        public ENCotizacionDetalle GetCotizacionDetalle(SqlConnection con, int idCotizacion)
        {

            ENCotizacionDetalle obeCotizacionDetalle = new ENCotizacionDetalle();
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCotizacionDetalle", con);
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
                    if (!drd.IsDBNull(0)) { obeCotizacionDetalle.idCotizacion = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCotizacionDetalle.Prima_Rimac = drd.GetDecimal(1); };
                    if (!drd.IsDBNull(2)) { obeCotizacionDetalle.Prima_Pacifico = drd.GetDecimal(2); };
                    if (!drd.IsDBNull(3)) { obeCotizacionDetalle.Prima_Mafre = drd.GetDecimal(3); };
                    if (!drd.IsDBNull(4)) { obeCotizacionDetalle.Prima_LaPositiva = drd.GetDecimal(4); };
                    if (!drd.IsDBNull(5)) { obeCotizacionDetalle.Prima_HDI = drd.GetDecimal(5); };
                    //GPS
                    if (!drd.IsDBNull(6)) { obeCotizacionDetalle.GPS_Rimac = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeCotizacionDetalle.GPS_Pacifico = drd.GetString(7); };
                    if (!drd.IsDBNull(8)) { obeCotizacionDetalle.GPS_Mafre = drd.GetString(8); };
                    if (!drd.IsDBNull(9)) { obeCotizacionDetalle.GPS_LaPositiva = drd.GetString(9); };
                    if (!drd.IsDBNull(10)) { obeCotizacionDetalle.GPS_HDI = drd.GetString(10); };
                 

                }
                drd.Close();
            }
            return obeCotizacionDetalle;
        }
    }
}
