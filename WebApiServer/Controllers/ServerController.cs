using System.Linq;

namespace WebApiServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Models;
    using Utils;

    /// <inheritdoc />
    [Route("api/[controller]")]
    public class ServerController : BaseController
    {
        public ServerController(IOptions<WebSocketServerOptions> webSocketServerOptions)
        {
            WebSocketServers = webSocketServerOptions.Value.WebSocketServer.ToArray();
        }
        
        private WebSocketServer[] WebSocketServers { get; }

        [HttpGet]
        public ActionResult GetServers()
        {
            return GetResponseData(WebSocketServers);
        }
        
        [Route("{code}")]
        [HttpGet]
        public ActionResult GetServer(string code)
        {
            return GetResponseData(WebSocketServers.FirstOrDefault(server => server.Code == code));
        }
    }
}