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
    public class DADeducibles
    {
        public List<ENDeducibles> GetDeduciblesCategoria(SqlConnection con, string RIMAC, string MAPFRE, string PACIFICO, string POSITIVA, string HDI)
        {
            List<ENDeducibles> lbeDeducibles = null;
            SqlCommand cmd = new SqlCommand("DBPS_GetDeduciblesCategoria", con);
            cmd.CommandType = CommandType.StoredProcedure;
          
            //RIMAC
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.String;
            param.ParameterName = "@RIMAC_CATEGORIA";
            param.Value = RIMAC;
            cmd.Parameters.Add(param);


            //MAPFRE
            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.String;
            param2.ParameterName = "@MAPFRE_CATEGORIA ";
            param2.Value = MAPFRE;
            cmd.Parameters.Add(param2);

            //PACIFICO
            DbParameter param3 = cmd.CreateParameter();
            param3.DbType = DbType.String;
            param3.ParameterName = "@PACIFICO_CATEGORIA ";
            param3.Value = PACIFICO;
            cmd.Parameters.Add(param3);

            //POSITIVA
            DbParameter param4 = cmd.CreateParameter();
            param4.DbType = DbType.String;
            param4.ParameterName = "@POSITIVA_CATEGORIA";
            param4.Value = POSITIVA;
            cmd.Parameters.Add(param4);

            //HDI
            DbParameter param5 = cmd.CreateParameter();
            param5.DbType = DbType.String;
            param5.ParameterName = "@HDI_CATEGORIA";
            param5.Value = HDI;
            cmd.Parameters.Add(param5);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeDeducibles = new List<ENDeducibles>();
                ENDeducibles obeDeducible;
                while (drd.Read())
                {
                    obeDeducible = new ENDeducibles();
                    if (!drd.IsDBNull(0)) { obeDeducible.idDeducible = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeDeducible.idAseguradora = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeDeducible.Categoria = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeDeducible.CoberturaTipo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeDeducible.Descripcion = drd.GetString(4); };
                    lbeDeducibles.Add(obeDeducible);
                }
                drd.Close();
            }
            return lbeDeducibles;
        }

        public List<ENDeducibles> GetDeduciblesCategoriaAll(SqlConnection con)
        {
            List<ENDeducibles> lbeDeducibles = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_GetDeduciblesCategoria", con);
            cmd.CommandType = CommandType.StoredProcedure;

           

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeDeducibles = new List<ENDeducibles>();
                ENDeducibles obeDeducible;
                while (drd.Read())
                {
                    obeDeducible = new ENDeducibles();
                    if (!drd.IsDBNull(0)) { obeDeducible.idDeducible = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeDeducible.idAseguradora = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeDeducible.Categoria = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeDeducible.CoberturaTipo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeDeducible.Descripcion = drd.GetString(4); };
                    lbeDeducibles.Add(obeDeducible);
                }
                drd.Close();
            }
            return lbeDeducibles;
        }

        public List<ENDeducibles> GetDeduciblesCompaniaAseguradora(SqlConnection con, int idAseguradora, string Categoria)
        {
            List<ENDeducibles> lbeDeducibles = null;
            SqlCommand cmd = new SqlCommand("DBPS_GetDeduciblesCategoriaCompania", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //RIMAC
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "IdAseguradora";
            param.Value = idAseguradora;
            cmd.Parameters.Add(param);


            //MAPFRE
            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.String;
            param2.ParameterName = "@Categoria ";
            param2.Value = Categoria;
            cmd.Parameters.Add(param2);


            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeDeducibles = new List<ENDeducibles>();
                ENDeducibles obeDeducible;
                while (drd.Read())
                {
                    obeDeducible = new ENDeducibles();
                    if (!drd.IsDBNull(0)) { obeDeducible.idDeducible = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeDeducible.idAseguradora = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeDeducible.Categoria = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeDeducible.CoberturaTipo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeDeducible.Descripcion = drd.GetString(4); };
                    lbeDeducibles.Add(obeDeducible);
                }
                drd.Close();
            }
            return lbeDeducibles;
        }

        public List<ENDeducibles> GetDeduciblesCompania_xAseguradora(SqlConnection con, int idAseguradora)
        {
            List<ENDeducibles> lbeDeducibles = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_Admin_GETDeduciblesLista_xAseguradoraTipo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //PARAMETER
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "IdAseguradora";
            param.Value = idAseguradora;
            cmd.Parameters.Add(param);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeDeducibles = new List<ENDeducibles>();
                ENDeducibles obeDeducible;
                while (drd.Read())
                {
                    obeDeducible = new ENDeducibles();
                    if (!drd.IsDBNull(0)) { obeDeducible.idDeducible = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeDeducible.idAseguradora = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeDeducible.Categoria = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeDeducible.CoberturaTipo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeDeducible.Descripcion = drd.GetString(4); };
                    lbeDeducibles.Add(obeDeducible);
                }
                drd.Close();
            }
            return lbeDeducibles;
        }

        public ENDeducibles getDeducible_ByID(SqlConnection con, int idDeducible)
        {

            ENDeducibles obeDeducible = new ENDeducibles();
            SqlCommand cmd = new SqlCommand("DBPESPS_Admin_GETDeducibleBY_ID", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@idDeducible";
            param.Value = idDeducible;
            cmd.Parameters.Add(param);



            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                while (drd.Read())
                {
                    if (!drd.IsDBNull(0)) { obeDeducible.idDeducible = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeDeducible.idAseguradora = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeDeducible.Categoria = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeDeducible.CoberturaTipo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeDeducible.Descripcion = drd.GetString(4); };


                }
                drd.Close();
            }
            return obeDeducible;
        }

        //ACTUALIZACION DE DEDUCIBLE

        public int SaveDeducible_TRANS(SqlConnection con,int idDeducible, string Descripcion)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("DBPESPS_Admin_UPD_Deducible", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm = new SqlParameter("@Retorno", SqlDbType.Int);
                parm.Size = 50;
                parm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm);

                SqlParameter parmT = new SqlParameter("@idDeducible", SqlDbType.Int);
                parmT.Value = idDeducible;
                parmT.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmT);

                SqlParameter parm1 = new SqlParameter("@Descripcion", SqlDbType.NVarChar);
                parm1.Value = Descripcion;
                parm1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm1);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                object idProyecto = cmd.Parameters["@Retorno"].Value;
                return (int)(idDeducible);
            }
        }

    }


}
