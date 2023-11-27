using DataAccess.DBModels;
using DataAccess.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Service
{
    public class UserService : IUserService
    {
        IUserRepository _UserRepository;
        ILogger logger;
        public UserService(IUserRepository UserRepository, ILogger<UserService> logger)
        {
            _UserRepository = UserRepository;
            logger = logger;
        }
        public async Task AddUser(User user)
        {
            try
            {
               await _UserRepository.AddUser(user);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from user service, the exception:" + ex.Message);
                throw new Exception("Error in AddUser_Service function:" + ex.Message);

            }


        }

        public async Task AddUserFavorites(int carId, int userId)
        {
            try
            {
               await _UserRepository.AddUserFavorites(carId, userId);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from user service, the exception:" + ex.Message);
                throw new Exception("Error in AddUser_Service function:" + ex.Message);

            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _UserRepository.Delete(id);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from user service, the exception:" + ex.Message);
                throw new Exception("Error in DeleteUser_Service function:" + ex.Message);

            }



        }

        public async Task DeleteUserFavorites(int carId, int userId)
        {
            try
            {
                await  _UserRepository.DeleteUserFavorites(carId, userId);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from user service, the exception:" + ex.Message);
                throw new Exception("Error in DeleteUserFavorites_Service function:" + ex.Message);
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _UserRepository.GetAllUsersAsync();

            }
            catch (Exception ex)
            {
                logger.LogError("logging from user service, the exception:" + ex.Message);
                throw new Exception("Error in GetAllUsersAsync_Service function:" + ex.Message);

            }

        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await _UserRepository.GetUserByIdAsync(id);

            }
            catch (Exception ex)
            {
                logger.LogError("logging from user service, the exception:" + ex.Message);
                throw new Exception("Error in GetUserByIdAsync_Service function:" + ex.Message);

            }

        }

        public async Task UpdateUserById(User user, int id)
        {
            try
            {
                await _UserRepository.UpdateUserById(user, id);

            }
            catch (Exception ex)
            {
                logger.LogError("logging from user service, the exception:" + ex.Message);
                throw new Exception("Error in UpdateUserById_Service function:" + ex.Message);

            }

        }
    }
}
