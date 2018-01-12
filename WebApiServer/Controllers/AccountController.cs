// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the AccountController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <inheritdoc />
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="users">
        /// The users.
        /// </param>
        public AccountController(Database.Users users)
        {
            Users = users;
        }

        /// <summary>
        /// The Users.
        /// </summary>
        private Database.Users Users { get; }

        /// <summary>
        /// The auth.
        /// </summary>
        /// <param name="userData">
        /// The user data.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [HttpPost]
        public int Auth([FromBody]UserModel userData)
        {
            return Users.Find(user => user.Login == userData.Login && user.Password == userData.Password)
                   ?.Id
                   ?? 0;
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="userData">
        /// The user data.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [HttpPut]
        public int Register([FromBody]UserModel userData)
        {
            if (Users.Find(user => user.Login == userData.Login) != null)
            {
                return -1;
            }

            var newUser = new UserModel(Users.Count + 1, userData.Login, userData.Password);
            Users.Add(newUser);
            return newUser.Id;
        }
    }
}
