using System;

namespace Entidades.Digitalbrokers
{
   public  class ENCompras
    {
        public int idCompra { get; set; }
        public int idCotizacion { get; set; }
        public int idCliente { get; set; }
        public int idAseguradora { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Estado { get; set; }
    }

   public class ENCompraDesc
   {
       public int idCompra { get; set; }
       public int idCotizacion { get; set; }
       public string Nombres { get; set; }
       public string Apellido_Paterno { get; set; }
       public string Apellido_Materno { get; set; }
       public string DNI { get; set; }
       public string Telefono { get; set; }
       public string Domicilio { get; set; }
       public string Seguro { get; set; }
       public DateTime FechaCompra { get; set; }
       public string Estado { get; set; }
   }
}
