using System;

namespace Entidades.Digitalbrokers
{
    public class ENCotizacionDetalle
    {
        public int idCotizacion { get; set; }
        public decimal Prima_Rimac { get; set; }
        public decimal Prima_Pacifico { get; set; }
        public decimal Prima_Mafre { get; set; }
        public decimal Prima_LaPositiva { get; set; }
        public decimal Prima_HDI { get; set; }
        public string GPS_Rimac{ get; set; }
        public string GPS_Pacifico { get; set; }
        public string GPS_Mafre { get; set; }
        public string GPS_LaPositiva { get; set; }
        public string GPS_HDI { get; set; }
    }
}
