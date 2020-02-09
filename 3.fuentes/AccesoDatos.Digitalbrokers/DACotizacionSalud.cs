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
    public class DACotizacionSalud
    {
        public int SaveCotizacionSalud(SqlConnection con, ENCotizacionSalud oCotizacion)
        {
            using (con)
            {


                SqlCommand cmd = new SqlCommand("DBPESPS_SaveCotizacionSalud", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametro de Retorno IDentity
                SqlParameter parmR = new SqlParameter("@CodigoRetorno", SqlDbType.Int);
                parmR.Size = 50;
                parmR.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parmR);

                SqlParameter parm1 = new SqlParameter("@Nombres", SqlDbType.NVarChar);
                parm1.Value = oCotizacion.Nombres;
                parm1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@Apellidos", SqlDbType.NVarChar);
                parm2.Value = oCotizacion.Apellidos;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);
                
                SqlParameter parmE = new SqlParameter("@Edad", SqlDbType.Int);
                parmE.Value = oCotizacion.Edad;
                parmE.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmE);


                SqlParameter parm3 = new SqlParameter("@DNI", SqlDbType.NVarChar);
                parm3.Value = oCotizacion.DNI;
                parm3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm3);

                SqlParameter parm4 = new SqlParameter("@Email", SqlDbType.NVarChar);
                parm4.Value = oCotizacion.Email;
                parm4.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm4);


                SqlParameter parm5 = new SqlParameter("@Telefono", SqlDbType.NVarChar);
                parm5.Value = oCotizacion.Telefono;
                parm5.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm5);

               


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                object intCotizacion = cmd.Parameters["@CodigoRetorno"].Value;
                return (int)(intCotizacion);
            }
        }

        public ENCotizacionSalud GetCotizacionSaludCabecera(SqlConnection con, int idCotizacion)
        {

            ENCotizacionSalud obeCotizacion = new ENCotizacionSalud();
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCotizacionSalud", con);
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
                    if (!drd.IsDBNull(0)) { obeCotizacion.idCotizacionSalud = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCotizacion.Nombres = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeCotizacion.Apellidos = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeCotizacion.Edad = drd.GetInt32(3); };
                    if (!drd.IsDBNull(4)) { obeCotizacion.DNI = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeCotizacion.Email = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCotizacion.Telefono = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeCotizacion.FechaSolicitud = drd.GetDateTime(7); };
                  


                }
                drd.Close();
            }
            return obeCotizacion;
        }

        public List<ENCotizacionSalud> GetCotizacionesSaludDashboard(SqlConnection con)
        {
            List<ENCotizacionSalud> lbeCotizaciones = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCotizacionesSaludAll", con);
            cmd.CommandType = CommandType.StoredProcedure;



            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeCotizaciones = new List<ENCotizacionSalud>();
                ENCotizacionSalud obeCotizacion;
                while (drd.Read())
                {
                    obeCotizacion = new ENCotizacionSalud();
                    if (!drd.IsDBNull(0)) { obeCotizacion.idCotizacionSalud = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCotizacion.Nombres = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeCotizacion.Apellidos = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeCotizacion.Edad = drd.GetInt32(3); };
                    if (!drd.IsDBNull(4)) { obeCotizacion.DNI = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeCotizacion.Email = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCotizacion.Telefono = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeCotizacion.FechaSolicitud = drd.GetDateTime(7); };
                    lbeCotizaciones.Add(obeCotizacion);
                }
                drd.Close();
            }
            return lbeCotizaciones;
        }

        public List<ENCotizacionSalud> GetCotizacionesSaludDashboardFiltro(SqlConnection con, string FechaInicio, string FechaFin)
        {
            List<ENCotizacionSalud> lbeCotizaciones = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCotizacionesSaludFiltro", con);
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
                lbeCotizaciones = new List<ENCotizacionSalud>();
                ENCotizacionSalud obeCotizacion;
                while (drd.Read())
                {
                    obeCotizacion = new ENCotizacionSalud();
                    if (!drd.IsDBNull(0)) { obeCotizacion.idCotizacionSalud = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCotizacion.Nombres = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeCotizacion.Apellidos = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeCotizacion.Edad = drd.GetInt32(3); };
                    if (!drd.IsDBNull(4)) { obeCotizacion.DNI = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeCotizacion.Email = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCotizacion.Telefono = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeCotizacion.FechaSolicitud = drd.GetDateTime(7); };
                    lbeCotizaciones.Add(obeCotizacion);
                }
                drd.Close();
            }
            return lbeCotizaciones;
        }
    }
}
