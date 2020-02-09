using System;

namespace Entidades.Digitalbrokers
{
    public class ENCotizacion
    {
        public int idCotizacion { get; set; }
        public int idMarca { get; set; }
        public int idModelo { get; set; }
        public string Anio { get; set; }
        public decimal ValorReferencial { get; set; }
        public string UsoVehiculo { get; set; }
        public string Descripcion_Modelo { get; set; }
        public string Mail_Cliente { get; set; }
        public string TelefonoCliente { get; set; }

        //MOdificacion para deducibles
        public string RIMAC_Categoria { get; set; }
        public string POSITIVA_Categoria { get; set; }
        public string PACIFICO_Categoria { get; set; }
        public string MAPFRE_Categoria { get; set; }
        public string HDI_Categoria { get; set; }
        public DateTime  FechaCreacion{ get; set; }


    }
}
