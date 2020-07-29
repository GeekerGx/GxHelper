using System.Web.Mvc;

namespace GxHelper.MVC
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            switch (filterContext.RequestContext.HttpContext.Request.RequestType.ToUpper())
            {
                case "GET":
                    TempData["Message"] = filterContext.Exception.Message;
                    filterContext.Result = new RedirectResult(Url.Action("Error", "Error"));
                    break;
                default:
                    string result = new
                    {
                        state = false,
                        msg = filterContext.Exception.Message
                    }.ToJson();
                    filterContext.HttpContext.Response.Write(result);
                    break;

            }
        }
    }
}
