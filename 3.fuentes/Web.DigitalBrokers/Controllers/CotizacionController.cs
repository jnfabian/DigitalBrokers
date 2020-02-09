using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;
using General.Librerias.CodigoUsuario;
using Web.DigitalBrokers.Seguridad;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text;

namespace Web.DigitalBrokers.Controllers
{
    public class CotizacionController : Controller
    {
        // GET: Cotizacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerarCotizacion()
        {
           
            return View();
        }
        public ActionResult MiCotizacion(string id)
        {
            try
            {
                //string CadenaDesencryptada = CryptorEngine.Decrypt(id, true);

                //Char delimiter = '@';
                //String[] substrings = CadenaDesencryptada.Split(delimiter);
                //string CodigoCotizacion = substrings[1].ToString();
                string CodigoCotizacion = CryptorEngine.Decrypt(id, true);
                ViewBag.idCotizacion = CodigoCotizacion;
                ViewBag.LinkDescarga = id;
                return View();
            }

            catch (Exception)
            {
                //EN El caso de Manipulacion de la Cadena Simplemente Mandamos a Cotizar por Pendejos
                //return RedirectToAction("Index","Vehicular");
                return RedirectToAction("Index", "Vehicular");
            }
            //Falta el tema Aregar a la cadena un Substring para Capturar Solo el Codigo
           
        }
             
