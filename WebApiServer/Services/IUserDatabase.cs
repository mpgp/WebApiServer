namespace WebApiServer.Services
{
    using Models;    
    
    public interface IUserDatabase
    {
        UserModel Add(UserModel userModel);
        UserModel Find(UserModel userModel);
        UserModel Remove(UserModel userModel);
        UserModel Update(UserModel userModel);
        bool UserExists(UserModel userModel);
    }
}
