// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the BaseController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
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

        /// <summary>
        /// The get processing errors.
        /// </summary>
        /// <param name="errorCodes">
        /// The error codes.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        protected ActionResult GetProcessingErrors(string[] errorCodes)
        {
            return Json(new { errors = errorCodes });
        }

        /// <summary>
        /// The get response data.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        protected ActionResult GetResponseData(object data)
        {
            return Json(new { data });
        }
    }
}