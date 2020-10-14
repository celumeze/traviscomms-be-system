using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravisComms.Api.Helpers;
using TravisComms.CsvProcessing.Exceptions;

namespace TravisComms.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("exceptionerror")]
        public string ErrorResponse()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exceptionThrown = context?.Error;
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            
            switch(exceptionThrown)
            {
                case ContactsCsvException contactsCsvException:
                    return contactsCsvException.Message;
                default:
                    return Constants.GlobalExceptionMessage;
            }            
        }
    }
}