        //SOLICITUD DE COTIZACION VEHICULAR
        public JsonResult SolicitudCotizacionVehicular(ENSolicitudComunicacion oSolicitud)
        {

            try
            {
                int intRes = 0;
                //Solicitud de Cotizacion
                LNSolicitudCotizacion oLNSolicitudCotizacion = new LNSolicitudCotizacion();
                intRes = oLNSolicitudCotizacion.SaveSolicitudAtencionTelefonica(oSolicitud);


                //Creación de la tabla
                //String TablaDetalleCotizacion = "<table width='90%' border='0' cellpadding='0' cellspacing='0' class='contenttable'><th>RIMAC</th><th>PACIFICO</th><th>LA POSITIVA</th><th>MAPFRE</th><th>HDI</th><tr><td>USD$" + oCotizacionDetalle.Prima_Rimac + "</td><td>USD$" + oCotizacionDetalle.Prima_Pacifico + "</td><td>USD$" + oCotizacionDetalle.Prima_LaPositiva + "</td><td>USD$" + oCotizacionDetalle.Prima_Mafre + "</td><td>USD$" + oCotizacionDetalle.Prima_HDI + "</td></tr></table>";
                
                //string cuerpoEmail = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> <html xmlns='http://www.w3.org/1999/xhtml'> <head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8'> <title>El Equipo de DigitalBrokers.pe</title> <style type='text/css'> body {margin: 0; padding: 0; min-width: 100%!important;} img {height: auto;} .content {width: 100%; max-width: 600px;} .contenttable{align:middle;text-align:center;width:100%;}.contenttable th{background-color:#0080FF;color: #fff;height:80px;font-weight :200;}. contenttable td{text-align:center; vertical-align:center;} .header {padding: 40px 30px 20px 30px;} .innerpadding {padding: 30px 30px 30px 30px;} .borderbottom {border-bottom: 1px solid #f2eeed;} .subhead {font-size: 15px; color: #ffffff; font-family: sans-serif;} .h2, .bodycopy {color: #fff; font-family: sans-serif;} .h1 {font-size: 33px;color: #fff; line-height: 38px; font-weight: bold;} .h2 {padding: 0 0 15px 0; font-size: 24px; line-height: 28px; font-weight: bold;} .bodycopy {font-size: 16px; line-height: 22px;} .button {text-align: center; font-size: 18px; font-family: sans-serif; font-weight: bold; padding: 0 30px 0 30px;} .button a {color: #ffffff; text-decoration: none;} .footer {padding: 20px 30px 15px 30px;} .footercopy {font-family: sans-serif; font-size: 14px; color: #ffffff;} .footercopy a {color: #ffffff; text-decoration: underline;} @media only screen and (max-width: 550px), screen and (max-device-width: 550px) { body[yahoo] .hide {display: none!important;} body[yahoo] .buttonwrapper {background-color: transparent!important;} body[yahoo] .button {padding: 0px!important;} body[yahoo] .button a {background-color: #e05443; padding: 15px 15px 13px!important;} body[yahoo] .unsubscribe {display: block; margin-top: 20px; padding: 10px 50px; background: #2f3942; border-radius: 5px; text-decoration: none!important; font-weight: bold;} } /*@media only screen and (min-device-width: 601px) { .content {width: 600px !important;} .col425 {width: 425px!important;} .col380 {width: 380px!important;} }*/ </style> </head> <!-- Desarrolado por Daniel Lazarte @daniellazarte en Twitter--> <body style='margin: 0;padding: 0;min-width: 100%!important;'> <table width='100%' bgcolor='#f6f8f1' border='0' cellpadding='0' cellspacing='0'> <tr> <td> <!--[if (gte mso 9)|(IE)]> <table width='600' align='center' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table bgcolor='#ffffff' class='content' align='center' cellpadding='0' cellspacing='0' border='0' style='width: 100%;max-width: 600px;'> <tr> <td bgcolor='#0080FF' class='header' style='padding: 40px 30px 20px 30px;'> <table width='70' align='left' border='0' cellpadding='0' cellspacing='0'> <tr> <td height='70' style='padding: 0 20px 20px 0;'> <img class='fix' src='https://pga.editoraperu.com.pe/image/check.png' width='70' height='70' border='0' alt='' style='height: auto;'> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> <table width='425' align='left' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table class='col425' align='left' border='0' cellpadding='0' cellspacing='0' style='width: 100%; max-width: 425px;'> <tr> <td height='70'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='subhead' style='padding: 0 0 0 3px;font-size: 15px;color: #ffffff;font-family: sans-serif;'> El Equipo de DigitalBrokers.pe</td> </tr> <tr> <td class='h1' style='padding: 5px 0 0 0;color: #fff;font-family: sans-serif;font-size: 33px;line-height: 38px;font-weight: bold;'>Tu cotización  Nro. WP-0" + intRes + " </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='h2' style='color: #153643;font-family: sans-serif;padding: 0 0 15px 0;font-size: 24px;line-height: 28px;font-weight: 200;'> Hola " + oSolicitud.EmailSolicitante.Trim() + ", generaste una cotización para tu vehículo marca " + oSolicitud.Desccripcion_Marca.Trim() + " modelo " + oSolicitud.Descripcion_Modelo + " Año " + oSolicitud.Anio + ", estamos felices de que nos hallas elegido. Aquí tienes tu cotización puedes verlo en los archivos adjuntos. </td> </tr> <tr> <td class='bodycopy' style='color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'>Si tuvieras alguna duda con la información enviada no dudes en escribirnos o solicitar una llamada atravéz de nuestra aplicación, estaremos encantados de conversar contigo. <br><br></td></tr><tr><td>" + TablaDetalleCotizacion + "</td></tr> </table></td> </tr>  <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <img class='fix' src='http://app.digitalbrokers.pe/imagenes/secure-car-email.gif' width='100%' border='0' alt='' style='height: auto;'> </td> </tr> <tr> <td class='innerpadding bodycopy' style='padding: 30px 30px 30px 30px;color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'> Gracias por ser parte de nuestro equipo =) . </td> </tr> <tr> <td class='footer' bgcolor='#44525f' style='padding: 20px 30px 15px 30px;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' class='footercopy' style='font-family: sans-serif;font-size: 14px;color: #ffffff;'> &reg; Digital Brokers S.A.<br> <span class='hide'>Correo enviado de forma automática por el portal DigitalBrokers.pe.<br/>Se recomienda no responder al presnete correo.</span> </td> </tr> <tr> <td align='center' style='padding: 20px 0 0 0;'> <table border='0' cellspacing='0' cellpadding='0'> <tr> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='http://www.facebook.com/'> <img src='https://pga.editoraperu.com.pe/image/facebook.png' width='37' height='37' alt='Facebook' border='0' style='height: auto;'> </a> </td> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='http://www.twitter.com/'> <img src='https://pga.editoraperu.com.pe/image/twitter.png' width='37' height='37' alt='Twitter' border='0' style='height: auto;'> </a> </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> </table> <!--analytics--> <script src='http://code.jquery.com/jquery-1.10.1.min.js' type='text/javascript'></script> </body> </html>";
                string cuerpoEmail = "Hola, realizaron una solicitud de llamada en la plataforma. El cliente " + oSolicitud.Nombres + " solicita una llamada a su numero: " + oSolicitud.TelefonoSolicitante + ", su email es: " + oSolicitud.EmailSolicitante + "<br> Este correo es un envio automático generado por pa plataforma Digitalbropers.pe <br><br>DIGITAL BROKERS S.A.C. CORREDORES DE SEGUROS";



                //**************************************Envio de Email al Cliente Produccion Godaddy*******************************************

                MailAddress mailfrom = new MailAddress("diego@digitalbrokers.pe");
                MailAddress mailto = new MailAddress("cteran@digitalbrokers.pe");
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                ////AGREGANDO COPIA A DIEGO PARA SU VALIDACION Y ATENCION
                MailAddress copy = new MailAddress("daniel.lazarte@gmail.com");
                newmsg.Bcc.Add(copy);

                ////AGREGANDO COPIA A DIEGO PARA SU VALIDACION Y ATENCION
                MailAddress copydiego = new MailAddress("diego@digitalbrokers.pe");
                newmsg.Bcc.Add(copydiego);

                ////AGREGANDO COPIA A DIEGO PARA SU VALIDACION Y ATENCION
                MailAddress copycli = new MailAddress("cliente@digitalbrokers.pe");
                newmsg.Bcc.Add(copycli);

                newmsg.Subject = "Solicitud de Llamada en Plataforma";
                //newmsg.Body = "Hola, " + Email + " En breve te tendremos muchas novedades de nuestro servicio. Estaremos en contacto contigo.  Saludos, de digitalbrokers.pe";

                SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("suscripcion@dlazarte.com", "servando");

                newmsg.Body = cuerpoEmail;
                newmsg.IsBodyHtml = true;
                smtp.Send(newmsg);
                //**************************************FIN Envio de Email al Cliente Produccion Godaddy*******************************************


                //**************************************Envio de Email Al Cliente con cuenta Google Desarrollo*************************************
                //GMailer.GmailUsername = "daniel@digitalbrokers.pe";
                //GMailer.GmailPassword = "qqmmhtoeeycdfdwx";

                ////////AGREGANDO COPIA A DIEGO PARA SU VALIDACION Y ATENCION
                ////MailAddress copy = new MailAddress("daniel.lazarte@gmail.com");
                ////newmsg.Bcc.Add(copy);


                //GMailer mailer = new GMailer();
                //mailer.ToEmail = "daniel.lazarte@gmail.com";
                //mailer.Subject = "Solicitud de Llamada Telefonica";
                //mailer.Body = cuerpoEmail;

                //mailer.IsHtml = true;
                //mailer.Send();
                ////**************************************Envio de Email Al Cliente con cuenta Google Desarrollo*************************************

                if (intRes > 0) return Json(new { intSolicitudCotizacion = intRes });
                else return Json(new { success = false });

            }
            catch (Exception)
            {

                throw;
            }




        }
        public JsonResult SaveCotizacionCliente(ENSolicitudCotizacion oSolicitud)
        {

            try
            {
                int intRes = 0;
                //Solicitud de Cotizacion
                LNSolicitudCotizacion oLNSolicitudCotizacion = new LNSolicitudCotizacion();
                intRes = oLNSolicitudCotizacion.SaveCotizacionCliente(oSolicitud);

                //Solicitud de Detalle de Cotizacion
                ENCotizacionDetalle oCotizacionDetalle = null;
                LNCotizacionDetalle olnCotizacionDetalle = new LNCotizacionDetalle();
                oCotizacionDetalle = olnCotizacionDetalle.GetCotizacionDetalle(intRes);

                //GENERACION DE ARCHIVO PDF PARA LA COTIZACION DEL CLIENTE

                //int idCotizacion = Int32.Parse(Session["idCotizacion"].ToString());
               
                LNCotizacion LNCotizacion = new LNCotizacion();
                //cambio fabian por las
                LNCotizacion.GenerarCotizacionPDF(intRes);
               
                //LEYENDO LOS BYTES
                string NombreArchivo = "COT-" + intRes.ToString() + ".PDF";
                //byte[] fileBytes = System.IO.File.ReadAllBytes(@"F:/DigitalBrokers/PDF/" + NombreArchivo);
                
                //Desarrollo
                //string NombreArchivoyRuta = (@"F:/DigitalBrokers/PDF/" + NombreArchivo);

                //Produccion
                //string NombreArchivoyRuta = (@"G:/PleskVhosts/digitalbrokers.pe/app.digitalbrokers.pe/Cotizaciones/PDF/" + NombreArchivo);
                //cambio fabian
                string NombreArchivoyRuta = (@"D:/trabajo/ROBERTO/2_Web.DigitalBrokers/Web.DigitalBrokers/Web.DigitalBrokers/Cotizaciones/PDF/" + NombreArchivo);

                //string fileName = RandomString(8, false) + intRes.ToString() + ".pdf";
                //string archivoCotizacionAdjuntar = @"F:/DigitalBrokers/PDF/" + fileName;
                //System.IO.File.WriteAllBytes(archivoCotizacionAdjuntar, fileBytes);

                //FIN GENERACION PDF CLIENTE 

                string PrimaRimac = oCotizacionDetalle.Prima_Rimac.ToString();
                string PrimaMafre = oCotizacionDetalle.Prima_Mafre.ToString();
                string PrimaPacifico =oCotizacionDetalle.Prima_Pacifico.ToString();
                string PrimaLaPositiva = oCotizacionDetalle.Prima_LaPositiva.ToString();
                string PrimaHDI = oCotizacionDetalle.Prima_HDI.ToString();

                if (oCotizacionDetalle.Prima_HDI.ToString() == "0") 
                {
                    PrimaHDI = "Consultar";
                }

                if (oCotizacionDetalle.Prima_LaPositiva.ToString() == "0")
                {
                    PrimaLaPositiva = "Consultar";
                }
                if (oCotizacionDetalle.Prima_Mafre.ToString() == "0")
                {
                    PrimaMafre = "Consultar"; 
                }
                if (oCotizacionDetalle.Prima_Pacifico.ToString() == "0")
                {
                    PrimaPacifico = "Consultar";
                }
                if (oCotizacionDetalle.Prima_Rimac.ToString() == "0")
                {
                    PrimaRimac = "Consultar";
                }

               

                ENCotizacion objCotizacion = null;
                LNCotizacion olnobjCotizacion = new LNCotizacion();
                objCotizacion = olnobjCotizacion.GetCotizacionCabecera(intRes);

                //GENERACION DE DEDUCIBLES POR COMPANIA
                //Agregar Deducibles al Emilio: 23 febrero Daniel Lazarte
                ////Obteniendo la Lista de Deducibles
                //LNDeducibles olnDeducible = new LNDeducibles();
                //List<ENDeducibles> lbeDeducible = olnDeducible.GetDeduciblesCategoriaAll();

                ////RIIMAC
                //string RimacListaDeducibles = "";
                // List<ENDeducibles> RimacItems =   lbeDeducible.Where(item => item.Categoria == objCotizacion.RIMAC_Categoria).ToList();
                // List<ENDeducibles> RimacItemFiltro = RimacItems.Where(item => item.idAseguradora== 2).ToList();

                // for (int i = 0; i < RimacItemFiltro.Count; i++)
                // {
                //     RimacListaDeducibles += "<li>" + RimacItemFiltro[i].Descripcion + "</li>";
                     
                // }
                ////FIN RIMAC

                ////LA POSITIVA
                // string PositivaListaDeducibles = "";
                // List<ENDeducibles> PositivaItems = lbeDeducible.Where(item => item.Categoria == objCotizacion.POSITIVA_Categoria).ToList();
                // List<ENDeducibles> PositivaItemFiltro = PositivaItems.Where(item => item.idAseguradora == 1).ToList();

                // for (int i = 0; i < PositivaItemFiltro.Count; i++)
                // {
                //     PositivaListaDeducibles += "<li>" + PositivaItemFiltro[i].Descripcion + "</li>";

                // }
                // //FIN LA POSITIVA

                // //MAPFRE
                // string MapfreListaDeducibles = "";
                // List<ENDeducibles> MapfreItems = lbeDeducible.Where(item => item.Categoria == objCotizacion.MAPFRE_Categoria).ToList();
                // List<ENDeducibles> MapfreItemFiltro = MapfreItems.Where(item => item.idAseguradora == 3).ToList();

                // for (int i = 0; i < MapfreItemFiltro.Count; i++)
                // {
                //     MapfreListaDeducibles += "<li>" + MapfreItemFiltro[i].Descripcion + "</li>";

                // }
                // //FIN MAPFRE

                // //PACIFICO
                // string PacificoListaDeducibles = "";
                // List<ENDeducibles> PacificoItems = lbeDeducible.Where(item => item.Categoria == objCotizacion.PACIFICO_Categoria).ToList();
                // List<ENDeducibles> PacificoItemFiltro = PacificoItems.Where(item => item.idAseguradora == 4).ToList();

                // for (int i = 0; i < PacificoItemFiltro.Count; i++)
                // {
                //     PacificoListaDeducibles += "<li>" + PacificoItemFiltro[i].Descripcion + "</li>";

                // }
                // //FIN PACIFICO

                // //HDI
                // string HDIListaDeducibles = "";
                // List<ENDeducibles> HDIItems = lbeDeducible.Where(item => item.Categoria == objCotizacion.HDI_Categoria).ToList();
                // List<ENDeducibles> HDIItemFiltro = HDIItems.Where(item => item.idAseguradora == 5).ToList();

                // for (int i = 0; i < HDIItemFiltro.Count; i++)
                // {
                //     HDIListaDeducibles += "<li>" + HDIItemFiltro[i].Descripcion + "</li>";

                // }
                // //FIN HDI


                // string TablaDeducibles = "<table width='90%' border='0' cellpadding='0' cellspacing='0' class='contenttable'><th>RIMAC DEDUCIBLES</th><tr><td align='left'>" + RimacListaDeducibles + "</td></tr></table>";
                // string TablaPositivaDeducibles = "<table width='90%' border='0' cellpadding='0' cellspacing='0' class='contenttable'><th>LA POSITIVA DEDUCIBLES</th><tr><td align='left'>" + PositivaListaDeducibles + "</td></tr></table>";
                // string MapfreTablaDeducibles = "<table width='90%' border='0' cellpadding='0' cellspacing='0' class='contenttable'><th>MAPFRE DEDUCIBLES</th><tr><td align='left'>" + MapfreListaDeducibles + "</td></tr></table>";
                // string PacificoTablaDeducibles = "<table width='90%' border='0' cellpadding='0' cellspacing='0' class='contenttable'><th>PACIFICO DEDUCIBLES</th><tr><td align='left'>" + PacificoListaDeducibles + "</td></tr></table>";
                // string HDITablaDeducibles = "<table width='90%' border='0' cellpadding='0' cellspacing='0' class='contenttable'><th>HDI DEDUCIBLES</th><tr><td align='left'>" + HDIListaDeducibles + "</td></tr></table>";

                // //FIN GENERACION DE DEDUCIBLES POR COMPANIA

                //Creación de la tabla
                 //Encryptar Codigo
                string codigoEncryptado = CryptorEngine.Encrypt(intRes.ToString(), true);
                //string codigoEncryptado = CryptorEngine.Encrypt(intRes.ToString(), true);
                String TablaDetalleCotizacion = "<table width='90%' border='0' cellpadding='0' cellspacing='0' class='contenttable'><th>RIMAC</th><th>PACIFICO</th><th>LA POSITIVA</th><th>MAPFRE</th><th>HDI</th><tr><td align='center'>" + PrimaRimac + "</td><td align='center'>" + PrimaPacifico + "</td><td align='center'>" + PrimaLaPositiva + "</td><td align='center'>" + PrimaMafre + "</td><td align='center'>" + PrimaHDI + "</td></tr></table>";
                //string cuerpoEmail = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> <html xmlns='http://www.w3.org/1999/xhtml'> <head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8'> <title>El Equipo de DigitalBrokers.pe</title> <style type='text/css'> body {margin: 0; padding: 0; min-width: 100%!important;} img {height: auto;} .content {width: 100%; max-width: 600px;} .contenttable{align:middle;text-align:center;width:100%;}.contenttable th{background-color:#0080FF;color: #fff;height:80px;font-weight :200;}. contenttable td{text-align:center; vertical-align:center;} .header {padding: 40px 30px 20px 30px;} .innerpadding {padding: 30px 30px 30px 30px;} .borderbottom {border-bottom: 1px solid #f2eeed;} .subhead {font-size: 15px; color: #ffffff; font-family: sans-serif;} .h2, .bodycopy {color: #fff; font-family: sans-serif;} .h1 {font-size: 33px;color: #fff; line-height: 38px; font-weight: bold;} .h2 {padding: 0 0 15px 0; font-size: 24px; line-height: 28px; font-weight: bold;} .bodycopy {font-size: 16px; line-height: 22px;} .button {text-align: center; font-size: 18px; font-family: sans-serif; font-weight: bold; padding: 0 30px 0 30px;} .button a {color: #ffffff; text-decoration: none;} .footer {padding: 20px 30px 15px 30px;} .footercopy {font-family: sans-serif; font-size: 14px; color: #ffffff;} .footercopy a {color: #ffffff; text-decoration: underline;} @media only screen and (max-width: 550px), screen and (max-device-width: 550px) { body[yahoo] .hide {display: none!important;} body[yahoo] .buttonwrapper {background-color: transparent!important;} body[yahoo] .button {padding: 0px!important;} body[yahoo] .button a {background-color: #e05443; padding: 15px 15px 13px!important;} body[yahoo] .unsubscribe {display: block; margin-top: 20px; padding: 10px 50px; background: #2f3942; border-radius: 5px; text-decoration: none!important; font-weight: bold;} } /*@media only screen and (min-device-width: 601px) { .content {width: 600px !important;} .col425 {width: 425px!important;} .col380 {width: 380px!important;} }*/ </style> </head> <!-- Desarrolado por Daniel Lazarte @daniellazarte en Twitter--> <body style='margin: 0;padding: 0;min-width: 100%!important;'> <table width='100%' bgcolor='#f6f8f1' border='0' cellpadding='0' cellspacing='0'> <tr> <td> <!--[if (gte mso 9)|(IE)]> <table width='600' align='center' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table bgcolor='#ffffff' class='content' align='center' cellpadding='0' cellspacing='0' border='0' style='width: 100%;max-width: 600px;'> <tr> <td bgcolor='#0080FF' class='header' style='padding: 40px 30px 20px 30px;'> <table width='70' align='left' border='0' cellpadding='0' cellspacing='0'> <tr> <td height='70' style='padding: 0 20px 20px 0;'> <img class='fix' src='https://pga.editoraperu.com.pe/image/check.png' width='70' height='70' border='0' alt='' style='height: auto;'> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> <table width='425' align='left' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table class='col425' align='left' border='0' cellpadding='0' cellspacing='0' style='width: 100%; max-width: 425px;'> <tr> <td height='70'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='subhead' style='padding: 0 0 0 3px;font-size: 15px;color: #ffffff;font-family: sans-serif;'> El Equipo de DigitalBrokers.pe</td> </tr> <tr> <td class='h1' style='padding: 5px 0 0 0;color: #fff;font-family: sans-serif;font-size: 33px;line-height: 38px;font-weight: bold;'>Tu cotización  Nro. WP-0" + intRes + " </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='h2' style='color: #153643;font-family: sans-serif;padding: 0 0 15px 0;font-size: 24px;line-height: 28px;font-weight: 200;'> Hola " + oSolicitud.EmailSolicitante.Trim() + ", generaste una cotización para tu vehículo marca " + oSolicitud.Desccripcion_Marca.Trim() + " " + oSolicitud.Descripcion_Modelo + " Año " + oSolicitud.Anio + " valorizado en USD$" + oSolicitud.valorReferencial.ToString() + ", estamos felices de que nos hallas elegido. Sigue disfrutando de nuestra plataforma. </td> </tr> <tr> <td class='bodycopy' style='color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'>Si tuvieras alguna duda con la información enviada no dudes en escribirnos o solicitar una llamada mediante nuestra plataforma, estaremos encantados de conversar contigo. Adjuntamos tabién el Slip vehícular en formato PDF.<br><br> La presente cotización esta expresada en Dolares Americanos (USD$)<br></td></tr><tr><td>" + TablaDetalleCotizacion + "</td></tr></table></td> </tr>  <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <img class='fix' src='http://app.digitalbrokers.pe/imagenes/secure-car-email.gif' width='100%' border='0' alt='' style='height: auto;'> </td> </tr><tr><td>" + TablaDeducibles + "</td></tr><tr><td>" + TablaPositivaDeducibles + "</td></tr><tr><td>" + MapfreTablaDeducibles + "</td></tr><tr><td>"+ PacificoTablaDeducibles+ "</td></tr><tr><td>"+ HDITablaDeducibles +"</td></tr> <tr> <td class='innerpadding bodycopy' style='padding: 30px 30px 30px 30px;color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'> Gracias por ser parte de nuestro equipo =) .</td> </tr> <tr> <td class='footer' bgcolor='#44525f' style='padding: 20px 30px 15px 30px;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' class='footercopy' style='font-family: sans-serif;font-size: 14px;color: #ffffff;'> &reg; Digital Brokers S.A.<br> <span class='hide'>Correo enviado de forma automática por el portal DigitalBrokers.pe.<br/>Se recomienda no responder al presnete correo.</span> </td> </tr> <tr> <td align='center' style='padding: 20px 0 0 0;'> <table border='0' cellspacing='0' cellpadding='0'> <tr> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='http://www.facebook.com/'> <img src='https://pga.editoraperu.com.pe/image/facebook.png' width='37' height='37' alt='Facebook' border='0' style='height: auto;'> </a> </td> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='http://www.twitter.com/'> <img src='https://pga.editoraperu.com.pe/image/twitter.png' width='37' height='37' alt='Twitter' border='0' style='height: auto;'> </a> </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> </table> <!--analytics--> <script src='http://code.jquery.com/jquery-1.10.1.min.js' type='text/javascript'></script> </body> </html>";
                //este era el cuerpo con deducibles string cuerpoEmail = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> <html xmlns='http://www.w3.org/1999/xhtml'> <head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8'> <title>El Equipo de DigitalBrokers.pe</title> <style type='text/css'> body {margin: 0; padding: 0; min-width: 100%!important;} img {height: auto;} .content {width: 100%; max-width: 600px;} .contenttable{align:middle;text-align:center;width:100%;}.contenttable th{background-color:#0080FF;color: #fff;height:80px;font-weight :200;}.cf-botton-probar{display:block;width:100%;background-color:#0174DF;border: 1px solid #0174DF;border-radius: 10px;text-decoration: none;text-align: center;color: #fff;font-size: 1em;padding: 10px;}.cf-botton-probar:hover{color:#0174DF;background-color:#fff;}.contenttable td{text-align:center; vertical-align:center;} .header {padding: 40px 30px 20px 30px;} .innerpadding {padding: 30px 30px 30px 30px;} .borderbottom {border-bottom: 1px solid #f2eeed;} .subhead {font-size: 15px; color: #ffffff; font-family: sans-serif;} .h2, .bodycopy {color: #fff; font-family: sans-serif;} .h1 {font-size: 33px;color: #fff; line-height: 38px; font-weight: bold;} .h2 {padding: 0 0 15px 0; font-size: 24px; line-height: 28px; font-weight: bold;} .bodycopy {font-size: 16px; line-height: 22px;} .button {text-align: center; font-size: 18px; font-family: sans-serif; font-weight: bold; padding: 0 30px 0 30px;} .button a {color: #ffffff; text-decoration: none;} .footer {padding: 20px 30px 15px 30px;} .footercopy {font-family: sans-serif; font-size: 14px; color: #ffffff;} .footercopy a {color: #ffffff; text-decoration: underline;} @media only screen and (max-width: 550px), screen and (max-device-width: 550px) { body[yahoo] .hide {display: none!important;} body[yahoo] .buttonwrapper {background-color: transparent!important;} body[yahoo] .button {padding: 0px!important;} body[yahoo] .button a {background-color: #e05443; padding: 15px 15px 13px!important;} body[yahoo] .unsubscribe {display: block; margin-top: 20px; padding: 10px 50px; background: #2f3942; border-radius: 5px; text-decoration: none!important; font-weight: bold;} } /*@media only screen and (min-device-width: 601px) { .content {width: 600px !important;} .col425 {width: 425px!important;} .col380 {width: 380px!important;} }*/ </style> </head> <!-- Desarrolado por Daniel Lazarte @daniellazarte en Twitter--> <body style='margin: 0;padding: 0;min-width: 100%!important;'> <table width='100%' bgcolor='#f6f8f1' border='0' cellpadding='0' cellspacing='0'> <tr> <td> <!--[if (gte mso 9)|(IE)]> <table width='600' align='center' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table bgcolor='#ffffff' class='content' align='center' cellpadding='0' cellspacing='0' border='0' style='width: 100%;max-width: 600px;'> <tr> <td bgcolor='#0080FF' class='header' style='padding: 40px 30px 20px 30px;'> <table width='70' align='left' border='0' cellpadding='0' cellspacing='0'> <tr> <td height='70' style='padding: 0 20px 20px 0;'> <img class='fix' src='https://pga.editoraperu.com.pe/image/check.png' width='70' height='70' border='0' alt='' style='height: auto;'> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> <table width='425' align='left' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table class='col425' align='left' border='0' cellpadding='0' cellspacing='0' style='width: 100%; max-width: 425px;'> <tr> <td height='70'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='subhead' style='padding: 0 0 0 3px;font-size: 15px;color: #ffffff;font-family: sans-serif;'> El Equipo de DigitalBrokers.pe</td> </tr> <tr> <td class='h1' style='padding: 5px 0 0 0;color: #fff;font-family: sans-serif;font-size: 33px;line-height: 38px;font-weight: bold;'>Tu cotización  Nro. WP-0" + intRes + " </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='h2' style='color: #153643;font-family: sans-serif;padding: 0 0 15px 0;font-size: 24px;line-height: 28px;font-weight: 200;'> Hola " + oSolicitud.EmailSolicitante.Trim() + ", generaste una cotización para tu vehículo marca " + oSolicitud.Desccripcion_Marca.Trim() + " " + oSolicitud.Descripcion_Modelo + " Año " + oSolicitud.Anio + " valorizado en USD$" + oSolicitud.valorReferencial.ToString() + ", estamos felices de que nos hallas elegido. Sigue disfrutando de nuestra plataforma. </td> </tr> <tr> <td class='bodycopy' style='color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'>Si tuvieras alguna duda con la información enviada no dudes en escribirnos o solicitar una llamada mediante nuestra plataforma, estaremos encantados de conversar contigo. Adjuntamos tabién el Slip vehícular en formato PDF.<br><br>También puedes ver tu cotización en cualquier momento aquí: <a class='cf-botton-probar' href='http://localhost:5701/Cotizacion/MiCotizacion/" + codigoEncryptado + "'>VER MI COTIZACIÓN ONLINE</a><br><br> La presente cotización esta expresada en Dolares Americanos (USD$)<br></td></tr><tr><td>" + TablaDetalleCotizacion + "</td></tr></table></td> </tr>  <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <img class='fix' src='http://app.digitalbrokers.pe/imagenes/secure-car-email.gif' width='100%' border='0' alt='' style='height: auto;'> </td> </tr><tr><td>" + TablaDeducibles + "</td></tr><tr><td>" + TablaPositivaDeducibles + "</td></tr><tr><td>" + MapfreTablaDeducibles + "</td></tr><tr><td>" + PacificoTablaDeducibles + "</td></tr><tr><td>" + HDITablaDeducibles + "</td></tr> <tr> <td class='innerpadding bodycopy' style='padding: 30px 30px 30px 30px;color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'> Gracias por ser parte de nuestro equipo =) .</td> </tr> <tr> <td class='footer' bgcolor='#44525f' style='padding: 20px 30px 15px 30px;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' class='footercopy' style='font-family: sans-serif;font-size: 14px;color: #ffffff;'> &reg; DIGITAL BROKERS S.A.C. - CORREDORES DE SEGUROS.<br> <span class='hide'>DOM.FISCAL: AV. AREQUIPA 2450 - OFICINA 1205, LINCE. LIMA-PE.<br/>TELEFONO: PERÚ(01) 759-7746</span> </td> </tr> <tr> <td align='center' style='padding: 20px 0 0 0;'> <table border='0' cellspacing='0' cellpadding='0'> <tr> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='https://www.facebook.com/digitalbrokers'> <img src='https://pga.editoraperu.com.pe/image/facebook.png' width='37' height='37' alt='Facebook' border='0' style='height: auto;'> </a> </td> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='http://www.twitter.com/'> <img src='https://pga.editoraperu.com.pe/image/twitter.png' width='37' height='37' alt='Twitter' border='0' style='height: auto;'> </a> </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> </table> <!--analytics--> <script src='http://code.jquery.com/jquery-1.10.1.min.js' type='text/javascript'></script> </body> </html>";
                string cuerpoEmail = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> <html xmlns='http://www.w3.org/1999/xhtml'> <head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8'> <title>El Equipo de DigitalBrokers.pe</title> <style type='text/css'> body {margin: 0; padding: 0; min-width: 100%!important;} img {height: auto;} .content {width: 100%; max-width: 600px;} .contenttable{align:middle;text-align:center;width:100%;}.contenttable{align:middle;text-align:center;width:100%;}.contenttable th{background-color:#fff;color: #000;height:30px;font-weight :200;}.cf-botton-probar{display:inline-block;width:50%;background-color:#fff;border: 1px solid #0174DF;text-decoration: none;text-align: center;color: #0174DF;font-size: 0.7em;padding: 10px;}.cf-botton-probar:hover{color:#0174DF;background-color:#fff;}.contenttable td{text-align:center; vertical-align:center;} .header {padding: 40px 30px 20px 30px;} .innerpadding {padding: 30px 30px 30px 30px;} .borderbottom {border-bottom: 1px solid #f2eeed;} .subhead {font-size: 15px; color: #ffffff; font-family: sans-serif;} .h2, .bodycopy {color: #fff; font-family: sans-serif;} .h1 {font-size: 33px;color: #fff; line-height: 38px; font-weight: bold;} .h2 {padding: 0 0 15px 0; font-size: 24px; line-height: 28px; font-weight: bold;} .bodycopy {font-size: 16px; line-height: 22px;} .button {text-align: center; font-size: 18px; font-family: sans-serif; font-weight: bold; padding: 0 30px 0 30px;} .button a {color: #ffffff; text-decoration: none;} .footer {padding: 20px 30px 15px 30px;} .footercopy {font-family: sans-serif; font-size: 14px; color: #ffffff;} .footercopy a {color: #ffffff; text-decoration: underline;} @media only screen and (max-width: 550px), screen and (max-device-width: 550px) { body[yahoo] .hide {display: none!important;} body[yahoo] .buttonwrapper {background-color: transparent!important;} body[yahoo] .button {padding: 0px!important;} body[yahoo] .button a {background-color: #e05443; padding: 15px 15px 13px!important;} body[yahoo] .unsubscribe {display: block; margin-top: 20px; padding: 10px 50px; background: #2f3942; border-radius: 5px; text-decoration: none!important; font-weight: bold;} } /*@media only screen and (min-device-width: 601px) { .content {width: 600px !important;} .col425 {width: 425px!important;} .col380 {width: 380px!important;} }*/ </style> </head> <!-- Desarrolado por Daniel Lazarte @daniellazarte en Twitter--> <body style='margin: 0;padding: 0;min-width: 100%!important;'> <table width='100%' bgcolor='#f6f8f1' border='0' cellpadding='0' cellspacing='0'> <tr> <td> <!--[if (gte mso 9)|(IE)]> <table width='600' align='center' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table bgcolor='#ffffff' class='content' align='center' cellpadding='0' cellspacing='0' border='0' style='width: 100%;max-width: 600px;'> <tr> <td bgcolor='#fff' class='header' style='padding: 40px 30px 20px 30px;'> <table width='292' align='left' border='0' cellpadding='0' cellspacing='0'> <tr> <td height='100' style='padding: 0 20px 20px 0;'> <img class='fix' src='https://www.digitalbrokers.pe/imagenes/digitalbrokerspe.png' width='292' height='100' border='0' alt='' style='height: auto;'> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> <table width='425' align='left' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table class='col425' align='left' border='0' cellpadding='0' cellspacing='0' style='width: 100%; max-width: 425px;'> <tr> <td height='70'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='subhead' style='padding: 0 0 0 3px;font-size: 15px;color: #000;font-family: sans-serif;'> El Equipo de DigitalBrokers.pe</td> </tr> <tr> <td class='h1' style='padding: 5px 0 0 0;color: #000;font-family: sans-serif;font-size: 24px;line-height: 38px;font-weight:300;'>Tu cotización  Nro. WP-0" + intRes + " </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='h2' style='color: #000;font-family: sans-serif;padding: 0 0 15px 0;font-size: 18px;line-height: 20px;font-weight: 200;'> Hola " + oSolicitud.EmailSolicitante.Trim() + ", generaste una cotización para tu vehículo " + oSolicitud.Descripcion_Modelo + " Año " + oSolicitud.Anio + " valorizado en USD$" + oSolicitud.valorReferencial.ToString() + ", estamos felices de que nos hallas elegido. Sigue disfrutando de nuestra plataforma. </td> </tr> <tr> <td class='bodycopy' style='color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;text-align:left;'>Si tuvieras alguna duda con la información enviada no dudes en escribirnos o solicitar una llamada mediante nuestra plataforma, estaremos encantados de conversar contigo. Adjuntamos tu cotización y el Slip vehicular en formato PDF.<br><br>También puedes ver tu cotización en cualquier momento aquí: <br><a class='cf-botton-probar' href='https://www.digitalbrokers.pe/Cotizacion/MiCotizacion?id=" + codigoEncryptado + "'>VER MI COTIZACIÓN ONLINE</a><br><br> La presente cotización esta expresada en Dolares Americanos (USD$)<br></td></tr><tr><td>" + TablaDetalleCotizacion + "</td></tr></table></td> </tr>  <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'>  </td> </tr><tr> <td class='innerpadding bodycopy' style='padding: 30px 30px 30px 30px;color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'> Gracias por ser parte de nuestro equipo =) .</td> </tr> <tr> <td class='footer' bgcolor='#44525f' style='padding: 20px 30px 15px 30px;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' class='footercopy' style='font-family: sans-serif;font-size: 14px;color: #ffffff;'> &reg; DIGITAL BROKERS S.A.C. - CORREDORES DE SEGUROS.<br> <span class='hide'>DOM.FISCAL: AV. AREQUIPA 2450 - OFICINA 1205, LINCE. LIMA-PE.<br/>TELEFONO: PERÚ(01) 759-7746</span> </td> </tr> <tr> <td align='center' style='padding: 20px 0 0 0;'> <table border='0' cellspacing='0' cellpadding='0'> <tr> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='https://www.facebook.com/digitalbrokers'> <img src='https://pga.editoraperu.com.pe/image/facebook.png' width='37' height='37' alt='Facebook' border='0' style='height: auto;'> </a> </td> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='http://www.twitter.com/'> <img src='https://pga.editoraperu.com.pe/image/twitter.png' width='37' height='37' alt='Twitter' border='0' style='height: auto;'> </a> </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> </table> <!--analytics--> <script src='http://code.jquery.com/jquery-1.10.1.min.js' type='text/javascript'></script> </body> </html>";


                //***********************Envio de Email al Cliente Produccion Godaddy***************************************
                
                //cambio fabian
                //MailAddress mailfrom = new MailAddress("diego@digitalbrokers.pe");
                MailAddress mailfrom = new MailAddress("jnfabian09@gmail.com");
                MailAddress mailto = new MailAddress(oSolicitud.EmailSolicitante);
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                ////AGREGANDO COPIA A DIEGO PARA SU VALIDACION Y ATENCION
                //cambio fabian , se comenta la copia para el gordito
                //MailAddress copy = new MailAddress("daniel.lazarte@gmail.com");
                //newmsg.Bcc.Add(copy);

                newmsg.Subject = "Diego de digitalbrokers.pe";

                //newmsg.Body = "Hola, " + Email + " En breve te tendremos muchas novedades de nuestro servicio. Estaremos en contacto contigo.  Saludos, de digitalbrokers.pe";

                SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("suscripcion@dlazarte.com", "servando");

                //MODIFICACION PARA ADJUNTAR EL PDF SEGUN CATEGORIA
                //SE CANCELA EL ENVIO DE ESTE PDF POR QUE LO REEMPLAZA EL NUEVO PDF GENERADO
                //String nombreArchivo = "PARTICULAR";
                //string nombreAtachado = "G:/PleskVhosts/digitalbrokers.pe/documentos/PARTICULAR.PDF";

                //if (objCotizacion.UsoVehiculo == "PARTICULAR")
                //{
                //    nombreArchivo = "G:/PleskVhosts/digitalbrokers.pe/documentos/PARTICULAR.PDF";
                //    nombreAtachado = "DB-PARTICULAR-SLIP.PDF";
                //}

                //if (objCotizacion.UsoVehiculo == "CHINOS")
                //{
                //    nombreArchivo = "G:/PleskVhosts/digitalbrokers.pe/documentos/CHINOS.PDF";
                //    nombreAtachado = "DB-VECHINOS-SLIP.PDF";
                //}

                //if (objCotizacion.UsoVehiculo == "PICK UP")
                //{
                //    nombreArchivo = "G:/PleskVhosts/digitalbrokers.pe/documentos/PICKUP.PDF";
                //    nombreAtachado = "DB-VEPICKUP-SLIP.PDF";
                //}

                ////Atachando Archivos
                //System.Net.Mail.Attachment attachment;
                //attachment = new System.Net.Mail.Attachment(nombreArchivo);
                //attachment.Name = nombreAtachado;
                //newmsg.Attachments.Add(attachment);

                //ADJUNTAR EL PDF DE LA COTIZACION

                System.Net.Mail.Attachment attachmentpdf;
                attachmentpdf = new System.Net.Mail.Attachment(NombreArchivoyRuta); //Nombre del PDF Generado en El Software 
                attachmentpdf.Name = RandomString(8, false) + intRes.ToString() + ".pdf";
                newmsg.Attachments.Add(attachmentpdf);


                newmsg.Body = cuerpoEmail;
                newmsg.IsBodyHtml = true;
                //cambio fabian
                //smtp.Send(newmsg);

                //***********************FIN Envio de Email al Cliente Produccion Godaddy***************************************

                //*****************************Envio de Email Al Cliente con cuenta Google Desarrollo***************************

                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //mail.From = new MailAddress("daniel@digitalbrokers.pe");
                //mail.To.Add(oSolicitud.EmailSolicitante);
                //mail.Subject = "Cotizacion vehicular Digitalbrokers: WP-" + intRes;
                //mail.Body = cuerpoEmail;
                //mail.IsBodyHtml = true;

                //////MODIFICACION PARA ADJUNTAR EL PDF SEGUN CATEGORIA
                ////String nombreArchivo = "";
                ////string nombreAtachado = "";
                ////if (objCotizacion.UsoVehiculo == "PARTICULAR")
                ////{
                ////    nombreArchivo = "C:/Docs/PARTICULAR.PDF";
                ////    nombreAtachado = "DB-PARTICULAR-SLIP.PDF";
                ////}

                ////if (objCotizacion.UsoVehiculo == "CHINOS")
                ////{
                ////    nombreArchivo = "C:/Docs/CHINOS.PDF";
                ////    nombreAtachado = "DB-VECHINOS-SLIP.PDF";
                ////}


                //////ADJUNTAR EL PDF DE LA COTIZACION

                //System.Net.Mail.Attachment attachmentpdf;
                //attachmentpdf = new System.Net.Mail.Attachment(NombreArchivoyRuta); //Nombre del PDF Generado en El Software 
                //attachmentpdf.Name = RandomString(8, false) + intRes.ToString() + ".pdf";
                //mail.Attachments.Add(attachmentpdf);


                //////ADJUNTAR LOS DEDUCIBLES
                ////System.Net.Mail.Attachment attachment;
                ////attachment = new System.Net.Mail.Attachment(nombreArchivo);
                ////attachment.Name = nombreAtachado;
                ////mail.Attachments.Add(attachment);

                //SmtpServer.Port = 587;
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("daniel@digitalbrokers.pe", "qqmmhtoeeycdfdwx");
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Send(mail);



                //*****************************Envio de Email Al Cliente con cuenta Google Desarrollo***************************

                Session.Add("idCotizacion", intRes);
                if (intRes > 0) return Json(new { intSolicitudCotizacion = intRes });
                else return Json(new { success = false });

            }
            catch (Exception)
            {
                
                throw;
            }


        }
    
