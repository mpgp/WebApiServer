// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebSocketServerOptions.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the WebSocketServerOptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Utils
{
    using Models;

    /// <summary>
    /// The web socket server options.
    /// </summary>
    public class WebSocketServerOptions
    {
        /// <summary>
        /// Gets or sets the web socket server.
        /// </summary>
        public WebSocketServer[] WebSocketServer { get; set; }
    }
}
