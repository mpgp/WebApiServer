// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitialUsersSeeder.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the InitialUsersSeeder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------------------------------------
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
                    new UserModel("loktionov129", "43b778bf33164eb9a09b278aaef2c783"),
                    new UserModel("Scorpio92", "0b537c6d4cb2f679641b853e92c63dfc"));
                context.SaveChanges();
            }
        }
    }
}
