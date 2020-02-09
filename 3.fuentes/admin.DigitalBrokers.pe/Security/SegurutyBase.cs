using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin.DigitalBrokers.pe.Security
{
    public class SegurutyBase : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["CodigoUsuario"];
            if (usuario == null) filterContext.Result = new RedirectResult("~/Usuario/Login");
        }
    }
}