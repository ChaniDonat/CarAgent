using AutoMapper;
using BuisnessLogic.Service;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarAgent.Controllers
{
    namespace CarAgent.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            IUserService _UserService;
            IMapper _Mapper;
            public UserController(IUserService userService, IMapper mapper)
            {
                _UserService = userService;
                _Mapper = mapper;
            }
            // GET: api/<CompanyController>
            [HttpGet]
            public async Task<List<UserDto>> GetAllUserAsync()
            {
               List <User> users= await _UserService.GetAllUsersAsync();
                return _Mapper.Map <List< UserDto>>(users);
            }

            // GET api/<CompanyController>/5
            [HttpGet("{id}")]
            public async Task<UserDto> GetUserIdAsync(int id)
            {
                User uses = await _UserService.GetUserByIdAsync(id);
                return _Mapper.Map<UserDto>(uses);
             
            }

            // POST api/<CompanyController>
            [HttpPost]
            public async Task AddUser(UserDto userDto)
            {
                User user = _Mapper.Map<User>(userDto);
                await _UserService.AddUser(user);
            }

            // PUT api/<CompanyController>/5
            [HttpPut("{id}")]
            public async Task UpdateUserById(UserDto userDto, int id)
            {
                User user = _Mapper.Map<User>(userDto);
                await _UserService.UpdateUserById(user, id);
            }

            // DELETE api/<CompanyController>/5
            [HttpDelete("{id}")]
            public async Task Delete(int id)
            {
                await _UserService.Delete(id);
            }
            [HttpPost]
            [HttpPost, Route("AddCarToFavorite/{carId}/{userId}")]
            public async Task AddUserFavorites(int carId, int userId)
            {
                try
                {
                    UserFavorite u = new UserFavorite();
                    u.CarId = carId;
                    u.UserId = userId;
                    var a = _Mapper.Map<UserFavorite>(u);
                    await _UserService.AddUserFavorites(a.CarId, a.UserId);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in AddCarToFavorite_Controller function:" + ex.Message);
                }
            }
            [HttpDelete()]
            [HttpDelete, Route(" DeleteCarToFavorite/{carId}/{userId}")]
            public async Task DeleteUserFavorites(int carId, int userId)
            {
                try
                {
                    await _UserService.DeleteUserFavorites(carId, userId);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in DeleteUserFavorites_Controller function:" + ex.Message);
                }

            }
        }
    }
}