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
    public class LNCobertura: BRGeneral
    {
        //GetCoberturaTipoAseguradora
        public List<ENCobertura> GetCoberturaTipoAseguradora(int idCoberturaTipo, int idAseguradora)
        {
            List<ENCobertura> lbeCoberturas = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACobertura odCobertura = new DACobertura();
                    lbeCoberturas = odCobertura.GetCoberturaTipoAseguradora(con, idCoberturaTipo, idAseguradora);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeCoberturas;
        }

        //Filtrado por Aseguradora y Tipo de Cobertura GetCobTipobyAseguradoraTipoCob

        public List<ENCobertura> GetCobTipobyAseguradoraTipoCob(int idCoberturaTipo, int idAseguradora)
        {
            List<ENCobertura> lbeCoberturas = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACobertura odCobertura = new DACobertura();
                    lbeCoberturas = odCobertura.GetCobTipobyAseguradoraTipoCob(con, idCoberturaTipo, idAseguradora);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeCoberturas;
        }
        //getCobertura_ByID
        public ENCobertura getCobertura_ByID(int idCobertura)
        {
            ENCobertura beCobertura = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACobertura odaCobertura = new DACobertura();
                    beCobertura = odaCobertura.getCobertura_ByID(con, idCobertura);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }

                return beCobertura;
            }
        }

        public int SaveCobertura_TRANS(ENCobertura oCobertura)
        {

            DACobertura data = new DACobertura();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveCobertura_TRANS(con, oCobertura);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }

            return Resultado;

        }
    
    }

    public class LNCoberturaSalud: BRGeneral
    {
        //GetCoberturaTipoAseguradora
        public List<ENCoberturaSalud> GetCoberturasSalud()
        {
            List<ENCoberturaSalud> lbeCoberturas = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACoberturaSalud odCobertura = new DACoberturaSalud();
                    lbeCoberturas = odCobertura.GetCoberturaTipoAseguradora(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeCoberturas;
        }

      

    }
}
