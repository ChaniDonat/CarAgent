using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUser(User user);
        Task UpdateUserById(User user, int id);
        Task Delete(int id);
        public Task AddUserFavorites(int carId, int userId);
        public Task DeleteUserFavorites(int carId, int userId);
    }
}

