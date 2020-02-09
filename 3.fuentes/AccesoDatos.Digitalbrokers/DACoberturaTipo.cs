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
    public class DACoberturaTipo
    {
        public List<ENCoberturaTipo> GetCoberturaTipoLista(SqlConnection con)
        {
            List<ENCoberturaTipo> lbeCobTipo = null;
            SqlCommand cmd = new SqlCommand("[DBPESPS_Admin_GETCoberturaTipoLista]", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeCobTipo = new List<ENCoberturaTipo>();
                ENCoberturaTipo obeCobTipo;
                while (drd.Read())
                {
                    obeCobTipo = new ENCoberturaTipo();

                    if (!drd.IsDBNull(0)) { obeCobTipo.idCoberturaTipo= drd.GetInt32(0); };
                    if (!drd.IsDBNull(1)) { obeCobTipo.Descripcion = drd.GetString(1); };
                    if (!drd.IsDBNull(2)) { obeCobTipo.Estado = drd.GetString(2); };
                   

                    
                    lbeCobTipo.Add(obeCobTipo);
                }
                drd.Close();
            }
            return lbeCobTipo;
        }


    }
}
