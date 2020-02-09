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
    public class LNCompras:BRGeneral
    {
        //ADMINISTRADOR COMPRAS
        public List<ENCompraDesc> GetComprasClientes()
        {
            List<ENCompraDesc> lbeCompra = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACompra odCompra = new DACompra();
                    lbeCompra = odCompra.GetComprasCliente(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeCompra;
        }
    }
}
