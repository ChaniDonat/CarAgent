using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DBModels;
using DataAccess.Repository;
using Microsoft.Extensions.Logging;

namespace BuisnessLogic.Service
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepositorycs CompanyRepository;
        ILogger logger;
        public CompanyService(ICompanyRepositorycs CompanyRepository, ILogger<CompanyService> logger)
        {
            this.CompanyRepository = CompanyRepository;
            this.logger = logger;
        }
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            try
            {
                return await CompanyRepository.GetCompanyByIdAsync(id);

            }
            catch (Exception ex)
            {
                logger.LogError("logging from Company service, the exception:" + ex.Message);

                throw new Exception("Error in GetCompanyByIdAsync_Service function:" + ex.Message);
            }

        }
        public async Task<List<Company>> GetAllCompanyAsync()
        {
            try
            {
                return await CompanyRepository.GetAllCompanyAsync();

            }
            catch (Exception ex)
            {
                logger.LogError("logging from Company service, the exception:" + ex.Message);

                throw new Exception("Error in GetAllCompanyAsync_Service function:" + ex.Message);

            }

        }
        public async Task AddCompany(Company company)
        {
            try
            {
                await CompanyRepository.AddCompany(company);

            }
            catch (Exception ex)
            {
                logger.LogError("logging from Company service, the exception:" + ex.Message);

                throw new Exception("Error in AddCompany_Service function:" + ex.Message);

            }

        }
        public async Task UpdateCompanyById(Company company, int id)
        {
            try
            {
                await CompanyRepository.UpdateCompanyById(company, id);

            }
            catch (Exception ex)
            {
                logger.LogError("logging from Company service, the exception:" + ex.Message);

                throw new Exception("Error in UpdateCompanyById_Service function:" + ex.Message);

            }

        }
        public async Task Delete(int id)

        {
            try
            {
                await CompanyRepository.Delete(id);

            }
            catch (Exception ex)
            {
                logger.LogError("logging from Company service, the exception:" + ex.Message);

                throw new Exception("Error in DeleteCompany_Service function:" + ex.Message);

            }

        }
    }
}
