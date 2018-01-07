// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthController.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the AuthController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <inheritdoc />
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="users">
        /// The users.
        /// </param>
        public AuthController(Database.Users users)
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
        public int Post([FromBody]UserModel authData)
        {
            return Users.Find(user => user.Login == authData.Login && user.Password == authData.Password)
                   ?.Id
                   ?? 0;
        }
    }
}
