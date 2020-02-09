using System;

namespace Entidades.Digitalbrokers
{
    public class ENCobertura
    {
        public int idCobertura { get; set; }
        public int idCoberturaTipo { get; set; }
        public int idAseguradora { get; set; }
        public string Descripcion { get; set; }
        public string ValorConvenio { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class ENCoberturaSalud
    {
        //idCoberturaSalud, idAseguradora, Descripcion, Valor, Estado, FechaCreacion
        public int idCoberturaSalud { get; set; }
        public int idAseguradora { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
