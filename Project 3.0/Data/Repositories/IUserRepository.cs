using Project_3._0.Model.Domain;

namespace Project_3._0.Data.Repositories
{
    public interface IUserRepository
    {
        public User Login(string username, string password);
    }
}
