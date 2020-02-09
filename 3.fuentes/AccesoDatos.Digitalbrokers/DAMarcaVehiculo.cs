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
    public class DAMarcaVehiculo
    {
        public List<ENMarcaVehiculo> GetMarcasVehiculo(SqlConnection con)
        {
            List<ENMarcaVehiculo> lbeMarcas = null;
            SqlCommand cmd = new SqlCommand("DBPESPS_GetMarcasVehiculo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeMarcas = new List<ENMarcaVehiculo>();
                ENMarcaVehiculo obeMarcas;
                while (drd.Read())
                {
                    obeMarcas = new ENMarcaVehiculo();
                    if (!drd.IsDBNull(0)) { obeMarcas.idMarca = drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeMarcas.Descripcion = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeMarcas.chrEstado = drd.GetString(2); };
                    lbeMarcas.Add(obeMarcas);
                }
                drd.Close();
            }
            return lbeMarcas;
        }
    }
}
