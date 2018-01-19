using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace forumapp.webapi.Filters
{
    public class AllowCors : ActionFilterAttribute
    {
        private const string DEFAULT_URL = "www.exemplo.com";

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Request.Headers.TryGetValues("Origin", out IEnumerable<string> origin);
            actionContext.Request.Headers.TryGetValues("Access-Control-Allow-Origin", out IEnumerable<string> acaorigin);
            
            if (origin != null || acaorigin != null)
            {
                try
                {
                    if (origin != null) {
                        if (origin.ToArray().FirstOrDefault().Contains("localhost"))
                            return;

                        if (origin.ToArray().FirstOrDefault() != DEFAULT_URL)
                            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acesso não autorizado");
                    }

                    if (acaorigin != null)
                    {
                        if (acaorigin.ToArray().FirstOrDefault().Contains("localhost"))
                            return;

                        if (acaorigin.ToArray().FirstOrDefault() != DEFAULT_URL)
                            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acesso não autorizado");
                    }
                }
                catch (Exception) { actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acesso não autorizado"); }
            }
            else
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acesso não autorizado");
        }
    }
}