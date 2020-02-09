using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using AccesoDatos.Digitalbrokers;
using Entidades.Digitalbrokers;
using System.Data.SqlClient;
using System.Windows.Media;
using System.Globalization;
using System.Configuration;

//LIBRERIAS PARA USO DE PDF
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf.draw;



namespace LogicaNegocios.Digitalbrokers
{
    public class LNCotizacion:BRGeneral
    {
        static double dPixelMM = 2.88;
        public ENCotizacion GetCotizacionCabecera(int idCotizacion)
        {
            ENCotizacion beCotizacion = null;

            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACotizacion odaCotizacion = new DACotizacion();
                    beCotizacion = odaCotizacion.GetCotizacionCabecera(con, idCotizacion);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }

                return beCotizacion;
            }
        }

        //Admin
        public List<ENCotizacion> GetCotizacionesDashboard()
        {
            List<ENCotizacion> lbeCotizaciones = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACotizacion odCotizacion = new DACotizacion();
                    lbeCotizaciones = odCotizacion.GetCotizacionesDashboard(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeCotizaciones;
        }

        public List<ENCotizacion> GetCotizacionesDashboardFiltro(string FechaInicio, string FechaFin)
        {
            List<ENCotizacion> lbeCotizaciones = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    DACotizacion odCotizacion = new DACotizacion();
                    lbeCotizaciones = odCotizacion.GetCotizacionesDashboardFiltro(con, FechaInicio, FechaFin);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lbeCotizaciones;
        }

        //PROCESO DE GENERACION DE COTIZACIÓN EN SERVIDOR. ARCHIVO PDF
        public void GenerarCotizacionPDF(int intCodigo)
        {
            try
            {
                //OBTENER DATOS DE COTIZACION
                string strCaracter = "0";
                ENCotizacion oCotizacion = GetCotizacionCabecera(intCodigo);
                string strCliente = oCotizacion.Mail_Cliente.ToString().Trim();
                string strOrdenCotizacion = oCotizacion.idCotizacion.ToString().PadLeft(10, strCaracter[0]);
                string strCelular = oCotizacion.TelefonoCliente.ToString();
                string strVehiculo = oCotizacion.Descripcion_Modelo.ToString();
                string strAno = oCotizacion.Anio.ToString();
                string strValor = "USD$" + oCotizacion.ValorReferencial.ToString();



                //Desarrollo
                //string strRutaCotizacion = @"F:\DigitalBrokers\PDF\COT-" + oCotizacion.idCotizacion + ".pdf";

                //Produccion
                //string strRutaCotizacion = @"G:/PleskVhosts/digitalbrokers.pe/app.digitalbrokers.pe/Cotizaciones/PDF/COT-" + oCotizacion.idCotizacion + ".pdf";
                //cambio fabian
                string strRutaCotizacion = @"D:/trabajo/ROBERTO/2_Web.DigitalBrokers/Web.DigitalBrokers/Web.DigitalBrokers/Cotizaciones/PDF/COT-" + oCotizacion.idCotizacion + ".pdf";

                //if (!Directory.Exists(RutaCotizacion + strFechaArchivo))
                //    Directory.CreateDirectory(RutaCotizacion + strFechaArchivo);

                //Obtener Detalle de Cotizacion y Articulos
                LNCotizacionDetalle olnCotizacionDetalle = new LNCotizacionDetalle();
                ENCotizacionDetalle obeCotizacionDetalle = olnCotizacionDetalle.GetCotizacionDetalle(intCodigo);

                //OBTENER DATOS DE DETALLE DE COTIZACION
                string strRimacPrecio = "USD$" + obeCotizacionDetalle.Prima_Rimac.ToString().Trim();
                string strMapfrePrecio = "USD$" + obeCotizacionDetalle.Prima_Mafre.ToString().Trim();
                string strPositivaPrecio = "USD$" + obeCotizacionDetalle.Prima_LaPositiva.ToString().Trim();
                string strPacificoPrecio = "USD$" + obeCotizacionDetalle.Prima_Pacifico.ToString().Trim();
               
                string strHDIPrecio = "USD$" + obeCotizacionDetalle.Prima_HDI.ToString().Trim();
                if (obeCotizacionDetalle.Prima_HDI == 0) { strHDIPrecio = "CONSULTAR"; }

                //REQUIERE USO DE GPS
                string strGPSRimac = obeCotizacionDetalle.GPS_Rimac.ToString().Trim();
                string strGPSMapfre = obeCotizacionDetalle.GPS_Mafre.ToString().Trim();
                string strGPSPositiva = obeCotizacionDetalle.GPS_LaPositiva.ToString().Trim();
                string strGPSPacifico = obeCotizacionDetalle.GPS_Pacifico.ToString().Trim();
                string strGPSHDI = obeCotizacionDetalle.GPS_HDI.ToString().Trim();


                //ARMAR PDF DE COTIZACION
                //iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
                Document doc = new Document(PageSize.A4);
                //PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(strRutaCotizacion, FileMode.Create));
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(strRutaCotizacion, FileMode.OpenOrCreate));
                doc.Open();

                //string fontpath = ConfigurationManager.AppSettings["RUTA_FONTS"];
                //FontFactory.RegisterDirectory(fontpath);

                doc.NewPage();

                //IMAGEN DESARROLLO
                //System.Drawing.Bitmap logo = new System.Drawing.Bitmap(@"F:\DigitalBrokers\logo\logodb.jpg");

                //IMAGEN PRODUCCION
                //System.Drawing.Bitmap logo = new System.Drawing.Bitmap(@"G:/PleskVhosts/digitalbrokers.pe/Documentos/logodb.jpg");
                System.Drawing.Bitmap logo = new System.Drawing.Bitmap(@"D:/trabajo/ROBERTO/2_Web.DigitalBrokers/Web.DigitalBrokers/Web.DigitalBrokers/documentos/logodb.jpg");
            

                System.Drawing.ImageConverter imgcon = new System.Drawing.ImageConverter();
                byte[] bytelogo = (byte[])imgcon.ConvertTo(logo, typeof(byte[]));
                iImage(doc, writer, 10, 7, 56, 20, 0, bytelogo);

                iTexto(doc, writer, 10, 28, 123, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", "DIGITAL BROKERS S.A.C. - CORREDORES DE SEGUROS");
                iTexto(doc, writer, 10, 33, 123, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "DOM.FISCAL: " + "AV. AREQUIPA 2450 - OFICINA 1205, LINCE. LIMA-PE");
                iTexto(doc, writer, 10, 37, 103, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "RUC: " + "20601943493 ");
                iTexto(doc, writer, 10, 41, 103, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "TELEFONO: " + " PERÚ(01) 759-7746");

                //RECTANGULO DERECHO
                iRectangle(doc, writer, 145, 15, 50, 29, 0, 0, 1);
                //iRectangle(doc, writer, 115, 15, 82, 29, 0, 0, 2); 82 es el ancho del cuadrado   29= alto del cuadrado
                iTexto(doc, writer, 145, 18, 50, 6, 0, (int)TextAlignment.Center, "ARIAL", 15, "Bold", "Normal", "#000000", "COTIZACIÓN");
                //if (oCotizacion.decMontoRecargo > 0)
                //    iTexto(doc, writer, 115, 26, 82, 6, 0, (int)TextAlignment.Center, "ARIAL", 15, "Bold", "Normal", "#000000", "URGENTE (24 HORAS)");
                //else
                //    iTexto(doc, writer, 115, 26, 82, 6, 0, (int)TextAlignment.Center, "ARIAL", 15, "Bold", "Normal", "#000000", "NORMAL (48 HORAS)");
                iTexto(doc, writer, 145, 35, 50, 6, 0, (int)TextAlignment.Center, "ARIAL", 15, "Bold", "Normal", "#000000", strOrdenCotizacion);

                //RECTANGULO IZQUIERDA
                iRectangle(doc, writer, 10, 50, 104, 26, 0, 4, 1);
                iTexto(doc, writer, 11, 51, 16, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "SEÑOR(ES)");
                iTexto(doc, writer, 28, 51, 75, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", ": " + strCliente);
                iTexto(doc, writer, 11, 58, 16, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "N° CEL");
                iTexto(doc, writer, 28, 58, 75, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", ": " + strCelular);
                iTexto(doc, writer, 11, 65, 16, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "VEHICULO");
                iTexto(doc, writer, 28, 65, 75, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", ": " + strVehiculo);
                //iTexto(doc, writer, 11, 72, 16, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "LOCALIDAD");
                //iTexto(doc, writer, 28, 72, 75, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", ": " + strLocalidad);

                //RECTANGULO DERECHA
                iRectangle(doc, writer, 115, 50, 82, 26, 0, 4, 1);
                iTexto(doc, writer, 116, 51, 20, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "USO");
                iTexto(doc, writer, 137, 51, 20, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", ": PARTICULAR" );
                iTexto(doc, writer, 116, 58, 20, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "AÑO");
                iTexto(doc, writer, 137, 58, 18, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", ": " + strAno);
                iTexto(doc, writer, 116, 65, 20, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", "SUMA ASE");
                iTexto(doc, writer, 137,65, 40, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Bold", "Normal", "#000000", ": " + strValor.Trim());

                //iTexto(doc, writer, 150, 51, 24, 3, 0, (int)TextAlignment.Right, "ARIAL", 8, "Normal", "Normal", "#000000", "FECHA:");
                //iTexto(doc, writer, 175, 51, 21, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", strFecha);
                //iTexto(doc, writer, 150, 58, 24, 3, 0, (int)TextAlignment.Right, "ARIAL", 8, "Normal", "Normal", "#000000", "PTO. VENTA:");
                //iTexto(doc, writer, 175, 58, 21, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", strPuntoVenta);
                //iTexto(doc, writer, 150, 65, 24, 3, 0, (int)TextAlignment.Right, "ARIAL", 8, "Normal", "Normal", "#000000", "OP:");
                //iTexto(doc, writer, 175, 65, 21, 3, 0, (int)TextAlignment.Left, "ARIAL", 8, "Normal", "Normal", "#000000", strIdOrden);

                //RECTANGULO DETALLE
                //iRectangle(doc, writer, 10, 79, 187, 165, 0, 4, 1); EL ORIGINAL 
                iRectangle(doc, writer, 10, 79, 187, 40, 0, 4, 1); 
                iRectangle(doc, writer, 10, 84, 187, 0, 0, 0, 0.5);

                iTexto(doc, writer, 11, 80, 05, 3, 0, (int)TextAlignment.Right, "ARIAL", 7, "Bold", "Normal", "#000000", "#");
                iTexto(doc, writer, 17, 80, 92, 3, 0, (int)TextAlignment.Left, "ARIAL", 7, "Bold", "Normal", "#000000", "RIMAC");
                iTexto(doc, writer, 69, 80, 30, 3, 0, (int)TextAlignment.Left, "ARIAL", 7, "Bold", "Normal", "#000000", "MAPFRE");
                iTexto(doc, writer, 110, 80, 39, 3, 0, (int)TextAlignment.Left, "ARIAL", 7, "Bold", "Normal", "#000000", "LA POSITIVA");
                iTexto(doc, writer, 147, 80, 17, 3, 0, (int)TextAlignment.Right, "ARIAL", 7, "Bold", "Normal", "#000000", "PACIFICO");
                iTexto(doc, writer, 174, 80, 17, 3, 0, (int)TextAlignment.Right, "ARIAL", 7, "Bold", "Normal", "#000000", "HDI");

                int intItem = 1;
                double y = 89;// inicio desde la ultima posicion
                double gps = 95;// linea debajo de los precios

                //AGREGANDO EL DETALLE DE LOS PRECIO A CADA UNA DE LAS COMPANIAS
                iTexto(doc, writer, 17, y, 92, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", strRimacPrecio);
                iTexto(doc, writer, 69, y, 120, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", strMapfrePrecio);
                iTexto(doc, writer, 110, y, 135, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", strPositivaPrecio);
                iTexto(doc, writer, 147, y, 17, 3, 0, (int)TextAlignment.Right, "ARIAL", 9, "Bold", "Normal", "#000000", strPacificoPrecio);
                iTexto(doc, writer, 174, y, 17, 3, 0, (int)TextAlignment.Right, "ARIAL", 9, "Bold", "Normal", "#000000", strHDIPrecio);

                //AGREGANDO EL USO DE GPS POR COMPAÑIA
                iTexto(doc, writer, 17, gps, 92, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", "GPS: " + strGPSRimac);
                iTexto(doc, writer, 69, gps, 120, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", "GPS: " + strGPSMapfre);
                iTexto(doc, writer, 110, gps, 135, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", "GPS: " + strGPSPositiva);
                iTexto(doc, writer, 147, gps, 17, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", "GPS: " + strGPSPacifico);
                iTexto(doc, writer, 174, gps, 17, 3, 0, (int)TextAlignment.Left, "ARIAL", 9, "Bold", "Normal", "#000000", "GPS: " + strGPSHDI);



                //foreach (var Articulo in lbeCotizacionDetalleCliente)
                //{
                //    iTexto(doc, writer, 11, y, 05, 3, 0, (int)TextAlignment.Right, "ARIAL", 7, "Normal", "Normal", "#000000", intItem.ToString());
                //    iTexto(doc, writer, 17, y, 92, 3, 0, (int)TextAlignment.Left, "ARIAL", 7, "Normal", "Normal", "#000000", Articulo.vchDescripcionArticulo.Trim());
                //    iTexto(doc, writer, 81, y, 30, 3, 0, (int)TextAlignment.Left, "ARIAL", 7, "Normal", "Normal", "#000000", Articulo.intAlto.ToString("#0") + "CM * " + Articulo.intAncho.ToString("#0") + "COL");
                //    iTexto(doc, writer, 120, y, 39, 3, 0, (int)TextAlignment.Left, "ARIAL", 7, "Normal", "Normal", "#000000", Articulo.vchFechaPublicacion);
                //    iTexto(doc, writer, 147, y, 17, 3, 0, (int)TextAlignment.Right, "ARIAL", 7, "Normal", "Normal", "#000000", Articulo.decPrecioUnitario.ToString("#,##0.00###"));
                //    iTexto(doc, writer, 179, y, 17, 3, 0, (int)TextAlignment.Right, "ARIAL", 7, "Normal", "Normal", "#000000", Articulo.decMontoNeto.ToString("#,##0.00"));
                //    y = y + (3.5);
                //    if (oCotizacion.decMontoRecargo > 0)
                //    {
                //        iTexto(doc, writer, 17, y, 50, 3, 0, (int)TextAlignment.Left, "ARIAL", 7, "Normal", "Normal", "#000000", "Recargo");
                //        iTexto(doc, writer, 179, y, 17, 3, 0, (int)TextAlignment.Right, "ARIAL", 7, "Normal", "Normal", "#000000", Articulo.decMontoRecargo.ToString("#,##0.00###"));
                //        y = y + 3.5;
                //    }
                //    intItem++;
                //}


                //AGREGAR LOS BENEFICIOS Y COBERTURAS EN UNA IMAGEN
                //IMAGEN SLIP DESARROLLO
                //System.Drawing.Bitmap imagenCoberturas = new System.Drawing.Bitmap(@"F:\DigitalBrokers\Beneficios\Particular.jpg");

                //INICIO IMAGEN SLIP PRODUCCION DE ACUERDO AL TIPO
                //System.Drawing.Bitmap imagenCoberturas = null;
                //if (oCotizacion.UsoVehiculo == "PARTICULAR") {imagenCoberturas = new System.Drawing.Bitmap(@"G:/PleskVhosts/digitalbrokers.pe/Documentos/Beneficios/Particular.jpg"); }
                //if (oCotizacion.UsoVehiculo == "CHINOS") { imagenCoberturas = new System.Drawing.Bitmap(@"G:/PleskVhosts/digitalbrokers.pe/Documentos/Beneficios/Chinos.jpg"); }
                //if (oCotizacion.UsoVehiculo == "PICK UP") { imagenCoberturas = new System.Drawing.Bitmap(@"G:/PleskVhosts/digitalbrokers.pe/Documentos/Beneficios/PickUp.jpg"); }
                //if (oCotizacion.UsoVehiculo == "CHINOS PICK UP") { imagenCoberturas = new System.Drawing.Bitmap(@"G:/PleskVhosts/digitalbrokers.pe/Documentos/Beneficios/chinos.jpg"); }
                //cambio fabian
                System.Drawing.Bitmap imagenCoberturas = null;
                if (oCotizacion.UsoVehiculo == "PARTICULAR") { imagenCoberturas = new System.Drawing.Bitmap(@"D:/trabajo/ROBERTO/2_Web.DigitalBrokers/Web.DigitalBrokers/Web.DigitalBrokers/documentos/Beneficios/Particular.jpg"); }
                if (oCotizacion.UsoVehiculo == "CHINOS") { imagenCoberturas = new System.Drawing.Bitmap(@"D:/trabajo/ROBERTO/2_Web.DigitalBrokers/Web.DigitalBrokers/Web.DigitalBrokers/documentos/Beneficios/Chinos.jpg"); }
                if (oCotizacion.UsoVehiculo == "PICK UP") { imagenCoberturas = new System.Drawing.Bitmap(@"D:/trabajo/ROBERTO/2_Web.DigitalBrokers/Web.DigitalBrokers/Web.DigitalBrokers/documentos/Beneficios/PickUp.jpg"); }
                if (oCotizacion.UsoVehiculo == "CHINOS PICK UP") { imagenCoberturas = new System.Drawing.Bitmap(@"D:/trabajo/ROBERTO/2_Web.DigitalBrokers/Web.DigitalBrokers/Web.DigitalBrokers/documentos/Beneficios/chinos.jpg"); }


                System.Drawing.ImageConverter img2con = new System.Drawing.ImageConverter();
                byte[] byteImagen = (byte[])img2con.ConvertTo(imagenCoberturas, typeof(byte[]));
                iImage(doc, writer, 10, 120, 189, 100, 0, byteImagen);

                //FIN IMAGEN SLIP PRODUCCION DE ACUERDO AL TIPO

                //INICIO IMAGEN PROMOCIONAL DIGITAL BROKERS
                System.Drawing.Bitmap imgPublicidad = null;
                imgPublicidad = new System.Drawing.Bitmap(@"D:/trabajo/ROBERTO/2_Web.DigitalBrokers/Web.DigitalBrokers/Web.DigitalBrokers/documentos/Beneficios/Publicidad_GEN.jpg");

                System.Drawing.ImageConverter imgPublicidadAdd = new System.Drawing.ImageConverter();
                byte[] byteImagenPub = (byte[])imgPublicidadAdd.ConvertTo(imgPublicidad, typeof(byte[]));
                iImage(doc, writer, 10, 222, 189, 20, 0, byteImagenPub);
                //FIN IMAGEN PROMOCIONAL DIGITAL BROKERS

                
                
                
                //RECTANGULO ABAJO CONSOLIDADO
                iRectangle(doc, writer, 10, 245, 187, 30, 0, 4, 1);
                //Linea vertical
                iRectangle(doc, writer, 145, 245, 0, 30, 0, 0, 0.5);
                //Lineas horizontales
                iRectangle(doc, writer, 145, 255, 52, 0, 0, 0, 0.5);
                iRectangle(doc, writer, 145, 265, 52, 0, 0, 0, 0.5);

                //iTexto(doc, writer, 149, 248, 27, 4, 0, (int)TextAlignment.Right, "ARIAL", 9, "Bold", "Normal", "#000000", "SUBTOTAL S/");
                //iTexto(doc, writer, 180, 248, 16, 4, 0, (int)TextAlignment.Right, "ARIAL", 9, "Bold", "Normal", "#000000", strSubTotal);
                //iTexto(doc, writer, 149, 258, 27, 4, 0, (int)TextAlignment.Right, "ARIAL", 9, "Bold", "Normal", "#000000", "I.G.V. (18% ) S/");
                //iTexto(doc, writer, 180, 258, 16, 4, 0, (int)TextAlignment.Right, "ARIAL", 9, "Bold", "Normal", "#000000", strIgv);
                //iTexto(doc, writer, 149, 268, 27, 4, 0, (int)TextAlignment.Right, "ARIAL", 9, "Bold", "Normal", "#000000", "TOTAL S/");
                //iTexto(doc, writer, 180, 268, 16, 4, 0, (int)TextAlignment.Right, "ARIAL", 9, "Bold", "Normal", "#000000", strTotal);

                //TEXTO DE COTIZACION
                iTexto(doc, writer, 13, 251, 180, 3, 0, (int)TextAlignment.Left, "ARIAL", 12, "Bold", "Normal", "#000000", "Esta cotización tiene una vigencia de 7 días calendario");

                doc.Close();
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public static void iRectangle(Document document, PdfWriter writer, double x, double y, double w, double h, int iAngle, int r, double iborder, string vFontForeground = "#00000000")
        {
            x = x * dPixelMM;
            y = y * dPixelMM;
            h = h * dPixelMM;
            w = w * dPixelMM;

            y = PageSize.A4.Height - y - h;//y=pos y del contenedor, h = height contenedor, hc = heigh del objeto
            double hh = 0;
            double ww = 0;
            switch (iAngle)
            {
                case 0:
                case 180:
                    hh = h;
                    ww = w;
                    break;
                case 90:
                case 270:
                    hh = w;
                    ww = h;
                    break;
            }
            PdfContentByte cb = writer.DirectContent;
            cb.SetLineWidth((float)iborder);
            cb.RoundRectangle((float)x, (float)y, (float)ww, (float)hh, r);
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(vFontForeground);
            cb.SetRGBColorStroke(c.R, c.G, c.B);
            cb.Stroke();
        }

        public static int iTexto(Document document, PdfWriter writer, double x, double y, double w, double h, int iAngle, int iTextAlignment,
                    string vFontFamily, double dFontSize, string vFontWeight, string vFontStyle, string vFontForeground, string vData)
        {
            if (string.IsNullOrEmpty(vData))
                vData = "";

            x = x * dPixelMM;
            y = y * dPixelMM;
            h = h * dPixelMM;
            w = w * dPixelMM;

            y = PageSize.A4.Height - y - h;//y=pos y del contenedor, h = height contenedor, hc = heigh del objeto

            PdfContentByte cb = writer.DirectContent;
            int iStyle = iTextSharp.text.Font.NORMAL;
            if ((vFontStyle != "Normal" && vFontWeight != "Normal")) iStyle = iTextSharp.text.Font.BOLDITALIC;
            if ((vFontStyle == "Normal" && vFontWeight != "Normal")) iStyle = iTextSharp.text.Font.BOLD;
            if ((vFontStyle != "Normal" && vFontWeight == "Normal")) iStyle = iTextSharp.text.Font.ITALIC;
            if ((vFontStyle == "Normal" && vFontWeight == "Normal")) iStyle = iTextSharp.text.Font.NORMAL;

            Font oFont;
            System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml(vFontForeground);
            oFont = FontFactory.GetFont(vFontFamily, (float)dFontSize, iStyle, new BaseColor(c));


            double dCon = dFontSize * 18 / 100;

            int iPDFTextAlig = 0;

            switch (iTextAlignment)
            {
                case 2://CENTER
                    iPDFTextAlig = PdfContentByte.ALIGN_CENTER;
                    break;
                case 0://lEFT
                    iPDFTextAlig = PdfContentByte.ALIGN_LEFT;
                    break;
                case 1://RIGHT
                    iPDFTextAlig = PdfContentByte.ALIGN_RIGHT;
                    break;
                default://DEFECTO LEFT
                    iPDFTextAlig = PdfContentByte.ALIGN_LEFT;
                    break;
            }
            #region grados
            //0 Grados
            if (iAngle == 0 && iTextAlignment == 2)//CENTER
            {
                y = y + 0 + dCon;
                x = x + (w / 2);
            }
            if (iAngle == 0 && iTextAlignment == 0)//lEFT
            {
                y = y + 0 + dCon;
                x = x + 0;
            }
            if (iAngle == 0 && iTextAlignment == 1)//RIGHT
            {
                y = y + 0 + dCon;
                x = x + w;
            }
            //180 Grados
            if (iAngle == 180 && iTextAlignment == 2)//CENTER
            {
                y = y + h - dCon;
                x = x + (w / 2);
            }
            if (iAngle == 180 && iTextAlignment == 0)//lEFT
            {
                y = y + h - dCon;
                x = x + w;
            }
            if (iAngle == 180 && iTextAlignment == 1)//RIGHT
            {
                y = y + h - dCon;
                x = x + 0;
            }
            //90 Grados
            if (iAngle == 90 && iTextAlignment == 2)//CENTER
            {
                y = y + (w / 2);
                x = x + h - dCon;
            }
            if (iAngle == 90 && iTextAlignment == 0)//lEFT
            {
                y = y + 0;
                x = x + h - dCon;
            }
            if (iAngle == 90 && iTextAlignment == 1)//RIGHT
            {
                y = y + w;
                x = x + h - dCon;
            }
            //270 Grados
            if (iAngle == 270 && iTextAlignment == 2)//CENTER
            {
                y = y + (w / 2);
                x = x + 0;
            }
            if (iAngle == 270 && iTextAlignment == 0)//lEFT
            {
                y = y + w;
                x = x + 0 + dCon;
            }
            if (iAngle == 270 && iTextAlignment == 1)//RIGHT
            {
                y = y + 0;
                x = x + 0 + dCon;
            }
            #endregion

            List<string> palabras = new List<string>();


            palabras = new List<string>();
            List<string> listTextos = new List<string>();

            foreach (string str in vData.Split(' '))
            {
                if (str.Trim() != string.Empty)
                {
                    listTextos.Add(str);
                }
            }


            while (listTextos.Count() > 0)
            {
                for (int i = listTextos.Count() - 1; i >= 0; i--)
                {
                    string vGeneratedText = string.Empty;
                    for (int j = 0; j <= i; j++)
                    {
                        vGeneratedText += listTextos[j] + " ";
                    }
                    double dtextWidth = GetTextWidth(vGeneratedText, dFontSize, vFontFamily, vFontStyle, vFontWeight);

                    if (dtextWidth <= w || listTextos.Count == 1)
                    {
                        palabras.Add(vGeneratedText.Trim());
                        for (int k = i; k >= 0; k--)
                        {
                            listTextos.RemoveAt(k);
                        }
                        break;
                    }
                }

                // aqui hacer la logica de salto de linea
            }

            if (palabras.Count > 1)
            {
                for (int i = 0; i < palabras.Count; i++)
                {

                    Phrase phrase = new Phrase(new Chunk(palabras[i], oFont));
                    ColumnText.ShowTextAligned(cb, (int)iPDFTextAlig, phrase, (float)x, (float)y, iAngle);


                    if (iAngle == 0)//CENTER
                    {
                        y -= h;
                    }
                    else if (iAngle == 180)//CENTER
                    {
                        y += h;
                    }
                    else if (iAngle == 90)//CENTER
                    {
                        x += h;
                    }
                    else if (iAngle == 270)//CENTER
                    {
                        x -= h;
                    }

                }
            }
            else
            {
                Phrase phrase = new Phrase(new Chunk(vData, oFont));
                ColumnText.ShowTextAligned(cb, (int)iPDFTextAlig, phrase, (float)x, (float)y, iAngle);
            }
            return palabras.Count;

        }

        static private double GetTextWidth(string text, double fontSize, string fonFamily, string fontStyle, string vFontWeight)
        {
            FontStyle oFontStyle;

            if (fontStyle == "Normal")
                oFontStyle = FontStyles.Normal;
            else
                oFontStyle = FontStyles.Italic;

            FontWeight oFontWeight;

            if (vFontWeight == "Normal")
                oFontWeight = FontWeights.Normal;
            else
                oFontWeight = FontWeights.Bold;

            FontFamily oFontFamily = new FontFamily(fonFamily);

            FormattedText oFormattedText = new FormattedText(text, CultureInfo.CurrentUICulture, FlowDirection.LeftToRight,
            new Typeface(oFontFamily, oFontStyle, oFontWeight, FontStretches.Normal), fontSize, Brushes.Black);

            double width = oFormattedText.Width;

            return width;
        }

        public static void iImage(Document document, PdfWriter writer, double x, double y, double w, double h, int iAngle, byte[] bImage)
        {
            x = x * dPixelMM;
            y = y * dPixelMM;
            h = h * dPixelMM;
            w = w * dPixelMM;

            y = PageSize.A4.Height - y - h;//y=pos y del contenedor, h = height contenedor, hc = heigh del objeto
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bImage);
            img.ScaleAbsolute((float)w, (float)h);
            img.SetAbsolutePosition((float)x, (float)y);
            img.RotationDegrees = iAngle;
            document.Add(img);
        }
        
    }
}
