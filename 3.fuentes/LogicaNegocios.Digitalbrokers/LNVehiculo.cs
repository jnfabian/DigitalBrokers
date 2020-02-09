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
    public class LNVehiculo:BRGeneral
    {
        //Administrador
        public List<ENVehiculo> GetvehiculosListadoMarca(int idMarca, int idAnio)
        {
            List<ENVehiculo> lbevehiculos = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAVehiculo odVehiculos = new DAVehiculo();
                    lbevehiculos = odVehiculos.GetvehiculosListadoMarca(con, idMarca, idAnio);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbevehiculos;
        }

        public ENVehiculoCompleto GetVehiculo(int idMarca, int idModelo, int Anio)
        {
            ENVehiculoCompleto beVehiculo = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DAVehiculo odaVehiculo = new DAVehiculo();
                    beVehiculo = odaVehiculo.GetVehiculo(con, idMarca,idModelo,Anio);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }

                return beVehiculo;
            }
        }

        //Actualizacion Vehicular
        public int SaveVehiculo_TRANS(ENVehiculoCompleto oVehiculo)
        {

            DAVehiculo data = new DAVehiculo();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveVehiculo_TRANS(con,oVehiculo);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }

            return Resultado;

        }

        //Agregar vehiculo
        public int SaveNewVehiculo_TRANS(ENVehiculoCompleto oVehiculo)
        {

            DAVehiculo data = new DAVehiculo();
            int Resultado = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    Resultado = data.SaveNewVehiculo_TRANS(con, oVehiculo);
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
