using System.Linq;

namespace WebApiServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Utils;

    /// <inheritdoc />
    [Route("api/[controller]")]
    public class ServerController : Controller
    {
        public ServerController(IOptions<WebSocketServerOptions> webSocketServerOptions)
        {
            WebSocketServers = webSocketServerOptions.Value.WebSocketServer.ToArray();
        }
        
        private WebSocketServer[] WebSocketServers { get; }

        [HttpGet]
        public ActionResult GetServers()
        {
            return Json(WebSocketServers);
        }
        
        [Route("{code}")]
        [HttpGet]
        public ActionResult GetServer(string code)
        {
            return Json(WebSocketServers.FirstOrDefault(server => server.Code == code));
        }
    }
}