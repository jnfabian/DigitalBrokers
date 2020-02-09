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
    public class DAVehiculo
    {
        public List<ENVehiculo> GetvehiculosListadoMarca(SqlConnection con, int idMarca, int idAnio)
        {
            List<ENVehiculo> lbeVehiculos = null;
            SqlCommand cmd = new SqlCommand("[DBPESPS_Admin_GetMarcaModeloByMarcaPrueba]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "idMarca";
            param.Value = idMarca;
            cmd.Parameters.Add(param);

            //Anio del vehiculo
            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.String;
            param2.ParameterName = "idAno";
            param2.Value = idAnio;
            cmd.Parameters.Add(param2);

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeVehiculos = new List<ENVehiculo>();
                ENVehiculo obeVehiculo;
                while (drd.Read())
                {
                    obeVehiculo = new ENVehiculo();
                    if (!drd.IsDBNull(0)) { obeVehiculo.idMarca = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeVehiculo.Marca = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeVehiculo.idModelo = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeVehiculo.Descripcion_Modelo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeVehiculo.Carroceria = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeVehiculo.Puertas = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeVehiculo.Asientos = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeVehiculo.Traccion = drd.GetString(7); };
                    if (!drd.IsDBNull(8)) { obeVehiculo.Desplazamiento = drd.GetString(8); };
                    if (!drd.IsDBNull(9)) { obeVehiculo.Potencia = drd.GetString(9); };
                    if (!drd.IsDBNull(10)) { obeVehiculo.Carburante = drd.GetString(10); };
                    if (!drd.IsDBNull(11)) { obeVehiculo.VRN = drd.GetDecimal(11); };
                    if (!drd.IsDBNull(12)) { obeVehiculo.PrecioAnio = drd.GetDecimal(12); };
     
                    //AnioVehiculoPrecio
                    lbeVehiculos.Add(obeVehiculo);
                }
                drd.Close();
            }
            return lbeVehiculos;
        }

        public ENVehiculoCompleto GetVehiculo(SqlConnection con, int idMarca, int idModelo, int Anio)
        {

            ENVehiculoCompleto obeVehiculo = new ENVehiculoCompleto();
            SqlCommand cmd = new SqlCommand("DBPESPS_Admin_GetVehiculo_Editar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.Int32;
            param.ParameterName = "@idMarca";
            param.Value = idMarca;
            cmd.Parameters.Add(param);

            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.Int32;
            param2.ParameterName = "@idModelo";
            param2.Value = idModelo;
            cmd.Parameters.Add(param2);

            DbParameter param3 = cmd.CreateParameter();
            param3.DbType = DbType.String;
            param3.ParameterName = "@idAno";
            param3.Value = Anio.ToString();
            cmd.Parameters.Add(param3);



            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);

            if (drd != null)
            {
                while (drd.Read())
                {
                    if (!drd.IsDBNull(0)) { obeVehiculo.idMarca = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeVehiculo.Marca = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeVehiculo.idModelo = drd.GetInt32(2); };
                    if (!drd.IsDBNull(3)) { obeVehiculo.Descripcion_Modelo = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeVehiculo.Carroceria = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeVehiculo.Puertas = drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeVehiculo.Asientos = drd.GetString(6); };
                    if (!drd.IsDBNull(7)) { obeVehiculo.Traccion = drd.GetString(7); };
                    if (!drd.IsDBNull(8)) { obeVehiculo.Desplazamiento = drd.GetString(8); };
                    if (!drd.IsDBNull(9)) { obeVehiculo.Potencia = drd.GetString(9); };
                    if (!drd.IsDBNull(10)) { obeVehiculo.Carburante = drd.GetString(10); };
                    if (!drd.IsDBNull(11)) { obeVehiculo.VRN = drd.GetDecimal(11); };
                    if (!drd.IsDBNull(12)) { obeVehiculo.PrecioAnio = drd.GetDecimal(12); };
                    if (!drd.IsDBNull(13)) { obeVehiculo.Clasificacion_LaPositiva = drd.GetString(13); };
                    if (!drd.IsDBNull(14)) { obeVehiculo.Clasificacion_Mapfre = drd.GetString(14); };
                    if (!drd.IsDBNull(15)) { obeVehiculo.Clasificacion_Pacifico = drd.GetString(15); };
                    if (!drd.IsDBNull(16)) { obeVehiculo.Clasificacion_Rimac = drd.GetString(16); };
                    if (!drd.IsDBNull(17)) { obeVehiculo.Clasificacion_HDI = drd.GetString(17); };
                    if (!drd.IsDBNull(18)) { obeVehiculo.GPS_LaPositiva = drd.GetString(18); };
                    if (!drd.IsDBNull(19)) { obeVehiculo.GPS_Mapfre = drd.GetString(19); };
                    if (!drd.IsDBNull(20)) { obeVehiculo.GPS_Pacifico = drd.GetString(20); };
                    if (!drd.IsDBNull(21)) { obeVehiculo.GPS_Rimac = drd.GetString(21); };
                    if (!drd.IsDBNull(22)) { obeVehiculo.GPS_HDI= drd.GetString(22); };





                }
                drd.Close();
            }
            return obeVehiculo;
        }

        //Actualiza Vehiculo 
        public int SaveVehiculo_TRANS(SqlConnection con, ENVehiculoCompleto oVehiculo)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("[DBPESPS_Admin_UPD_Vehiculos]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parm = new SqlParameter("@Retorno", SqlDbType.Int);
                parm.Size = 50;
                parm.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm);

                SqlParameter parmT = new SqlParameter("@idMarca", SqlDbType.Int);
                parmT.Value = oVehiculo.idMarca;
                parmT.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmT);

                SqlParameter parm2 = new SqlParameter("@idModelo", SqlDbType.Int);
                parm2.Value = oVehiculo.idModelo;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@Descripcion_modelo", SqlDbType.NVarChar);
                parm3.Value = oVehiculo.Descripcion_Modelo;
                parm3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm3);

                SqlParameter parm4 = new SqlParameter("@Carroceria", SqlDbType.Char);
                parm4.Value = oVehiculo.Carroceria;
                parm4.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm4);

                SqlParameter parm5 = new SqlParameter("@Puertas", SqlDbType.Char);
                parm5.Value = oVehiculo.Puertas;
                parm5.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@Asientos", SqlDbType.Char);
                parm6.Value = oVehiculo.Asientos;
                parm6.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm6);

                SqlParameter parm7 = new SqlParameter("@Traccion", SqlDbType.Char);
                parm7.Value = oVehiculo.Traccion;
                parm7.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm7);

                SqlParameter parm8 = new SqlParameter("@Desplazamiento", SqlDbType.NVarChar);
                parm8.Value = oVehiculo.Desplazamiento;
                parm8.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm8);

                SqlParameter parm9 = new SqlParameter("@Potencia", SqlDbType.Char);
                parm9.Value = oVehiculo.Potencia;
                parm9.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm9);


                SqlParameter parmC = new SqlParameter("@Carburante", SqlDbType.Char);
                parmC.Value = oVehiculo.Carburante;
                parmC.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmC);


                SqlParameter parm10 = new SqlParameter("@VRN", SqlDbType.Decimal);
                parm10.Value = oVehiculo.VRN;
                parm10.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm10);

                SqlParameter parm11 = new SqlParameter("@Precio", SqlDbType.Decimal);
                parm11.Value = oVehiculo.PrecioAnio;
                parm11.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm11);

                //CLASIFICACINES GENERALES
                SqlParameter parm12 = new SqlParameter("@POSITIVA", SqlDbType.NVarChar);
                parm12.Value = oVehiculo.Clasificacion_LaPositiva;
                parm12.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm12);

                SqlParameter parm13 = new SqlParameter("@MAPFRE", SqlDbType.NVarChar);
                parm13.Value = oVehiculo.Clasificacion_Mapfre;
                parm13.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm13);

                SqlParameter parm14 = new SqlParameter("@PACIFICO", SqlDbType.NVarChar);
                parm14.Value = oVehiculo.Clasificacion_Pacifico;
                parm14.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm14);

                SqlParameter parm15 = new SqlParameter("@RIMAC", SqlDbType.NVarChar);
                parm15.Value = oVehiculo.Clasificacion_Rimac;
                parm15.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm15);

                SqlParameter parm16 = new SqlParameter("@HDI", SqlDbType.NVarChar);
                parm16.Value = oVehiculo.Clasificacion_HDI;
                parm16.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm16);
                
                //GPS VEHICULAR
                SqlParameter parm17 = new SqlParameter("@GPS_HDI", SqlDbType.Char);
                parm17.Value = oVehiculo.GPS_HDI;
                parm17.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm17);

                SqlParameter parm18 = new SqlParameter("@GPS_POSITIVA", SqlDbType.Char);
                parm18.Value = oVehiculo.GPS_LaPositiva;
                parm18.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm18);

                SqlParameter parm19 = new SqlParameter("@GPS_MAPFRE", SqlDbType.Char);
                parm19.Value = oVehiculo.GPS_Mapfre;
                parm19.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm19);

                SqlParameter parm20 = new SqlParameter("@GPS_PACIFICO", SqlDbType.Char);
                parm20.Value = oVehiculo.GPS_Pacifico;
                parm20.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm20);

                SqlParameter parm21 = new SqlParameter("@GPS_RIMAC", SqlDbType.Char);
                parm21.Value = oVehiculo.GPS_Rimac;
                parm21.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm21);

                SqlParameter parm22 = new SqlParameter("@Anio", SqlDbType.NVarChar);
                parm22.Value = oVehiculo.Anio;
                parm22.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm22);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                object idVehiculo = cmd.Parameters["@Retorno"].Value;
                return (int)(idVehiculo);
            }
        }

        public int SaveNewVehiculo_TRANS(SqlConnection con, ENVehiculoCompleto oVehiculo)
        {
            using (con)
            {
                SqlCommand sqlCommand = new SqlCommand("[DBPESPS_Admin_INS_Vehiculos]", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter1 = new SqlParameter("@Retorno", SqlDbType.Int);
                sqlParameter1.Size = 50;
                sqlParameter1.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameter1);
                
                SqlParameter sqlParameter2 = new SqlParameter("@idMarca", SqlDbType.Int);
                sqlParameter2.Value = oVehiculo.idMarca;
                sqlParameter2.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter2);


                SqlParameter sqlParameter3 = new SqlParameter("@Marca", SqlDbType.NVarChar);
                sqlParameter3.Value = oVehiculo.Marca;
                sqlParameter3.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter3);
                
                SqlParameter sqlParameter4 = new SqlParameter("@idModelo", SqlDbType.Int);
                sqlParameter4.Value = oVehiculo.idModelo;
                sqlParameter4.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter4);
                
                SqlParameter sqlParameter5 = new SqlParameter("@Descripcion_modelo", SqlDbType.NVarChar);
                sqlParameter5.Value = oVehiculo.Descripcion_Modelo;
                sqlParameter5.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter5);
                
                SqlParameter sqlParameter6 = new SqlParameter("@Carroceria", SqlDbType.Char);
                sqlParameter6.Value = oVehiculo.Carroceria;
                sqlParameter6.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter6);
                
                SqlParameter sqlParameter7 = new SqlParameter("@Puertas", SqlDbType.Char);
                sqlParameter7.Value = oVehiculo.Puertas;
                sqlParameter7.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter7);
                
                SqlParameter sqlParameter8 = new SqlParameter("@Asientos", SqlDbType.Char);
                sqlParameter8.Value = oVehiculo.Asientos;
                sqlParameter8.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter8);
                
                SqlParameter sqlParameter9 = new SqlParameter("@Traccion", SqlDbType.Char);
                sqlParameter9.Value = oVehiculo.Traccion;
                sqlParameter9.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter9);
                
                SqlParameter sqlParameter10 = new SqlParameter("@Desplazamiento", SqlDbType.NVarChar);
                sqlParameter10.Value = oVehiculo.Desplazamiento;
                sqlParameter10.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter10);
                
                SqlParameter sqlParameter11 = new SqlParameter("@Potencia", SqlDbType.Char);
                sqlParameter11.Value = oVehiculo.Potencia;
                sqlParameter11.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter11);
                
                SqlParameter sqlParameter12 = new SqlParameter("@Carburante", SqlDbType.Char);
                sqlParameter12.Value = oVehiculo.Carburante;
                sqlParameter12.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter12);
                
                SqlParameter sqlParameter13 = new SqlParameter("@VRN", SqlDbType.Decimal);
                sqlParameter13.Value = oVehiculo.VRN;
                sqlParameter13.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter13);
                
                SqlParameter sqlParameter14 = new SqlParameter("@POSITIVA", SqlDbType.NVarChar);
                sqlParameter14.Value = oVehiculo.Clasificacion_LaPositiva;
                sqlParameter14.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter14);
                
                SqlParameter sqlParameter15 = new SqlParameter("@MAPFRE", SqlDbType.NVarChar);
                sqlParameter15.Value = oVehiculo.Clasificacion_Mapfre;
                sqlParameter15.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter15);
                
                SqlParameter sqlParameter16 = new SqlParameter("@PACIFICO", SqlDbType.NVarChar);
                sqlParameter16.Value = oVehiculo.Clasificacion_Pacifico;
                sqlParameter16.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter16);
                
                SqlParameter sqlParameter17 = new SqlParameter("@RIMAC", SqlDbType.NVarChar);
                sqlParameter17.Value = oVehiculo.Clasificacion_Rimac;
                sqlParameter17.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter17);
               
                SqlParameter sqlParameter18 = new SqlParameter("@HDI", SqlDbType.NVarChar);
                sqlParameter18.Value = oVehiculo.Clasificacion_HDI;
                sqlParameter18.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter18);
                
                SqlParameter sqlParameter19 = new SqlParameter("@GPS_HDI", SqlDbType.Char);
                sqlParameter19.Value = oVehiculo.GPS_HDI;
                sqlParameter19.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter19);
                
                SqlParameter sqlParameter20 = new SqlParameter("@GPS_POSITIVA", SqlDbType.Char);
                sqlParameter20.Value = oVehiculo.GPS_LaPositiva;
                sqlParameter20.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter20);
                
                SqlParameter sqlParameter21 = new SqlParameter("@GPS_MAPFRE", SqlDbType.Char);
                sqlParameter21.Value = oVehiculo.GPS_Mapfre;
                sqlParameter21.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter21);
                
                SqlParameter sqlParameter22 = new SqlParameter("@GPS_PACIFICO", SqlDbType.Char);
                sqlParameter22.Value = oVehiculo.GPS_Pacifico;
                sqlParameter22.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter22);
                
                SqlParameter sqlParameter23 = new SqlParameter("@GPS_RIMAC", SqlDbType.Char);
                sqlParameter23.Value = oVehiculo.GPS_Rimac;
                sqlParameter23.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter23);
                
                SqlParameter sqlParameter24 = new SqlParameter("@P2017", SqlDbType.Decimal);
                sqlParameter24.Value = oVehiculo.P2017;
                sqlParameter24.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter24);
                
                SqlParameter sqlParameter25 = new SqlParameter("@P2016", SqlDbType.Decimal);
                sqlParameter25.Value = oVehiculo.P2016;
                sqlParameter25.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter25);
                
                SqlParameter sqlParameter26 = new SqlParameter("@P2015", SqlDbType.Decimal);
                sqlParameter26.Value = oVehiculo.P2015;
                sqlParameter26.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter26);
                
                SqlParameter sqlParameter27 = new SqlParameter("@P2014", SqlDbType.Decimal);
                sqlParameter27.Value = oVehiculo.P2014;
                sqlParameter27.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter27);
                
                SqlParameter sqlParameter28 = new SqlParameter("@P2013", SqlDbType.Decimal);
                sqlParameter28.Value = oVehiculo.P2013;
                sqlParameter28.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter28);
                
                SqlParameter sqlParameter29 = new SqlParameter("@P2012", SqlDbType.Decimal);
                sqlParameter29.Value = oVehiculo.P2012;
                sqlParameter29.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter29);
                
                SqlParameter sqlParameter30 = new SqlParameter("@P2011", SqlDbType.Decimal);
                sqlParameter30.Value = oVehiculo.P2011;
                sqlParameter30.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter30);
                
                SqlParameter sqlParameter31 = new SqlParameter("@P2010", SqlDbType.Decimal);
                sqlParameter31.Value = oVehiculo.P2010;
                sqlParameter31.Direction = ParameterDirection.Input;
                sqlCommand.Parameters.Add(sqlParameter31);
                
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
                return (int)sqlCommand.Parameters["@Retorno"].Value;
            }
        }

    }
}
