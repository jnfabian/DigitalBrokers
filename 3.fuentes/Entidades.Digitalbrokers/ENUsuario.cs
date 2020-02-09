using System;


namespace Entidades.Digitalbrokers
{
    public class ENUsuario
    {
        public int idUsuario { get; set; }
        public string  vchEmail { get; set; }
        public string vchNombres { get; set; }
        public string vchPassword { get; set; }
        public string vchImagen { get; set; }
        public string chrEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
