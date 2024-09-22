using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Filters;

namespace WebApi.ActionFilters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private ILog _log;

        public GlobalExceptionFilter()
        {
            _log = LogManager.GetLogger("WebServiceLogger");
        }
        public override void OnException(HttpActionExecutedContext context)
        {
            _log.Error(context.Exception.Message + Environment.NewLine + context.Exception.StackTrace);

            if (context.Exception is ArgumentException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Invalid argument."),
                    ReasonPhrase = "Bad Request"
                };
            }
            //else if: if other exception type should have custom handling
            else
            {
                // By default, return a 500 error with a generic message
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An error occurred, please try again later."),
                    ReasonPhrase = "Internal Server Error"
                };
            }
        }
    }
}