
using Project_3._0.Model.Domain;
using System.Data.SqlClient;

namespace Project_3._0.Data.Repositories.Implementations
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public User Login(string username, string password)
        {
            User user = new User();
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "use ComopanyProgect; select *from Users where LoginName=@user and Password=@pass";
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    //cmd.Parameters.AddWithValue("@id", UserLoginCache.IdUser);
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.IdUser = reader.GetInt32(0);
                            user.FirstName = reader.GetString(3);
                            user.LastName = reader.GetString(4);
                            // user.Email = reader.GetString(5);
                            user.Position = reader.GetInt32(6);
                            user.Archive = reader.GetInt32(7);
                            if (user.Archive == 0 && user.Position == 2)
                                return user = new User();
                        }                        
                    }
                }
                return user;
            }
        }
    }
}
