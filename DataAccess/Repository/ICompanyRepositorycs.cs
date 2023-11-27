using DataAccess.DBModels;

namespace DataAccess.Repository
{
    public interface ICompanyRepositorycs
    {
        Task<Company> GetCompanyByIdAsync(int id);
        Task<List<Company>> GetAllCompanyAsync();
        public Task AddCompany(Company company);
        public Task UpdateCompanyById(Company company, int id);
        public  Task Delete(int id);
    }
}