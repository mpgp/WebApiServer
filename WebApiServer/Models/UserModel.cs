// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserModel.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the UserModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Models
{
    /// <summary>
    /// The user model.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserModel"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        public UserModel(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
