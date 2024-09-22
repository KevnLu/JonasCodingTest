using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApi.Models;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private ILog _log;
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            log4net.Config.XmlConfigurator.Configure();
            _log = LogManager.GetLogger("WebServiceLogger");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            
            _log.Error(exception.Message+Environment.NewLine+exception.StackTrace);

            HttpContext httpContext = ((WebApiApplication)sender).Context;
            HttpResponse response = httpContext.Response;

            // Customize the response for unhandled exceptions
            response.Clear();
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.ContentType = "application/json";

            var errorResponse = new ErrorResponse
            {
                ErrorMessage = "An unexpected error occurred. Please try again later.",
                ErrorCode = "500",
                ErrorDetails = exception.Message
            };

            // Serialize and return the error response
            response.Write(JsonConvert.SerializeObject(errorResponse));
            Server.ClearError();
        }
    }
}
