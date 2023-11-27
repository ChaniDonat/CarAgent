using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CompanyRepositorycs : ICompanyRepositorycs

    {
        DBAgentContext _DBAgentContext;
        public CompanyRepositorycs(DBAgentContext DBAgentContext)
        {
            _DBAgentContext = DBAgentContext;
        }
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            try
            {
                return await _DBAgentContext.Companies.SingleOrDefaultAsync(c => c.Id == id);

            }
            catch (Exception ex)
            {

                throw new Exception("Error in GetCompanyByIdAsync_Repository function:" + ex.Message);

            }
        }
        public async Task<List<Company>> GetAllCompanyAsync()
        {
            try
            {
                return await _DBAgentContext.Companies.ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("Error in GetAllCompanyAsync_Repository function:" + ex.Message);

            }
        }
        public async Task AddCompany(Company company)
        {
            try
            {
                _DBAgentContext.Companies.Add(company);
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddCompany_Repository function:" + ex.Message);

            }

        }
        public async Task UpdateCompanyById(Company company, int id)
        {
            try
            {
                _DBAgentContext.Companies.Update(company);
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in UpdateCompanyById_Repository function:" + ex.Message);
            }


        }
        public async Task Delete(int id)
        {
            try
            {
                _DBAgentContext.Remove(_DBAgentContext.Companies.Find(id));
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteCompany_Repository function:" + ex.Message);
            }
        }




    }
}
