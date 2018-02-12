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
    using System.Linq;
    using System.Net;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

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
            // ReSharper disable once StyleCop.SA1115
            services.AddCors(
                o => o.AddPolicy(
                    "MyPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
            }));
            var connection = Configuration.GetConnectionString("DefaultConnection");
#if !DEBUG
            services.AddEntityFrameworkNpgsql().AddDbContext<Models.ApiContext>(options => options.UseNpgsql(connection));
#else
            services.AddDbContext<Models.ApiContext>(options => options.UseSqlServer(connection));
#endif
            services.Configure<Utils.WebSocketServerOptions>(Configuration.GetSection("Params"));
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
            app.Use(async (context, next) =>
            {
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
                        context.Response.ContentType = "text/html";
                        await context.Response.SendFileAsync("wwwroot/errors/404.html");
                    }
                }
            });
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    options =>
                    {
                        options.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                context.Response.ContentType = "text/html";
                                var ex = context.Features.Get<IExceptionHandlerFeature>();
                                if (ex != null)
                                {
                                    await context.Response.SendFileAsync("wwwroot/errors/500.html");
                                }
                            });
                });
            }

            app.UseMvc();
        }

        /// <summary>
        /// The is front end route.
        /// </summary>
        /// <param name="route">
        /// The route.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsFrontEndRoute(string route)
        {
            return RouteIsAbsolute(route) || RouteIsRelative(route);
        }

        /// <summary>
        /// The route is absolute.
        /// </summary>
        /// <param name="route">
        /// The route.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool RouteIsAbsolute(string route)
        {
            return Configuration.GetSection("Params:FrontEndRoutes:Absolute").GetChildren()
                       .FirstOrDefault(absoluteRoute => route == absoluteRoute.Value) != null;
        }

        /// <summary>
        /// The route is relative.
        /// </summary>
        /// <param name="route">
        /// The route.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool RouteIsRelative(string route)
        {
            return Configuration.GetSection("Params:FrontEndRoutes:Relative").GetChildren()
                       .FirstOrDefault(absoluteRoute => route.StartsWith(absoluteRoute.Value)) != null;
        }
    }
}
