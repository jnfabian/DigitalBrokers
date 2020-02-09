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
    public class DACotizacion
    {
        public ENCotizacion GetCotizacionCabecera(SqlConnection con, int idCotizacion)
        {

            ENCotizacion obeCotizacion = new ENCotizacion();
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCotizacioncabecera", con);
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
                    if (!drd.IsDBNull(0)) { obeCotizacion.idCotizacion = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCotizacion.idMarca = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeCotizacion.idModelo = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeCotizacion.Anio = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeCotizacion.ValorReferencial = drd.GetDecimal(4); };
                    if (!drd.IsDBNull(5)) { obeCotizacion.UsoVehiculo = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCotizacion.Descripcion_Modelo = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeCotizacion.Mail_Cliente = drd.GetString(7); };
                    if (!drd.IsDBNull(8)) { obeCotizacion.TelefonoCliente = drd.GetString(8); };
                    if (!drd.IsDBNull(9)) { obeCotizacion.RIMAC_Categoria = drd.GetString(9); };
                    if (!drd.IsDBNull(10)) { obeCotizacion.POSITIVA_Categoria = drd.GetString(10); };
                    if (!drd.IsDBNull(11)) { obeCotizacion.PACIFICO_Categoria = drd.GetString(11); };
                    if (!drd.IsDBNull(12)) { obeCotizacion.MAPFRE_Categoria = drd.GetString(12); };
                    if (!drd.IsDBNull(13)) { obeCotizacion.HDI_Categoria = drd.GetString(13); };


                }
                drd.Close();
            }
            return obeCotizacion;
        }

        //Admin
        public List<ENCotizacion> GetCotizacionesDashboard(SqlConnection con)
        {
            List<ENCotizacion> lbeCotizaciones = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCotizacionesAll", con);
            cmd.CommandType = CommandType.StoredProcedure;



            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeCotizaciones = new List<ENCotizacion>();
                ENCotizacion obeCotizacion;
                while (drd.Read())
                {
                    obeCotizacion = new ENCotizacion();
                    if (!drd.IsDBNull(0)) { obeCotizacion.idCotizacion = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCotizacion.idMarca = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeCotizacion.idModelo = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeCotizacion.Anio = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeCotizacion.ValorReferencial = drd.GetDecimal(4); };
                    if (!drd.IsDBNull(5)) { obeCotizacion.UsoVehiculo = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCotizacion.Descripcion_Modelo = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeCotizacion.Mail_Cliente = drd.GetString(7); };
                    if (!drd.IsDBNull(8)) { obeCotizacion.TelefonoCliente = drd.GetString(8); };
                    if (!drd.IsDBNull(9)) { obeCotizacion.RIMAC_Categoria = drd.GetString(9); };
                    if (!drd.IsDBNull(10)) { obeCotizacion.POSITIVA_Categoria = drd.GetString(10); };
                    if (!drd.IsDBNull(11)) { obeCotizacion.PACIFICO_Categoria = drd.GetString(11); };
                    if (!drd.IsDBNull(12)) { obeCotizacion.MAPFRE_Categoria = drd.GetString(12); };
                    if (!drd.IsDBNull(13)) { obeCotizacion.HDI_Categoria = drd.GetString(13); };
                    if (!drd.IsDBNull(14)) { obeCotizacion.FechaCreacion = drd.GetDateTime(14); };
                    lbeCotizaciones.Add(obeCotizacion);
                }
                drd.Close();
            }
            return lbeCotizaciones;
        }

        public List<ENCotizacion> GetCotizacionesDashboardFiltro(SqlConnection con, string FechaInicio, string FechaFin)
        {
            List<ENCotizacion> lbeCotizaciones = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_Admin_GETCotizacionesFiltro", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.String;
            param.ParameterName = "@FechaInicio";
            param.Value = FechaInicio;
            cmd.Parameters.Add(param);

            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.String;
            param2.ParameterName = "@FechaFin";
            param2.Value = FechaInicio;
            cmd.Parameters.Add(param2);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeCotizaciones = new List<ENCotizacion>();
                ENCotizacion obeCotizacion;
                while (drd.Read())
                {
                    obeCotizacion = new ENCotizacion();
                    if (!drd.IsDBNull(0)) { obeCotizacion.idCotizacion = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCotizacion.idMarca = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeCotizacion.idModelo = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeCotizacion.Anio = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeCotizacion.ValorReferencial = drd.GetDecimal(4); };
                    if (!drd.IsDBNull(5)) { obeCotizacion.UsoVehiculo = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCotizacion.Descripcion_Modelo = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeCotizacion.Mail_Cliente = drd.GetString(7); };
                    if (!drd.IsDBNull(8)) { obeCotizacion.TelefonoCliente = drd.GetString(8); };
                    if (!drd.IsDBNull(9)) { obeCotizacion.RIMAC_Categoria = drd.GetString(9); };
                    if (!drd.IsDBNull(10)) { obeCotizacion.POSITIVA_Categoria = drd.GetString(10); };
                    if (!drd.IsDBNull(11)) { obeCotizacion.PACIFICO_Categoria = drd.GetString(11); };
                    if (!drd.IsDBNull(12)) { obeCotizacion.MAPFRE_Categoria = drd.GetString(12); };
                    if (!drd.IsDBNull(13)) { obeCotizacion.HDI_Categoria = drd.GetString(13); };
                    if (!drd.IsDBNull(14)) { obeCotizacion.FechaCreacion = drd.GetDateTime(14); };
                    lbeCotizaciones.Add(obeCotizacion);
                }
                drd.Close();
            }
            return lbeCotizaciones;
        }

    }
}
