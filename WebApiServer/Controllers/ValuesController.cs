// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValuesController.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the AuthModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <inheritdoc />
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValuesController"/> class.
        /// </summary>
        /// <param name="users">
        /// The users.
        /// </param>
        public ValuesController(Database.Users users)
        {
            Users = users;
            Users.Add(new UserModel()
            {
                Id = 1,
                Login = "loktionov129",
                Password = "asdafafavwfvttwet"
            });
            Users.Add(new UserModel()
            {
                Id = 2,
                Login = "Scorpio92",
                Password = "cmowwoermhgomodsg"
            });
        }

        /// <summary>
        /// The Users.
        /// </summary>
        private Database.Users Users { get; }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="authData">
        /// The auth data.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [HttpPost]
        public string Post([FromBody]AuthModel authData)
        {
            return Users.Find(user => user.Login == authData.Login && user.Password == authData.Password) == null
                       ? "ERROR"
                       : "SUCCESS";
        }

        /// <summary>
        /// The auth model.
        /// TODO: Transfer this model to ./Models
        /// </summary>
        public class AuthModel
        {
            /// <summary>
            /// Gets or sets the login.
            /// </summary>
            public string Login { get; set; }

            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            public string Password { get; set; }
        }
    }
}
