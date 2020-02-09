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
    public class DACliente
    {
        public int SaveCliente(SqlConnection con, ENCliente oCliente)
        {
            using (con)
            {


                SqlCommand cmd = new SqlCommand("DBPESPS_ClienteRegistro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametro de Retorno IDentity
                SqlParameter parmR = new SqlParameter("@CodigoRetorno", SqlDbType.Int);
                parmR.Size = 50;
                parmR.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parmR);

                SqlParameter parm1 = new SqlParameter("@Nombres", SqlDbType.NVarChar);
                parm1.Value = oCliente.Nombres;
                parm1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@Apellido_Paterno", SqlDbType.NVarChar);
                parm2.Value = oCliente.Apellido_Paterno;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);

                SqlParameter parm3 = new SqlParameter("@Apellido_Materno", SqlDbType.NVarChar);
                parm3.Value = oCliente.Apellido_Materno;
                parm3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm3);

                SqlParameter parm4 = new SqlParameter("@DNI", SqlDbType.NVarChar);
                parm4.Value = oCliente.DNI;
                parm4.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm4);

                SqlParameter parm5 = new SqlParameter("@Sexo", SqlDbType.NVarChar);
                parm5.Value = oCliente.Sexo;
                parm5.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@Email", SqlDbType.NVarChar);
                parm6.Value = oCliente.Email;
                parm6.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm6);

                SqlParameter parm7 = new SqlParameter("@Telefono", SqlDbType.NVarChar);
                parm7.Value = oCliente.Telefono;
                parm7.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm7);

                SqlParameter parm8 = new SqlParameter("@Domicilio", SqlDbType.NVarChar);
                parm8.Value = oCliente.Domicilio;
                parm8.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm8);

                SqlParameter parm9 = new SqlParameter("@Ciudad", SqlDbType.NVarChar);
                parm9.Value = oCliente.Ciudad;
                parm9.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm9);

                SqlParameter parm10 = new SqlParameter("@Estado", SqlDbType.NVarChar);
                parm10.Value = "A";
                parm10.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm10);


                SqlParameter parm11 = new SqlParameter("@idCotizacion", SqlDbType.Int);
                parm11.Value = oCliente.idCotizacion;
                parm11.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm11);

                SqlParameter parm12 = new SqlParameter("@idAseguradora", SqlDbType.Int);
                parm12.Value = oCliente.idAseguradora;
                parm12.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm12);



                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                object intSolicitudCotizacion = cmd.Parameters["@CodigoRetorno"].Value;
                return (int)(intSolicitudCotizacion);
            }
        }
    }
}
