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
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    /// <inheritdoc />
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="db">
        /// The users.
        /// </param>
        public AccountController(ApiContext db)
        {
            Db = db;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        private ApiContext Db { get; }

        /// <summary>
        /// The auth.
        /// </summary>
        /// <param name="userData">
        /// The user data.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Auth([FromBody]UserModel userData)
        {
            if (!ModelState.IsValid)
            {
                return GetValidationErrors();
            }

            var foundUser = Db.Users.FirstOrDefault(
                user => user.Login == userData.Login && user.Password == Utils.HashProvider.Get(userData.Password));

            if (foundUser == null)
            {
                return Json(
                    new { Errors = new[] { new { Code = "NOT_FOUND", Message = "Incorrect login or password" } } });
            }

            return Json(new { AuthToken = GetAuthToken(foundUser) });
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
        public ActionResult Register([FromBody]UserModel userData)
        {
            if (!ModelState.IsValid)
            {
                return GetValidationErrors();
            }

            var foundUser = Db.Users.FirstOrDefault(user => user.Login == userData.Login);
            if (foundUser != null)
            {
                return Json(
                    new { Errors = new[] { new { Code = "ALREADY_EXISTS", Message = "Login already exists" } } });
            }

            userData.Password = Utils.HashProvider.Get(userData.Password);
            var newUser = Db.Users.Add(userData).Entity;
            Db.SaveChanges();

            return Json(new { AuthToken = GetAuthToken(newUser) });
        }

        /// <summary>
        /// The generate auth token.
        /// </summary>
        /// <param name="userData">
        /// The user data.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetAuthToken(UserModel userData)
        {
            var timestamp = (int)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1)).TotalSeconds;
            var userTokenData = Db.UsersTokens.FirstOrDefault(userToken => userToken.UserId == userData.Id);
            if (userTokenData == null)
            {
                var token = Utils.HashProvider.Get(userData.Login + timestamp);
                userTokenData = new UserTokenModel() { CreatedAt = timestamp, Token = token, UserId = userData.Id, };
                Db.UsersTokens.Add(userTokenData);
            }
            else
            {
                userTokenData.CreatedAt = timestamp;
            }

            Db.SaveChanges();

            return userTokenData.Token;
        }

        /// <summary>
        /// The get validation errors.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        private ActionResult GetValidationErrors()
        {
            return Json(
                new
                {
                    Errors = new[]
                                     {
                                         new
                                             {
                                                 Code = "INVALID_MODEL",
                                                 Message = string.Join(
                                                     "; ",
                                                     ModelState.Values.SelectMany(x => x.Errors)
                                                         .Select(x => x.ErrorMessage))
                                             }
                                     }
                });
        }
    }
}