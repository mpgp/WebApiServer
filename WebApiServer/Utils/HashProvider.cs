namespace WebApiServer.Utils
{
    using System.Text;
    using System.Linq;
    using System.Security.Cryptography;
    
    internal static class HashProvider
    {
        internal static string Get(string text)
        {
            var input = Encoding.Unicode.GetBytes(text);
            return string.Concat(MD5.Create().ComputeHash(input).Select(b => b.ToString("x2")));
        }
    }
}