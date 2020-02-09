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
    public class DACobertura
    {
        public List<ENCobertura> GetCoberturaTipoAseguradora(SqlConnection con, int idCoberturaTipo, int idAseguradora)
        {
            List<ENCobertura> lbeCobertura = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCoberturaTipobyAseguradora", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "idCoberturaTipo";
            param.Value = idCoberturaTipo;
            cmd.Parameters.Add(param);

            //Anio del vehiculo
            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.Int32;
            param2.ParameterName = "idAseguradora";
            param2.Value = idAseguradora;
            cmd.Parameters.Add(param2);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeCobertura = new List<ENCobertura>();
                ENCobertura obeCobertura;
                while (drd.Read())
                {
                    obeCobertura = new ENCobertura();
                    if (!drd.IsDBNull(0)) { obeCobertura.idCobertura = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCobertura.idCoberturaTipo = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeCobertura.idAseguradora = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeCobertura.Descripcion = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeCobertura.ValorConvenio = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeCobertura.Estado = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCobertura.FechaCreacion = drd.GetDateTime(6); };
               
                    
                    lbeCobertura.Add(obeCobertura);
                }
                drd.Close();
            }
            return lbeCobertura;
        }

        public List<ENCobertura> GetCobTipobyAseguradoraTipoCob(SqlConnection con, int idAseguradora, int idTipoCobertura)
        {
            List<ENCobertura> lbeCobertura = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_Admin_GETCoberturasByAseguradoraTipoCobertura", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //ARGUMENTOS DE PROCEDURE

            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@idAseguradora";
            param.Value = idAseguradora;
            cmd.Parameters.Add(param);

            DbParameter param1 = cmd.CreateParameter();
            param1.DbType = DbType.Int32;
            param1.ParameterName = "@idTipoCobertura";
            param1.Value = idTipoCobertura;
            cmd.Parameters.Add(param1);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeCobertura = new List<ENCobertura>();
                ENCobertura obeCobertura;
                while (drd.Read())
                {
                    obeCobertura = new ENCobertura();
                    if (!drd.IsDBNull(0)) { obeCobertura.idCobertura = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCobertura.idCoberturaTipo = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeCobertura.idAseguradora = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeCobertura.Descripcion = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeCobertura.ValorConvenio = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeCobertura.Estado = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCobertura.FechaCreacion = drd.GetDateTime(6); };


                    lbeCobertura.Add(obeCobertura);
                }
                drd.Close();
            }
            return lbeCobertura;
        }

        public ENCobertura getCobertura_ByID(SqlConnection con, int idCobertura)
        {

            ENCobertura obeCobertura = new ENCobertura();
            SqlCommand cmd = new SqlCommand("DBPESPS_Admin_GETCobertura_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@idCobertura";
            param.Value = idCobertura;
            cmd.Parameters.Add(param);



            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                while (drd.Read())
                {
                    if (!drd.IsDBNull(0)) { obeCobertura.idCobertura = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCobertura.idCoberturaTipo = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeCobertura.idAseguradora = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeCobertura.Descripcion = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeCobertura.ValorConvenio = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeCobertura.Estado = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeCobertura.FechaCreacion = drd.GetDateTime(6); };


                }
                drd.Close();
            }
            return obeCobertura;
        }

        //UPDATE COBERTURA
        public int SaveCobertura_TRANS(SqlConnection con, ENCobertura oCobertura)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("DBPESPS_Admin_UPD_Cobertura", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm = new SqlParameter("@Retorno", SqlDbType.Int);
                parm.Size = 50;
                parm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm);

                SqlParameter parmT = new SqlParameter("@idCobertura", SqlDbType.Int);
                parmT.Value = oCobertura.idCobertura;
                parmT.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmT);

                SqlParameter parm1 = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
                parm1.Value = oCobertura.Descripcion;
                parm1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@ValorConvenio", SqlDbType.NVarChar);
                parm2.Value = oCobertura.ValorConvenio;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@Estado", SqlDbType.NVarChar);
                parm3.Value = oCobertura.Estado;
                parm3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm3);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                object idCobertura = cmd.Parameters["@Retorno"].Value;
                return (int)(idCobertura);
            }
        }
    }

    public class DACoberturaSalud
    {
        public List<ENCoberturaSalud> GetCoberturaTipoAseguradora(SqlConnection con)
        {
            List<ENCoberturaSalud> lbeCobertura = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_GetCoberturaSalud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //ARGUMENTOS DE PROCEDURE
           

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeCobertura = new List<ENCoberturaSalud>();
                ENCoberturaSalud obeCobertura;
                while (drd.Read())
                {
                    obeCobertura = new ENCoberturaSalud();
                    if (!drd.IsDBNull(0)) { obeCobertura.idCoberturaSalud = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCobertura.idAseguradora = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeCobertura.Descripcion = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeCobertura.Valor= drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeCobertura.Estado = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeCobertura.FechaCreacion = drd.GetDateTime(5); };


                    lbeCobertura.Add(obeCobertura);
                }
                drd.Close();
            }
            return lbeCobertura;
        }

       
    }
}
