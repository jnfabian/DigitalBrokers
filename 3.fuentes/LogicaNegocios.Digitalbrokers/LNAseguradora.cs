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
    public class LNAseguradora:BRGeneral
    {
        public List<ENAseguradora> GetAseguradorasLista()
        {
            List<ENAseguradora> lbeAseguradoras = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAAseguradora odAseguradora = new DAAseguradora();
                    lbeAseguradoras = odAseguradora.GetAseguradorasLista(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeAseguradoras;
        }
    }
}