        //Retorno de la Cotizacion
        public JsonResult GetCotizacionClienteCabecera(int idCotizacion)
        {
            try
            {
                ENCotizacion oCotizacion = null;
                LNCotizacion olnCotizacion = new LNCotizacion();
                oCotizacion= olnCotizacion.GetCotizacionCabecera(idCotizacion);
                return Json(oCotizacion, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //DetalleCotizacion
        public JsonResult GetCotizacionClienteDetalle(int idCotizacion)
        {
            try
            {
                ENCotizacionDetalle oCotizacionDetalle = null;
                LNCotizacionDetalle olnCotizacionDetalle = new LNCotizacionDetalle();
                oCotizacionDetalle = olnCotizacionDetalle.GetCotizacionDetalle(idCotizacion);
                return Json(oCotizacionDetalle, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public FileResult Download()
        {
            //PRUEBAS DE ESCRITURA DE COTIZACION EN PDF
            //int idCotizacion = Int32.Parse(Session["idCotizacion"].ToString());
            //string NombreArchivo = "COT-" + idCotizacion.ToString() + ".PDF";

            //LNCotizacion LNCotizacion = new LNCotizacion();
            //LNCotizacion.GenerarCotizacionPDF(idCotizacion);

            ////Desarrollo Pruebas y Rutas
            //byte[] fileBytes = System.IO.File.ReadAllBytes(@"F:/DigitalBrokers/PDF/" + NombreArchivo);
            //string fileName = "TuCotizacion" + idCotizacion.ToString() + ".pdf";
            //System.IO.File.WriteAllBytes(@"F:/DigitalBrokers/PDF/" + fileName, fileBytes);
            
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            //Produccion G:/PleskVhosts/digitalbrokers.pe/documentos/VEHICULAR-SLIP.PDF

            //DESCARGAR LOS BENEFICIOS DE ACUERDO AL TIPO DE COTIZACION
            try
            {
                int idCotizacion = Int32.Parse(Session["idCotizacion"].ToString());
                //ENCotizacion oCotizacion = null;
                //LNCotizacion olnCotizacion = new LNCotizacion();
                //oCotizacion = olnCotizacion.GetCotizacionCabecera(idCotizacion);
                //string Categoria = "PARTICULAR.PDF";
                //if (oCotizacion.UsoVehiculo == "CHINOS") { Categoria = "CHINOS.PDF"; }
                //if (oCotizacion.UsoVehiculo == "PICKUP") { Categoria = "PICKUP.PDF"; }

                byte[] fileBytes = System.IO.File.ReadAllBytes(@"G:/PleskVhosts/digitalbrokers.pe/app.digitalbrokers.pe/Cotizaciones/PDF/COT-" + idCotizacion + ".pdf");
                string fileName = "COT-" + RandomString(12, false) + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        //Donwload Email Cliente
        public FileResult DownloadEmail()
        {
          
            try
            {
                string  encriptado = Request.QueryString["id"].ToString();
              
                //LOGICA DE EXTRAER ID DE LA CADENA
                string idCotizacion = CryptorEngine.Decrypt(encriptado, true);

                //Char delimiter = '@';
                //String[] substrings = CadenaDesencryptada.Split(delimiter);
                //string idCotizacion = substrings[1].ToString();




                byte[] fileBytes = System.IO.File.ReadAllBytes(@"G:/PleskVhosts/digitalbrokers.pe/app.digitalbrokers.pe/Cotizaciones/PDF/COT-" + idCotizacion + ".pdf");
                string fileName = "COT-" + RandomString(12, false) + ".pdf";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            }
            catch (Exception ex)
            {
                throw;
                  
            }

        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToUpper();
            return builder.ToString().ToUpper();
        }

       
       
    }
}