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
    public class LNCotizacionSalud:BRGeneral
    {
        public int SaveCotizacionSalud(ENCotizacionSalud oCotizacion)
        {

            DACotizacionSalud data = new DACotizacionSalud();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveCotizacionSalud(con, oCotizacion);
                }
                catch (Exception ex)
                {

                    GrabarLog(ex);
                }
            }

            return Resultado;

        }

        public ENCotizacionSalud GetCotizacionSaludCabecera(int idCotizacion)
        {
            ENCotizacionSalud beCotizacion = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACotizacionSalud odaCotizacion = new DACotizacionSalud();
                    beCotizacion = odaCotizacion.GetCotizacionSaludCabecera(con, idCotizacion);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }

                return beCotizacion;
            }
        }

        //Admin 
        public List<ENCotizacionSalud> GetCotizacionesSaludDashboard()
        {
            List<ENCotizacionSalud> lbeCotizaciones = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACotizacionSalud odCotizacion = new DACotizacionSalud();
                    lbeCotizaciones = odCotizacion.GetCotizacionesSaludDashboard(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeCotizaciones;
        }
        public List<ENCotizacionSalud> GetCotizacionesSaludDashboardFiltro(string FechaInicio, string FechaFin)
        {
            List<ENCotizacionSalud> lbeCotizaciones = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACotizacionSalud odCotizacion = new DACotizacionSalud();
                    lbeCotizaciones = odCotizacion.GetCotizacionesSaludDashboardFiltro(con, FechaInicio,FechaFin);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeCotizaciones;
        }

    }
}
