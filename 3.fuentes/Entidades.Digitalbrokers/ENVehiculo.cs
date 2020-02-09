using System;


namespace Entidades.Digitalbrokers
{
    public class ENVehiculo
    {
        public int idMarca { get; set; }
        public string Marca { get; set; }
        public int idModelo { get; set; }
        public string Descripcion_Modelo { get; set; }
        public string Carroceria { get; set; }
        public string Puertas { get; set; }
        public string Asientos { get; set; }
        public string Traccion { get; set; }
        public string Desplazamiento { get; set; }
        public string Potencia { get; set; }
        public string Carburante { get; set; }
        public decimal VRN { get; set; }
        public decimal PrecioAnio { get; set; }

    }

    public class ENVehiculoCompleto
    {
        public int idMarca { get; set; }

        public string Marca { get; set; }

        public int idModelo { get; set; }

        public string Descripcion_Modelo { get; set; }

        public string Carroceria { get; set; }

        public string Puertas { get; set; }

        public string Asientos { get; set; }

        public string Traccion { get; set; }

        public string Desplazamiento { get; set; }

        public string Potencia { get; set; }

        public string Carburante { get; set; }

        public Decimal VRN { get; set; }

        public Decimal PrecioAnio { get; set; }

        public string Anio { get; set; }

        public string Clasificacion_LaPositiva { get; set; }

        public string Clasificacion_Mapfre { get; set; }

        public string Clasificacion_Pacifico { get; set; }

        public string Clasificacion_Rimac { get; set; }

        public string Clasificacion_HDI { get; set; }

        public string GPS_LaPositiva { get; set; }

        public string GPS_Mapfre { get; set; }

        public string GPS_Pacifico { get; set; }

        public string GPS_Rimac { get; set; }

        public string GPS_HDI { get; set; }
        public Decimal P2018 { get; set; }
        public Decimal P2017 { get; set; }

        public Decimal P2016 { get; set; }

        public Decimal P2015 { get; set; }

        public Decimal P2014 { get; set; }

        public Decimal P2013 { get; set; }

        public Decimal P2012 { get; set; }

        public Decimal P2011 { get; set; }

        public Decimal P2010 { get; set; }
    }
}
