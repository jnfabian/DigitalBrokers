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
    public class LNAseguradoraTasas:BRGeneral

    {
        //
        public List<ENAseguradoraTasas> GetTasasAseguradora_ByAseguradora(int idAseguradora, string Anio)
        {
            List<ENAseguradoraTasas> lbeTasas = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAAseguradoraTasas odTasas = new DAAseguradoraTasas();
                    lbeTasas = odTasas.GetTasasAseguradora_ByAseguradora(con, idAseguradora, Anio);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeTasas;
        }

        public ENAseguradoraTasas GetTasabyidCorrelativo(int idCorrelativo)
        {
            ENAseguradoraTasas beTasa = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAAseguradoraTasas odaTasa = new DAAseguradoraTasas();
                    beTasa = odaTasa.getTasabyIdCorrelativo(con, idCorrelativo);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }

                return beTasa;
            }
        }

        public int UPD_TASA_ByCorrelativo_TRANS(int idCorrelativo, decimal Tasa)
        {
            DAAseguradoraTasas data = new DAAseguradoraTasas();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.UPDTasa_TRANS(con, idCorrelativo,Tasa);
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
