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
    using System.ComponentModel.DataAnnotations;
    
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
        /// Initializes a new instance of the <see cref="UserModel"/> class.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        public UserModel(string login, string password)
        {
            Login = login;
            Password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserModel"/> class.
        /// </summary>
        public UserModel()
        {
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        [Required(ErrorMessage = "LOGIN.REQUIRED")]
        [MinLength(3, ErrorMessage = "LOGIN.MIN_LENGTH")]
        [MaxLength(12, ErrorMessage = "LOGIN.MAX_LENGTH")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "LOGIN.REGEX")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required(ErrorMessage = "PASSWORD.REQUIRED")]
        [MinLength(8, ErrorMessage = "PASSWORD.MIN_LENGTH")]
        [MaxLength(249, ErrorMessage = "PASSWORD.MAX_LENGTH")]
        public string Password { get; set; }
    }
}
