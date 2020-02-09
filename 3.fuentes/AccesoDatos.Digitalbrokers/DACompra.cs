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
   public class DACompra
    {
       //ADMINISTRADOR
       public List<ENCompraDesc> GetComprasCliente(SqlConnection con)
       {
           List<ENCompraDesc> lbeCompras = null;
           SqlCommand cmd = new SqlCommand("DBPESPS_COMPRALISTA", con);
           cmd.CommandType = CommandType.StoredProcedure;



           SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
           if (drd != null)
           {
               lbeCompras = new List<ENCompraDesc>();
               ENCompraDesc obeCompras;
               while (drd.Read())
               {
                   obeCompras = new ENCompraDesc();
                   if (!drd.IsDBNull(0)) { obeCompras.idCompra= drd.GetInt32(0); };
                   if (!drd.IsDBNull(1)) { obeCompras.idCotizacion = drd.GetInt32(1); };
                   if (!drd.IsDBNull(2)) { obeCompras.Nombres = drd.GetString(2); };
                   if (!drd.IsDBNull(3)) { obeCompras.Apellido_Paterno = drd.GetString(3); };
                   if (!drd.IsDBNull(4)) { obeCompras.Apellido_Materno = drd.GetString(4); };
                   if (!drd.IsDBNull(5)) { obeCompras.DNI = drd.GetString(5); };
                   if (!drd.IsDBNull(6)) { obeCompras.Telefono = drd.GetString(6); };
                   if (!drd.IsDBNull(7)) { obeCompras.Domicilio = drd.GetString(7); };
                   if (!drd.IsDBNull(8)) { obeCompras.Seguro = drd.GetString(8); };
                   if (!drd.IsDBNull(9)) { obeCompras.FechaCompra = drd.GetDateTime(9); };
                   if (!drd.IsDBNull(10)) { obeCompras.Estado = drd.GetString(10); };
                  
                   lbeCompras.Add(obeCompras);
               }
               drd.Close();
           }
           return lbeCompras;
       }
    }
}
