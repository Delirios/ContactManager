using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Repositories
{
    public interface IContactManagerRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int userId);
        Task EditUser(User user);
        Task DeleteUser(int userId);
        Task AddUser(IFormFile file);
    }
}
