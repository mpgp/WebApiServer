namespace WebApiServer.Services
{
    using Models;
    
    // ReSharper disable once UnusedMember.Global
    public class UserDatabaseMemory : IUserDatabase
    {
        private System.Collections.Generic.List<UserModel> Users { get; }
        
        public UserDatabaseMemory()
        {
            Users = new System.Collections.Generic.List<UserModel>
            {
                new UserModel(1, "loktionov129", "43b778bf33164eb9a09b278aaef2c783"),
                new UserModel(2, "Scorpio92", "0b537c6d4cb2f679641b853e92c63dfc")
            };
        }
        
        public UserModel Add(UserModel userModel)
        {
            userModel.Id = Users.Count + 1;
            userModel.Password = Utils.HashProvider.Get(userModel.Password);
            Users.Add(userModel);
            return userModel;
        }

        public UserModel Find(UserModel userModel)
        {
            return Users.Find(user
                => user.Login == userModel.Login
                   && user.Password == Utils.HashProvider.Get(userModel.Password)
            );
        }

        public UserModel Remove(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public UserModel Update(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public bool UserExists(UserModel userModel)
        {
            return Users.Find(user => user.Login == userModel.Login) != null;
        }
    }
}
