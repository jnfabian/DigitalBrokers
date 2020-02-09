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
    public class LNMarcaVehiculo: BRGeneral
    {
        public List<ENMarcaVehiculo> GetMarcasVehiculo()
        {
            List<ENMarcaVehiculo> lbeMarcas = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAMarcaVehiculo odMarcas= new DAMarcaVehiculo();
                    lbeMarcas = odMarcas.GetMarcasVehiculo(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeMarcas;
        }

    }
}
