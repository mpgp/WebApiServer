// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   The startup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    /// <summary>
    /// The startup.
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IConfiguration Configuration { get; }

        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Configure Policy
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Models.ApiContext>(options => options.UseSqlServer(connection));
            services.AddMvc();
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("MyPolicy");
            app.Use(async (context, next) => {
                await next();
                
                if (context.Response.StatusCode == 404)
                {
                    if (IsFrontEndRoute(context.Request.Path.Value))
                    {
                        context.Request.Path = "/index.html";
                        await next();
                    }
                    else
                    {
                        context.Response.Redirect("/");
                    }
                }
            });
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
        
        private bool IsFrontEndRoute(string route)
        {
            return RouteIsAbsolute(route) || RouteIsRelative(route);
        }
        
        private bool RouteIsAbsolute(string route)
        {
            return Configuration.GetSection("Params:FrontEndRoutes:Absolute").GetChildren()
                       .FirstOrDefault(absoluteRoute => route == absoluteRoute.Value) != null;
        }
        
        private bool RouteIsRelative(string route)
        {
            return Configuration.GetSection("Params:FrontEndRoutes:Relative").GetChildren()
                       .FirstOrDefault(absoluteRoute => route.StartsWith(absoluteRoute.Value)) != null;
        }
    }
}