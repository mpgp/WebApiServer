namespace WebApiServer.Services
{
    using System.Data;
    using Models;
    
    // ReSharper disable once ClassNeverInstantiated.Global
    public class UserDatabaseFile : IUserDatabase
    {
        private string FilePath { get; }
        private DataSet DataSet { get; } = new DataSet("Users");
        private DataTable DataTable { get; } = new DataTable("UserModel");
        
        public UserDatabaseFile()
        {
            FilePath = "App_Data/Users.xml";
            DataTable.Columns.Add(new DataColumn("Id"));
            DataTable.Columns.Add(new DataColumn("Login"));
            DataTable.Columns.Add(new DataColumn("Password"));
            DataSet.Tables.Add(DataTable);
            DataSet.ReadXml(FilePath);
        }
        
        public UserModel Add(UserModel userModel)
        {
            userModel.Id = DataTable.Rows.Count + 1;
            DataTable.Rows.Add(userModel.Id, userModel.Login, userModel.Password);
            DataSet.WriteXml(FilePath);
            return userModel;
        }

        public UserModel Find(UserModel userModel)
        {
            var rows = DataTable.Select($"Login = '{userModel.Login}' AND Password = '{userModel.Password}'");
            if (rows.Length == 0)
            {
                return null;
            }
            
            var row = rows[0];
            var model = new UserModel(int.Parse((string)row["Id"]), (string)row["Login"], (string)row["Password"]);
            return model;
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
            var rows = DataTable.Select($"Login = '{userModel.Login}'");
            return rows.Length > 0;
        }
    }
}
