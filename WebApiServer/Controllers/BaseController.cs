namespace WebApiServer.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    
    public class BaseController : Controller
    {
        /// <summary>
        /// The get validation errors.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        protected ActionResult GetValidationErrors()
        {
            return Json(
                new
                {
                    errors = ModelState.Values.SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToArray()
                });
        }

        protected ActionResult GetProcessingErrors(string[] errorCodes)
        {
            return Json(new { errors = errorCodes });
        }

        protected ActionResult GetResponseData(object data)
        {
            return Json(new {data});
        }
    }
}