using System;


namespace Entidades.Digitalbrokers
{
    public class ENAseguradoraTasas
    {
        public int idCorrelativo { get; set; }
        public int idAseguradora { get; set; }
        public string DescAseguradora { get; set; }
        public string Clasificacion { get; set; }
        public string Provincia { get; set; }
        public string Anio { get; set; }
        public decimal Tasa { get; set; }
        public decimal Tasa_Provincia { get; set; }
        public string Estado { get; set; }

    }
}
