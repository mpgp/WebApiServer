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
        public int Auth([FromBody]UserModel userData)
        {
            if (!ModelState.IsValid)
            {
                System.Console.WriteLine("Model isn't valid! Errors:");
                System.Console.WriteLine(string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));                
            }
            else
            {
                System.Console.WriteLine("Model is valid!");
            }

            var foundUser = Db.Users.FirstOrDefault(
                user => user.Login == userData.Login && user.Password == Utils.HashProvider.Get(userData.Password));

            return foundUser?.Id ?? 0;
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
            if (!ModelState.IsValid)
            {
                System.Console.WriteLine("Model isn't valid! Errors:");
                System.Console.WriteLine(string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            }
            else
            {
                System.Console.WriteLine("Model is valid!");
            }

            var foundUser = Db.Users.FirstOrDefault(user => user.Login == userData.Login);
            if (foundUser != null)
            {
                return 0;
            }

            userData.Password = Utils.HashProvider.Get(userData.Password);
            var newUser = Db.Users.Add(userData).Entity;
            Db.SaveChanges();

            return newUser?.Id ?? 0;
        }
    }
}
