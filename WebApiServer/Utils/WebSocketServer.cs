namespace WebApiServer.Utils
{
    public class WebSocketServer
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    
    public class WebSocketServerOptions
    {        
        public WebSocketServer[] WebSocketServer { get; set; }
    }
}