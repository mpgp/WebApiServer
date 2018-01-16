// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiContext.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the ApiContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public class ApiContext : DbContext
    {
        /// <inheritdoc />
        public ApiContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// Gets or sets the users tokens.
        /// </summary>
        public DbSet<UserTokenModel> UsersTokens { get; set; }
    }
}
