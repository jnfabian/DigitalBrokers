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
    public class DAAseguradoraTasas
    {
        public List<ENAseguradoraTasas> GetTasasAseguradora_ByAseguradora(SqlConnection con, int idAseguradora, string Anio)
        {
            List<ENAseguradoraTasas> lbeTasas = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_Admin_GETAseguradoraTasas_Aseguradora", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@idAseguradora";
            param.Value = idAseguradora;
            cmd.Parameters.Add(param);

            //Anio del vehiculo
            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.String;
            param2.ParameterName = "Anio";
            param2.Value = Anio;
            cmd.Parameters.Add(param2);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeTasas = new List<ENAseguradoraTasas>();
                ENAseguradoraTasas obeTasas;
                while (drd.Read())
                {
                    obeTasas = new ENAseguradoraTasas();
                    if (!drd.IsDBNull(0)) { obeTasas.idCorrelativo = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeTasas.idAseguradora = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeTasas.DescAseguradora = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeTasas.Clasificacion = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeTasas.Provincia = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeTasas.Anio = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeTasas.Tasa = drd.GetDecimal(6); };
                    if (!drd.IsDBNull(7)) { obeTasas.Tasa_Provincia = drd.GetDecimal(7); };
                    if (!drd.IsDBNull(8)) { obeTasas.Estado = drd.GetString(8); };
                   

                    lbeTasas.Add(obeTasas);
                }
                drd.Close();
            }
            return lbeTasas;
        }
        public ENAseguradoraTasas getTasabyIdCorrelativo(SqlConnection con, int idCorrelativo)
        {

            ENAseguradoraTasas obeTasas = new ENAseguradoraTasas();
            SqlCommand cmd = new SqlCommand("DBPESPS_Admin_GETAseguradoraTasa_ByIdCorrelativo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@idCorrelativo";
            param.Value = idCorrelativo;
            cmd.Parameters.Add(param);



            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                while (drd.Read())
                {
                    if (!drd.IsDBNull(0)) { obeTasas.idCorrelativo = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeTasas.idAseguradora = drd.GetInt32(1); };
                    if (!drd.IsDBNull(2)) { obeTasas.DescAseguradora = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeTasas.Clasificacion = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeTasas.Provincia = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeTasas.Anio = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeTasas.Tasa = drd.GetDecimal(6); };
                    if (!drd.IsDBNull(7)) { obeTasas.Tasa_Provincia = drd.GetDecimal(7); };
                    if (!drd.IsDBNull(8)) { obeTasas.Estado = drd.GetString(8); };
                   


                }
                drd.Close();
            }
            return obeTasas;
        }

        public int UPDTasa_TRANS(SqlConnection con, int idCorrelativo, decimal Tasa)
        {
            using (con)
            {


                SqlCommand cmd = new SqlCommand("[DBPESPS_Admin_UPDTasaAseguradora_ByCorrelativo]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm = new SqlParameter("@Retorno", SqlDbType.Int);
                parm.Size = 50;
                parm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm);

                SqlParameter parmT = new SqlParameter("@idCorrelativo", SqlDbType.Int);
                parmT.Value = idCorrelativo;
                parmT.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmT);

                SqlParameter parm2 = new SqlParameter("@Tasa", SqlDbType.Decimal);
                parm2.Value = Tasa;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                object resultado = cmd.Parameters["@Retorno"].Value;
                return (int)(resultado);
            }
        }
    }
}
