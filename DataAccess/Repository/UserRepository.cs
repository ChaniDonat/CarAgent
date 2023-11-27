using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        DBAgentContext _DBAgentContext;
        public UserRepository(DBAgentContext DBAgentContext)
        {
            _DBAgentContext = DBAgentContext;
        }
        public async Task AddUser(User user)
        {
            try
            {
                _DBAgentContext.Users.Add(user);
               await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddUser_Repository function:" + ex.Message);

            }
        }


        public async Task Delete(int id)
        {
            try
            {
                _DBAgentContext.Remove(_DBAgentContext.Users.Find(id));
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteUser_Repository function:" + ex.Message);
            }


        }


        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _DBAgentContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetAllUsersAsync_Repository function:" + ex.Message);
            }


        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await _DBAgentContext.Users.SingleOrDefaultAsync(u => u.UserId == id);

            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetUserByIdAsync_Repository function:" + ex.Message);

            }


        }

        public async Task UpdateUserById(User user, int id)
        {
            try
            {
                _DBAgentContext.Users.Update(user);
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UpdateUserById_Repository function:" + ex.Message);
            }


        }
        public async Task AddUserFavorites(int carId, int userId)
        {
            try
            {
                UserFavorite userFavorite = new UserFavorite();
                userFavorite.UserId = userId;
                userFavorite.CarId = carId;
                await _DBAgentContext.AddAsync(userFavorite);
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddUserFavorites_Repository function:" + ex.Message);
            }
        }
        public async Task DeleteUserFavorites(int carId, int userId)
        {
            //try
            //{
            //    _DBAgentContext.Remove(_DBAgentContext.UserFavorites.Find(carId));
            //    await _DBAgentContext.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in DeleteUserFavorites_Repository function:" + ex.Message);
            //}
            //try
            //{
            //    UserFavorite uf = await _DBAgentContext.UserFavorites.FindAsync(carId);

            //    if (uf != null)
            //    {
            //        _DBAgentContext.UserFavorites.Remove(uf);
            //        await _DBAgentContext.SaveChangesAsync();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error in DeleteUserFavorites_Repository function:" + ex.Message);
            //}
            try
            {
                var favoraitesId = await (from u in _DBAgentContext.UserFavorites
                                          where u.UserId == userId && u.CarId == carId
                                          select u).ToListAsync();
                foreach (var f in favoraitesId)
                {
                    _DBAgentContext.UserFavorites.Remove(f);

                }
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                 throw new Exception("Error in DeleteUserFavorites_Repository function:" + ex.Message);

            }

        }
    }

}

