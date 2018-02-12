// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the UserController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <inheritdoc />
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="db">
        /// The users.
        /// </param>
        public UserController(ApiContext db)
        {
            Db = db;
        }
        
        /// <summary>
        /// Gets the users.
        /// </summary>
        private ApiContext Db { get; }
        
        /// <summary>
        /// The get avatar.
        /// </summary>
        /// <param name="login">
        /// The user login.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Route("{login}/avatar.jpg")]
        [HttpGet]
        public ActionResult GetAvatar(string login)
        {
            var userModel = Db.Users.FirstOrDefault(user => user.Login == login);
            var parts = new[]
            {
                System.AppDomain.CurrentDomain.BaseDirectory,
                "wwwroot",
                "images",
                "avatars",
                userModel?.Avatar ?? "0.jpg"
            };
            var path = string.Join(System.IO.Path.DirectorySeparatorChar, parts);
            var image = System.IO.File.OpenRead(path);
            return File(image, "image/jpeg");
        }
    }
}