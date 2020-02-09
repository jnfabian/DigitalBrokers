using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Entidades.Digitalbrokers;


namespace AccesoDatos.Digitalbrokers
{
    public class DASolicitudCotizacion
    {
        public int SaveCotizacionCliente(SqlConnection con, ENSolicitudCotizacion oSolicitud)
        {
            using (con)
            {


                SqlCommand cmd = new SqlCommand("[PRUEBAS_COTIZACION]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametro de Retorno IDentity
                SqlParameter parmR = new SqlParameter("@CodigoRetorno", SqlDbType.Int);
                parmR.Size = 50;
                parmR.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parmR);

                SqlParameter parm1 = new SqlParameter("@idMarca", SqlDbType.Int);
                parm1.Value = oSolicitud.idMarca;
                parm1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm1);

                SqlParameter parm2 = new SqlParameter("@idModelo", SqlDbType.Int);
                parm2.Value = oSolicitud.idModelo;
                parm2.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm2);

                SqlParameter parmAnio = new SqlParameter("@Anio", SqlDbType.Char);
                parmAnio.Value = oSolicitud.Anio;
                parmAnio.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmAnio);

                SqlParameter parm3 = new SqlParameter("@Valorreferencial", SqlDbType.Decimal);
                parm3.Value = oSolicitud.valorReferencial;
                parm3.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm3);

                SqlParameter parm4 = new SqlParameter("@UsoVehiculo", SqlDbType.Char);
                parm4.Value = oSolicitud.UsoVehiculo;
                parm4.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm4);

                SqlParameter parmDesc = new SqlParameter("@DescripcionModelo", SqlDbType.NVarChar);
                parmDesc.Value = oSolicitud.Descripcion_Modelo;
                parmDesc.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmDesc);


                SqlParameter parm5 = new SqlParameter("@EmailSolicitante", SqlDbType.NVarChar);
                parm5.Value = oSolicitud.EmailSolicitante;
                parm5.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@TelefonoSolicitante", SqlDbType.NVarChar);
                parm6.Value = oSolicitud.TelefonoSolicitante;
                parm6.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm6);

                SqlParameter parm7 = new SqlParameter("@httpResponseURLEncode", SqlDbType.NVarChar);
                parm7.Value = oSolicitud.httpResponseURLEncode  ;
                parm7.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm7);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                object intSolicitudCotizacion = cmd.Parameters["@CodigoRetorno"].Value;
                return (int)(intSolicitudCotizacion);
            }
        }

        public int SaveSolicitudAtencionTelefonica(SqlConnection con, ENSolicitudComunicacion oSolicitud)
        {
            using (con)
            {


                SqlCommand cmd = new SqlCommand("[DBPESPS_SaveolicitudLlamada]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametro de Retorno IDentity
                SqlParameter parmR = new SqlParameter("@CodigoRetorno", SqlDbType.Int);
                parmR.Size = 50;
                parmR.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parmR);

                SqlParameter parm1 = new SqlParameter("@intTipoSolicitud", SqlDbType.Int);
                parm1.Value = oSolicitud.intTipoSolicitud;
                parm1.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm1);


                SqlParameter parmN = new SqlParameter("@Nombres", SqlDbType.NVarChar);
                parmN.Value = oSolicitud.Nombres;
                parmN.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parmN);

                SqlParameter parm5 = new SqlParameter("@EmailSolicitante", SqlDbType.NVarChar);
                parm5.Value = oSolicitud.EmailSolicitante;
                parm5.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm5);

                SqlParameter parm6 = new SqlParameter("@TelefonoSolicitante", SqlDbType.NVarChar);
                parm6.Value = oSolicitud.TelefonoSolicitante;
                parm6.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm6);

                SqlParameter parm7 = new SqlParameter("@httpResponseURI", SqlDbType.NVarChar);
                parm7.Value = oSolicitud.httpResponseUri;
                parm7.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parm7);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                object intSolicitudCotizacion = cmd.Parameters["@CodigoRetorno"].Value;
                return (int)(intSolicitudCotizacion);
            }
        }
    }
}
