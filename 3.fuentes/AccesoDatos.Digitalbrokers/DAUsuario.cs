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
    public class DAUsuario
    {
        public ENUsuario GetUsuarioLoginEmail(SqlConnection con, string usuario, string password)
        {
            ENUsuario obeUsuario = new ENUsuario();
            SqlCommand cmd = new SqlCommand("Usuario_ListarxEmailPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //ARGUMENTOS DE PROCEDURE
            DbParameter param = cmd.CreateParameter();
            param.DbType = DbType.String;
            param.ParameterName = "usuario";
            param.Value = usuario;
            cmd.Parameters.Add(param);

            DbParameter param2 = cmd.CreateParameter();
            param2.DbType = DbType.String;
            param2.ParameterName = "password";
            param2.Value = password;
            cmd.Parameters.Add(param2);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);


            if (drd != null)
            {
                while (drd.Read())
                {
                    if (!drd.IsDBNull(0)) { obeUsuario.idUsuario= drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeUsuario.vchEmail= drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeUsuario.vchNombres = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeUsuario.vchPassword = drd.GetString(3); };
                    if (!drd.IsDBNull(4)) { obeUsuario.vchImagen = drd.GetString(4); };
                    if (!drd.IsDBNull(5)) { obeUsuario.chrEstado= drd.GetString(5); };
                    if (!drd.IsDBNull(6)) { obeUsuario.FechaCreacion = drd.GetDateTime(6); };
                
                }

                drd.Close();
            }

            return obeUsuario;
        }
    }
}
