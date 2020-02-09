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
   public class DAVehiculoModelo
    {
       public List<ENVehiculoModelo> GetModelosVehiculos(SqlConnection con, int idMarca, string idAnio)
       {
           List<ENVehiculoModelo> lbeModelos = null;
           SqlCommand cmd = new SqlCommand("DBPESPS_GetMarcaModeloByMarcaPrueba", con);
           cmd.CommandType = CommandType.StoredProcedure;
           //ARGUMENTOS DE PROCEDURE
           DbParameter param = cmd.CreateParameter();
           param.DbType = DbType.Int32;
           param.ParameterName = "idMarca";
           param.Value = idMarca;
           cmd.Parameters.Add(param);

           //Anio del vehiculo
           DbParameter param2 = cmd.CreateParameter();
           param2.DbType = DbType.String;
           param2.ParameterName = "idAno";
           param2.Value = idAnio.Trim();
           cmd.Parameters.Add(param2);

           SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
           if (drd != null)
           {
               lbeModelos = new List<ENVehiculoModelo>();
               ENVehiculoModelo obeModelos;
               while (drd.Read())
               {
                   obeModelos = new ENVehiculoModelo();
                   if (!drd.IsDBNull(0)) { obeModelos.idMarca = drd.GetInt32(0); };
                   if (!drd.IsDBNull(1)) { obeModelos.idModelo = drd.GetInt32(1); };
                   if (!drd.IsDBNull(2)) { obeModelos.Descripcion_Modelo= drd.GetString(2); };
                   if (!drd.IsDBNull(3)) { obeModelos.VNR= drd.GetDecimal(3); };
                   if (!drd.IsDBNull(4)) { obeModelos.AnioVehiculoPrecio = drd.GetDecimal(4); };
                   //AnioVehiculoPrecio
                   lbeModelos.Add(obeModelos);
               }
               drd.Close();
           }
           return lbeModelos;
       }
    }
}
