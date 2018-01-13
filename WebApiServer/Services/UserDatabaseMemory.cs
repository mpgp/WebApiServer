namespace WebApiServer.Services
{
    using Models;
    
    public class UserDatabaseMemory : IUserDatabase
    {
        private System.Collections.Generic.List<UserModel> Users { get; }
        
        public UserDatabaseMemory()
        {
            Users = new System.Collections.Generic.List<UserModel>();
            Add(new UserModel(1, "loktionov129", "asdafafavwfvttwet"));
            Add(new UserModel(2, "Scorpio92", "cmowwoermhgomodsg"));
        }
        
        public UserModel Add(UserModel userModel)
        {
            userModel.Id = Users.Count + 1;
            Users.Add(userModel);
            return userModel;
        }

        public UserModel Find(UserModel userModel)
        {
            return Users.Find(user => user.Login == userModel.Login && user.Password == userModel.Password);
        }

        public UserModel Remove(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public UserModel Update(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
