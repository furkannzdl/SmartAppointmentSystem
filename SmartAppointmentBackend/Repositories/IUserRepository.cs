using SmartAppointmentBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartAppointmentBackend.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

    }
}
