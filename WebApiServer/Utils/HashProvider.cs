// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HashProvider.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the HashProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Utils
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// The hash provider.
    /// </summary>
    internal static class HashProvider
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        internal static string Get(string text)
        {
            var input = Encoding.Unicode.GetBytes($"s3cr3t++{text}::s@lt");
            return string.Concat(MD5.Create().ComputeHash(input).Select(b => b.ToString("x2")));
        }
    }
}