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
    public class LNDeducibles:BRGeneral
    {
        //GetDeduciblesCategoria
        
        public List<ENDeducibles> GetDeduciblesCategoriaAll()
        {
            List<ENDeducibles> lbeDeducibles = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DADeducibles odDeducible = new DADeducibles();
                    lbeDeducibles = odDeducible.GetDeduciblesCategoriaAll(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeDeducibles;
        }
        public List<ENDeducibles> GetDeduciblesCompaniaAseguradora(int idAseguradora, string Categoria)
        {
            List<ENDeducibles> lbeDeducibles = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DADeducibles odDeducible = new DADeducibles();
                    lbeDeducibles = odDeducible.GetDeduciblesCompaniaAseguradora(con,idAseguradora,Categoria);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeDeducibles;
        }
        public List<ENDeducibles> GetDeduciblesCompania_xAseguradora(int idAseguradora)
        {
            List<ENDeducibles> lbeDeducibles = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DADeducibles odDeducible = new DADeducibles();
                    lbeDeducibles = odDeducible.GetDeduciblesCompania_xAseguradora(con, idAseguradora);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeDeducibles;
        }
        public ENDeducibles getDeducible_ByID(int idDeducible)
        {
            ENDeducibles beDeducible = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DADeducibles odaDeducible = new DADeducibles();
                    beDeducible = odaDeducible.getDeducible_ByID(con, idDeducible);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }

                return beDeducible;
            }
        }

        //ACTUALIZACON DE DEDUCILES
        public int SaveDeducible_TRANS(int idDeducible, string Descripcion)
        {

            DADeducibles data = new DADeducibles();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveDeducible_TRANS(con, idDeducible,Descripcion);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }

            return Resultado;

        }
        
    }
}
