using Project_3._0.Data.Repositories;
using Project_3._0.Model.Domain;

namespace Project_3._0.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepositories;
        public UserServices(IUserRepository userRepositories)
        {
            _userRepositories = userRepositories;
        }
        public User Authorize(string login, string password)
        {
            return _userRepositories.Login(login, password);
        }
    }
}
