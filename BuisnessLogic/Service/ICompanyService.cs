using DataAccess.DBModels;

namespace BuisnessLogic.Service
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByIdAsync(int id);
        Task<List<Company>> GetAllCompanyAsync();
         Task AddCompany(Company company);
         Task UpdateCompanyById(Company company, int id);
         Task Delete(int id);
    }
}