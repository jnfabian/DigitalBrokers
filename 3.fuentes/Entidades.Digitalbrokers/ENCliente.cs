using System;


namespace Entidades.Digitalbrokers
{
    public class ENCliente
    {
        public int idCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string DNI { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int idCotizacion { get; set; }
        public int idAseguradora { get; set; }
    }
}
