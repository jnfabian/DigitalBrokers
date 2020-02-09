using System;


namespace Entidades.Digitalbrokers
{
    public class ENSolicitudCotizacion
    {
        public int idCotizacion { get; set; }
        public int idMarca { get; set; }
        public int idModelo { get; set; }
        public string Desccripcion_Marca { get; set; }
        public string Anio { get; set; }
        public decimal valorReferencial { get; set; }
        public string UsoVehiculo { get; set; }
        public string Descripcion_Modelo { get; set; }
        public string EmailSolicitante { get; set; }
        public string TelefonoSolicitante { get; set; }
        public DateTime dtmFechaSolicitud{ get; set; }
        public string httpResponseURLEncode { get; set; }
        

    }
}
