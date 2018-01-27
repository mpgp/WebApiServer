// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerController.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the ServerController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Models;
    using Utils;

    /// <inheritdoc />
    [Route("api/[controller]")]
    public class ServerController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerController"/> class.
        /// </summary>
        /// <param name="webSocketServerOptions">
        /// The web socket server options.
        /// </param>
        public ServerController(IOptions<WebSocketServerOptions> webSocketServerOptions)
        {
            WebSocketServers = webSocketServerOptions.Value.WebSocketServer.ToArray();
        }

        /// <summary>
        /// Gets the web socket servers.
        /// </summary>
        private WebSocketServer[] WebSocketServers { get; }

        /// <summary>
        /// The get servers.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult GetServers()
        {
            return GetResponseData(WebSocketServers);
        }

        /// <summary>
        /// The get server.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Route("{code}")]
        [HttpGet]
        public ActionResult GetServer(string code)
        {
            return GetResponseData(WebSocketServers.FirstOrDefault(server => server.Code == code));
        }
    }
}