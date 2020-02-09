using System;


namespace Entidades.Digitalbrokers
{
    public class ENSolicitudComunicacion
    {
        public int idSolicitud { get; set; }
        public int intTipoSolicitud { get; set; }
        public string Nombres { get; set; }
        public string EmailSolicitante { get; set; }
        public string TelefonoSolicitante { get; set; }
        public string httpResponseUri { get; set; }
        public string dtmFechaSolicitud { get; set; }

    }
}
