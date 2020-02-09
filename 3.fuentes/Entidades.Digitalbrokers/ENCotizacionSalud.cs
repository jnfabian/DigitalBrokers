using System;


namespace Entidades.Digitalbrokers
{
    public class ENCotizacionSalud
    {
        public int idCotizacionSalud { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaSolicitud { get; set; }

    }
}
