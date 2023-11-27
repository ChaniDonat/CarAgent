using AutoMapper;
using BuisnessLogic.Service;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _CarService;
        Mapper _Mapper;
        public CarController(ICarService CarService)
        {
            _CarService = CarService;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<List<Car>> GetAllCarsAsync()
        {
           //List<Car> cars=
              return  await _CarService.GetAllCarsAsync();
            //return _Mapper.Map<List<CarDto>>(cars);
        }

        // GET api/<CompanyController>/5
        //[HttpGet("{id}")]
        [HttpGet, Route("GetCarByIdAsync/{id}")]
        public async Task<Car> GetCarByIdAsync(int id)
        {
            //Car car= 
              return  await _CarService.GetCarByIdAsync(id);
            //return _Mapper.Map<CarDto>(car);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task AddCar(Car car)
        {
            //Car car = _Mapper.Map<Car>(carDto);
            await _CarService.AddCar(car);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task UpdateCarById(Car carDto, int id)
        {
            //Car car = _Mapper.Map<Car>(carDto);
            await _CarService.UpdateCarById(carDto, id);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _CarService.Delete(id);
        }
        [HttpGet]
        [Route("GetFilterCars/{companyid}/{modelName}/{fromYear}/{untilYear}/{fromPrice}/{untilPrice}/{codeRegion}")]
        public async Task<ActionResult<List<Car>>> GetFilterCars(int companyid = -1, string modelName = "defaultValue", int fromYear = -1, int untilYear = -1, int fromPrice = -1, int untilPrice = -1, int codeRegion = -1)
        {
            List<Car> list = await _CarService.GetFilterCars(companyid, modelName, fromYear, untilYear, fromPrice, untilPrice, codeRegion);
            if (list.Count > 0)
            {
                return Ok(list);
            }

            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("Search")]
        public async Task SerchParameters(string parameters)
        {
            await _CarService.AddSearchLogging(parameters);
        }
    }
}
