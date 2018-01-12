// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Users.cs" company="mpgp">
//   Multiplayer Game Platform
// </copyright>
// <summary>
//   Defines the Users type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApiServer.Database
{
    /// <inheritdoc />
    public class Users : System.Collections.Generic.List<Models.UserModel>
    {
        /// <inheritdoc />
        public Users()
        {
            Add(new Models.UserModel(1, "loktionov129", "asdafafavwfvttwet"));
            Add(new Models.UserModel(2, "Scorpio92", "cmowwoermhgomodsg"));
        }
    }
}
