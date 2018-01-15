﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitialUsersSeeder.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the InitialUsersSeeder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Seeds
{
    using System.Linq;
    using WebApiServer.Models;

    /// <summary>
    /// The initial users seeder.
    /// </summary>
    public static class InitialUsersSeeder
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void Initialize(ApiContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new UserModel("Loktionov129", "941bdee79a796bfc6778eb35478e34f6"),
                    new UserModel("Scorpio92", "0596df50d7e110a71da2f53d21ff3669"));
                context.SaveChanges();
            }
        }
    }
}
