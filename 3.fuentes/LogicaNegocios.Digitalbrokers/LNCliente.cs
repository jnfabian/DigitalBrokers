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
    public class LNCliente:BRGeneral
    {
        public int SaveCliente(ENCliente oCliente)
        {

            DACliente data = new DACliente();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveCliente(con, oCliente);
                }
                catch (Exception ex)
                {

                    GrabarLog(ex);
                }
            }

            return Resultado;

        }

    }
}
