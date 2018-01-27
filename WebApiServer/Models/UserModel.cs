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
        [Required(ErrorMessage = Errors.LoginRequired)]
        [MinLength(3, ErrorMessage = Errors.LoginMinLength)]
        [MaxLength(12, ErrorMessage = Errors.LoginMaxLength)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = Errors.LoginRegex)]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required(ErrorMessage = Errors.PasswordRequired)]
        [MinLength(8, ErrorMessage = Errors.PasswordMinLength)]
        [MaxLength(249, ErrorMessage = Errors.PasswordMaxLength)]
        public string Password { get; set; }

        /// <summary>
        /// The errors.
        /// </summary>
        private static class Errors
        {
            /// <summary>
            /// The error codes.
            /// </summary>
            public const string LoginRequired = "1",
                LoginMinLength = "2",
                LoginMaxLength = "3",
                LoginRegex = "4",
                PasswordRequired = "5",
                PasswordMinLength = "6",
                PasswordMaxLength = "7";
        }
    }
}
