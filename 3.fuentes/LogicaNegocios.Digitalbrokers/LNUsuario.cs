using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Digitalbrokers;
using Entidades.Digitalbrokers;
using System.Data.SqlClient;

namespace LogicaNegocios.Digitalbrokers
{
    public class LNUsuario:BRGeneral
    {
        public ENUsuario GetUsuarioLoginEmail(string usuario, string password)
        {
            ENUsuario oUsuario = new ENUsuario();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAUsuario odEmpleado = new DAUsuario();
                    oUsuario = odEmpleado.GetUsuarioLoginEmail(con, usuario, password);

                }
                catch (Exception ex)
                {
                    GrabarLog(ex);

                }

                return oUsuario;
            }
        }
    }
}
