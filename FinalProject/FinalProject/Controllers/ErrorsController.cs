using FinalProject.BusinessLogic.ErrorResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FinalProject.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public MyErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; 
            
            if(exception is HttpStatusException httpStatusException)
            {
                var status = (int)httpStatusException.StatusCode;
                var errorResponse = new MyErrorResponse(exception,status);
                Response.StatusCode = status;
                return errorResponse;
            }
            var errorResponseDefault = new MyErrorResponse(exception, 500);
            
            return errorResponseDefault;
        }
    }
}
