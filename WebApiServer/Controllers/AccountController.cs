﻿// --------------------------------------------------------------------------------------------------------------------
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
    public class AccountController : BaseController
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
                return GetProcessingErrors(new[] { Errors.IncorrectLoginOrPassword });
            }

            return GetResponseData(new { Token = GetAuthToken(foundUser) });
        }

        /// <summary>
        /// The check token.
        /// </summary>
        /// <param name="tokenData">
        /// The token data.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPatch]
        public ActionResult CheckToken([FromBody]UserTokenModel tokenData)
        {
            var userTokenData = Db.UsersTokens.FirstOrDefault(userToken => userToken.Token == tokenData.Token);
            if (userTokenData == null)
            {
                return GetResponseData(new { Status = 0 });
            }

            var timestamp = (int)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1)).TotalSeconds;
            userTokenData.CreatedAt = timestamp;
            Db.SaveChanges();
            return GetResponseData(new { Status = 1 });
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
                return GetProcessingErrors(new[] { Errors.LoginAlreadyExists });
            }

            userData.Password = Utils.HashProvider.Get(userData.Password);
            var newUser = Db.Users.Add(userData).Entity;
            Db.SaveChanges();

            return GetResponseData(new { Token = GetAuthToken(newUser) });
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
        /// The errors.
        /// </summary>
        private static class Errors
        {
            /// <summary>
            /// The error codes.
            /// </summary>
            public const string LoginAlreadyExists = "1000",
                IncorrectLoginOrPassword = "1001";
        }
    }
}