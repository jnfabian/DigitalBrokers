using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Digitalbrokers;
using LogicaNegocios.Digitalbrokers;
using General.Librerias.CodigoUsuario;
using System.Net;
using System.Net.Mail;

namespace Web.DigitalBrokers.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Buy()
        {
               
            return View();
           
        }

        //JSON generación de Orden de Compra
        public JsonResult GenerarComprar(ENCliente obCliente)
        {
            try
            {
                int intRes = 0;
                //Registro de Cliente
                LNCliente oCliente = new LNCliente();
                obCliente.idCotizacion = Int32.Parse(Session["idCotizacion"].ToString());
                intRes = oCliente.SaveCliente(obCliente);
                string nombres = obCliente.Nombres + " " + obCliente.Apellido_Paterno + " " + obCliente.Apellido_Materno;
                //Envio de Email de Confirmción
                String DetalledeCompra = "";
                //String TablaDetalleCotizacion = "<table width='90%' border='0' cellpadding='0' cellspacing='0' class='contenttable'><th>RIMAC</th><th>PACIFICO</th><th>LA POSITIVA</th><th>MAPFRE</th><th>HDI</th><tr><td>USD$" + oCotizacionDetalle.Prima_Rimac + "</td><td>USD$" + oCotizacionDetalle.Prima_Pacifico + "</td><td>USD$" + oCotizacionDetalle.Prima_LaPositiva + "</td><td>USD$" + oCotizacionDetalle.Prima_Mafre + "</td><td>USD$" + oCotizacionDetalle.Prima_HDI + "</td></tr></table>";
                string cuerpoEmail = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'> <html xmlns='http://www.w3.org/1999/xhtml'> <head> <meta http-equiv='Content-Type' content='text/html; charset=utf-8'> <title>El Equipo de DigitalBrokers.pe</title> <style type='text/css'> body {margin: 0; padding: 0; min-width: 100%!important;} img {height: auto;} .content {width: 100%; max-width: 600px;} .contenttable{align:middle;text-align:center;width:100%;}.contenttable th{background-color:#0080FF;color: #fff;height:80px;font-weight :200;}. contenttable td{text-align:center; vertical-align:center;} .header {padding: 40px 30px 20px 30px;} .innerpadding {padding: 30px 30px 30px 30px;} .borderbottom {border-bottom: 1px solid #f2eeed;} .subhead {font-size: 15px; color: #ffffff; font-family: sans-serif;} .h2, .bodycopy {color: #fff; font-family: sans-serif;} .h1 {font-size: 33px;color: #fff; line-height: 38px; font-weight: bold;} .h2 {padding: 0 0 15px 0; font-size: 24px; line-height: 28px; font-weight: bold;} .bodycopy {font-size: 16px; line-height: 22px;} .button {text-align: center; font-size: 18px; font-family: sans-serif; font-weight: bold; padding: 0 30px 0 30px;} .button a {color: #ffffff; text-decoration: none;} .footer {padding: 20px 30px 15px 30px;} .footercopy {font-family: sans-serif; font-size: 14px; color: #ffffff;} .footercopy a {color: #ffffff; text-decoration: underline;} @media only screen and (max-width: 550px), screen and (max-device-width: 550px) { body[yahoo] .hide {display: none!important;} body[yahoo] .buttonwrapper {background-color: transparent!important;} body[yahoo] .button {padding: 0px!important;} body[yahoo] .button a {background-color: #e05443; padding: 15px 15px 13px!important;} body[yahoo] .unsubscribe {display: block; margin-top: 20px; padding: 10px 50px; background: #2f3942; border-radius: 5px; text-decoration: none!important; font-weight: bold;} } /*@media only screen and (min-device-width: 601px) { .content {width: 600px !important;} .col425 {width: 425px!important;} .col380 {width: 380px!important;} }*/ </style> </head> <!-- Desarrolado por Daniel Lazarte @daniellazarte en Twitter--> <body style='margin: 0;padding: 0;min-width: 100%!important;'> <table width='100%' bgcolor='#f6f8f1' border='0' cellpadding='0' cellspacing='0'> <tr> <td> <!--[if (gte mso 9)|(IE)]> <table width='600' align='center' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table bgcolor='#ffffff' class='content' align='center' cellpadding='0' cellspacing='0' border='0' style='width: 100%;max-width: 600px;'> <tr> <td bgcolor='#0080FF' class='header' style='padding: 40px 30px 20px 30px;'> <table width='70' align='left' border='0' cellpadding='0' cellspacing='0'> <tr> <td height='70' style='padding: 0 20px 20px 0;'> <img class='fix' src='http://app.digitalbrokers.pe/imagenes/box.png' width='70' height='70' border='0' alt='' style='height: auto;'> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> <table width='425' align='left' cellpadding='0' cellspacing='0' border='0'> <tr> <td> <![endif]--> <table class='col425' align='left' border='0' cellpadding='0' cellspacing='0' style='width: 100%; max-width: 425px;'> <tr> <td height='70'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='subhead' style='padding: 0 0 0 3px;font-size: 15px;color: #ffffff;font-family: sans-serif;'> El Equipo de DigitalBrokers.pe</td> </tr> <tr> <td class='h1' style='padding: 5px 0 0 0;color: #fff;font-family: sans-serif;font-size: 33px;line-height: 38px;font-weight: bold;'>Gracias por tu Compra. </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td class='h2' style='color: #153643;font-family: sans-serif;padding: 0 0 15px 0;font-size: 24px;line-height: 28px;font-weight: 200;'> Hola " + nombres + ", gran desición estamos muy contentos de que hallas realizado la compra de tu seguro con nuestra plataforma. </td> </tr> <tr> <td class='bodycopy' style='color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'>En breve un asesor estará comunicandose contigo para concluir tu proceso de adquisición de tu Seguro Vehicular. Nuevamente Muchas gracias por ser parte de nuestro selecto equipo de clientes.  <br><br></td></tr><tr><td>" + DetalledeCompra + "</td></tr> </table></td> </tr>  <tr> <td class='innerpadding borderbottom' style='padding: 30px 30px 30px 30px;border-bottom: 1px solid #f2eeed;'> <img class='fix' src='http://app.digitalbrokers.pe/imagenes/thanks-buy.gif' width='100%' border='0' alt='' style='height: auto;'> </td> </tr> <tr> <td class='innerpadding bodycopy' style='padding: 30px 30px 30px 30px;color: #153643;font-family: sans-serif;font-size: 16px;line-height: 22px;'> Gracias por ser parte de nuestro equipo =) . </td> </tr> <tr> <td class='footer' bgcolor='#44525f' style='padding: 20px 30px 15px 30px;'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' class='footercopy' style='font-family: sans-serif;font-size: 14px;color: #ffffff;'> &reg; Digital Brokers S.A.<br> <span class='hide'>Correo enviado de forma automática por el portal DigitalBrokers.pe.<br/>Se recomienda no responder al presnete correo.</span> </td> </tr> <tr> <td align='center' style='padding: 20px 0 0 0;'> <table border='0' cellspacing='0' cellpadding='0'> <tr> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='http://www.facebook.com/'> <img src='https://pga.editoraperu.com.pe/image/facebook.png' width='37' height='37' alt='Facebook' border='0' style='height: auto;'> </a> </td> <td width='37' style='text-align: center; padding: 0 10px 0 10px;'> <a href='http://www.twitter.com/'> <img src='https://pga.editoraperu.com.pe/image/twitter.png' width='37' height='37' alt='Twitter' border='0' style='height: auto;'> </a> </td> </tr> </table> </td> </tr> </table> </td> </tr> </table> <!--[if (gte mso 9)|(IE)]> </td> </tr> </table> <![endif]--> </td> </tr> </table> <!--analytics--> <script src='http://code.jquery.com/jquery-1.10.1.min.js' type='text/javascript'></script> </body> </html>";
                
                
                //***********************Envio de Email al Cliente Produccion Godaddy***************************************

                MailAddress mailfrom = new MailAddress("diego@digitalbrokers.pe");
                MailAddress mailto = new MailAddress(obCliente.Email.ToString());
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                //AGREGANDO COPIA A DIEGO PARA SU VALIDACION Y ATENCION
                MailAddress copy = new MailAddress("daniel.lazarte@gmail.com");
                newmsg.Bcc.Add(copy);


                newmsg.Subject = "Tu compra en digitalbrokers.pe";

                SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("suscripcion@dlazarte.com", "servando");

                newmsg.Body = cuerpoEmail;
                newmsg.IsBodyHtml = true;
                smtp.Send(newmsg);

                //***********************FIN Envio de Email al Cliente Produccion Godaddy***************************************

                //*****************************Envio de Email Al Cliente con cuenta Google Desarrollo***************************
                //GMailer.GmailUsername = "daniel@digitalbrokers.pe";
                //GMailer.GmailPassword = "qqmmhtoeeycdfdwx";

                ////GMailer.GmailUsername = "desarrollo@digitalbrokers.pe";
                ////GMailer.GmailPassword = "servando";

                //GMailer mailer = new GMailer();
                //mailer.ToEmail = obCliente.Email.ToString();

                //mailer.Subject = "Tu compra en digitalbrokers.pe";
                //mailer.Body = cuerpoEmail;
                //mailer.IsHtml = true;
                //mailer.Send();



                //*****************************Envio de Email Al Cliente con cuenta Google Desarrollo***************************

                if (intRes > 0) return Json(new { idCompra = intRes });
                else return Json(new { success = false });

            }

           
            
            catch (Exception)
            {
                
                throw;
            }



        }

        public ActionResult Thankyou()
        {
            return View();
        }

    }
}