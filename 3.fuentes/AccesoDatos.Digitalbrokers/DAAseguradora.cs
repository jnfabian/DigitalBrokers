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
    public class DAAseguradora
    {
        public List<ENAseguradora> GetAseguradorasLista(SqlConnection con)
        {
            List<ENAseguradora> lbeAseguradora = null;
            SqlCommand cmd = new SqlCommand("[DBPESPS_Admin_GETAseguradorasLista]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //ARGUMENTOS DE PROCEDURE
           

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeAseguradora = new List<ENAseguradora>();
                ENAseguradora obeAseguradora;
                while (drd.Read())
                {
                    obeAseguradora = new ENAseguradora();

                    if (!drd.IsDBNull(0)) { obeAseguradora.idAseguradora= drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeAseguradora.vchNombre = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeAseguradora.vchDescripcion = drd.GetString(2); };
                    if (!drd.IsDBNull(3)) { obeAseguradora.vchImagen = drd.GetString(3); };


                    //AnioVehiculoPrecio
                    lbeAseguradora.Add(obeAseguradora);
                }
                drd.Close();
            }
            return lbeAseguradora;
        }
    }
}
