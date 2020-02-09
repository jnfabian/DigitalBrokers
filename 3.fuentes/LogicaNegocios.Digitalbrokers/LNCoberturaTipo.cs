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
   public class LNCoberturaTipo:BRGeneral
    {
       public List<ENCoberturaTipo> GetCoberturaTipoLista()
       {
           List<ENCoberturaTipo> lbeCobTipo = null;
           using (SqlConnection con = new SqlConnection(CadenaConexion))
           {
               try
               {
                   con.Open();
                   DACoberturaTipo odCobTipo = new DACoberturaTipo();
                   lbeCobTipo = odCobTipo.GetCoberturaTipoLista(con);
               }
               catch (Exception ex)
               {
                   GrabarLog(ex);
               }
           }
           return lbeCobTipo;
       }

    }
}
