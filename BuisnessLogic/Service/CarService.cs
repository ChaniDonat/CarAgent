using DataAccess.DBModels;
using DataAccess.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Service
{
    public class CarService : ICarService
    {
        ICarRepository _CarRepository;
        ILogger logger;
        public CarService(ICarRepository CarRepository, ILogger<CarService> logger)
        {
            _CarRepository = CarRepository;
           this.logger = logger;
        }
        public async Task AddCar(Car car)
        {
            try
            {
                await _CarRepository.AddCar(car);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from car service, the exception:" + ex.Message);

                throw new Exception("Error in AddCar_Service function:" + ex.Message);

            }

        }


        public async Task Delete(int id)
        {
            try
            {
                await _CarRepository.Delete(id);

            }
            catch (Exception ex)
            {
                logger.LogError("logging from car service, the exception:" + ex.Message);

                throw new Exception("Error in Delete_Service function:" + ex.Message);

            }
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            try
            {
                return await _CarRepository.GetAllCarsAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("logging from car service, the exception:" + ex.Message);

                throw new Exception("Error in GetAllCarsAsync_Service function:" + ex.Message);

            }

        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            try
            {
                return await _CarRepository.GetCarByIdAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from car service, the exception:" + ex.Message);

                throw new Exception("Error in GetCarByIdAsync_Service function:" + ex.Message);

            }

        }

        public async Task UpdateCarById(Car car, int id)
        {

            try
            {
                await _CarRepository.UpdateCarById(car, id);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from car service, the exception:" + ex.Message);

                throw new Exception("Error in UpdateCarById_Service function:" + ex.Message);

            }

        }
        public async Task<List<Car>> GetFilterCars(int companyid, string modelName, int fromYear, int untilYear, int fromPrice, int untilPrice, int codeRegion)
        {
            try
            {
                return await _CarRepository.GetFilterCars(companyid, modelName, fromYear, untilYear, fromPrice, untilPrice, codeRegion);

            }
            catch (Exception ex)
            {
                logger.LogError("logging from car service, the exception:" + ex.Message);

                throw new Exception("Error in GetFilterCars_Service function:" + ex.Message);

            }
        }
        //public async Task AddBeforeSearchLogging(string searchParameters)
        //{
        //    try
        //    {
        //        await _CarRepository.AddBeforeSearchLogging(searchParameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in AddBeforeSearchLogging_Service function:" + ex.Message);
        //    }

        //}
        public async Task AddBeforeSearchLogging(string parameters)
        {
            try
            {
                await _CarRepository.AddBeforeSearchLogging(parameters);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from car service, the exception:" + ex.Message);

                throw new Exception("Error in IfExiteSearchParameters_Service function:" + ex.Message);
            }
        }

        public async Task AddSearchLogging(string searchParameters)
        {
            try
            {
                await _CarRepository.AddSearchLogging(searchParameters);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from car service, the exception:" + ex.Message);
                throw new Exception("Error in AddSearchLogging_Service function:" + ex.Message);
            }
        }
    }
}
