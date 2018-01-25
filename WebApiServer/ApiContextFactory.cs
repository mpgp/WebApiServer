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
    using Microsoft.Extensions.Configuration;
    
    public class ApiContextFactory : IDesignTimeDbContextFactory<Models.ApiContext>
    {
        public Models.ApiContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<Models.ApiContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new Models.ApiContext(builder.Options);
        }
    }
}
