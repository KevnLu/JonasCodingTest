using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ErrorResponse
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDetails { get; set; }
    }
}