using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 namespace DataAccess.Repository
{
    public class CarRepository: ICarRepository
    {
        DBAgentContext _DBAgentContext;
        ILogger<Car> logger;
        public CarRepository(DBAgentContext DBAgentContext, ILogger<Car> logger)
        {
            _DBAgentContext = DBAgentContext;
            this.logger = logger;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _DBAgentContext.Cars.ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            try
            {
                return await _DBAgentContext.Cars.SingleOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error in GetCarByIdAsync_Repository function:" + ex.Message);
            }
        }
        public async Task AddCar(Car car)
        {
            try
            {
                _DBAgentContext.Cars.Add(car);
               await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Add Car: " + ex.Message);
            }


        }

       public async Task UpdateCarById(Car car, int id)
        {
            _DBAgentContext.Cars.Update(car);
            await _DBAgentContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _DBAgentContext.Remove(_DBAgentContext.Cars.Find(id));
            await _DBAgentContext.SaveChangesAsync();
        }

        public async Task<List<Car>> GetFilterCars(int companyid, string modelName, int fromYear, int untilYear, int fromPrice, int untilPrice, int codeRegion)
        {

            try
            {

                var cars = await (from c in _DBAgentContext.Cars
                                  where ((companyid == -1) || (c.CompanyId == companyid)) && ((modelName == "defaultValue") || (c.ModelName == modelName))
                                  && ((fromYear == -1) || (c.Year > fromYear)) && ((untilYear == -1) || (c.Year < untilYear)) && ((fromPrice == -1) ||
                                  (c.Price > fromPrice)) && ((untilPrice == -1) || (c.Price < untilPrice)) && ((codeRegion == -1) || (codeRegion == (from b in _DBAgentContext.Branches
                                                                                                                                                     where b.BranchId == c.BranchId
                                                                                                                                                     select b.RegionId).First()))
                                  select c).ToListAsync();
                return cars;
            }
            catch (Exception ex)
            {
                //logger.LogError(ex.Message);
                throw new Exception("Error in GetCarByFilter function:" + ex.Message);

            }

        }
        public async Task AddBeforeSearchLogging(string parameters)
        {
            try
            {
                logger.LogTrace("aszxcdvfbnm,shndfghj=================================================");
                logger.LogInformation("before search information:" + parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddSearchLogging function:" + ex.Message);
            }
        }

public async Task AddSearchLogging(string searchParameters)
        {
            try
            {

                var search = await _DBAgentContext.SearchLoggings.Where(s => s.SearchParameters == searchParameters).FirstOrDefaultAsync();

                if (search != null)
                {
                    search.Count += 1;
                    search.UpdateDate = DateTime.Now;
                    _DBAgentContext.SearchLoggings.Update(search);
                }

                else
                {
                    SearchLogging searchLogging = new SearchLogging()
                    { SearchParameters = searchParameters, Count = 1, CrationDate = DateTime.Now, UpdateDate = DateTime.Now };
                    await _DBAgentContext.SearchLoggings.AddAsync(searchLogging);
                }
                await _DBAgentContext.SaveChangesAsync();
                logger.LogInformation("after search information:" + searchParameters);
            }
            catch (Exception ex)
            {

                throw new Exception("Error in AddSearchLogging function:" + ex.Message);
            }

        }
    }
}
