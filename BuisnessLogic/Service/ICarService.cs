using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Service
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCarsAsync();

        Task<Car> GetCarByIdAsync(int id);
        Task AddCar(Car car);
        Task UpdateCarById(Car car, int id);
        Task Delete(int id);
        Task<List<Car>> GetFilterCars(int companyid, string modelName, int fromYear, int untilYear, int fromPrice, int untilPrice, int codeRegion);
        public Task AddSearchLogging(string searchParameters);
        Task AddBeforeSearchLogging(string searchParameters);


    }
}
