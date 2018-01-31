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
                    new UserModel(1, "system", "041bdee79a796bfc6778be35478e1448"),
                    new UserModel(2, "admin", "9596df50d7e110a71ad2f53d21ff3228"));
                context.SaveChanges();
            }
        }
    }
}
