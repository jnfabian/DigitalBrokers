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
    public class LNVehiculoModelo: BRGeneral
    {
        //GetModelosVehiculos
        public List<ENVehiculoModelo> GetModelosVehiculos(int idMarca, string idAnio)
        {
            List<ENVehiculoModelo> lbeModelos = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAVehiculoModelo odModelos = new DAVehiculoModelo();
                    lbeModelos = odModelos.GetModelosVehiculos(con, idMarca, idAnio);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeModelos;
        }
    }
}
