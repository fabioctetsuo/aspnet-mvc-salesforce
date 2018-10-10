using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace SalesforceProject.Filters
{
    public class AcessoFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Contents["UsuarioLogado"] == null)
            {
                if (filterContext.Controller.TempData["Mensagem"] == null) {
                    filterContext.Controller.TempData.Add("Mensagem", "Sessão Expirada! Efetue o login novamente.");
                } ;
                Controller controller = filterContext.Controller as Controller;
                controller.HttpContext.Response.Redirect("/Admin");
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("Depois de execução a Ação do Controller", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log(
            "Antes do Retorno do Retorno do Controller", filterContext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log(
            "Depois do Retorno do Retorno do Controller", filterContext.RouteData);
        }
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");

        }

    }
}