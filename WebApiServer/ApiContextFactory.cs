// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiContextFactory.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the ApiContextFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    
    public class ApiContextFactory : IDesignTimeDbContextFactory<Models.ApiContext>
    {
        public Models.ApiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Models.ApiContext>();
            optionsBuilder.UseSqlite("Data Source=master.db");

            return new Models.ApiContext(optionsBuilder.Options);
        }
    }
}
