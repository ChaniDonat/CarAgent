using Microsoft.AspNetCore.Mvc;
using BuisnessLogic.Service;
using DataAccess.DBModels;
using AutoMapper;

namespace CarAgent.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
         ICompanyService  CompanyService;
        IMapper _Mapper;
        public CompanyController(ICompanyService CompanyService, IMapper mapper)
        {
            this.CompanyService = CompanyService;
            _Mapper = mapper;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<List<CompanyDto>> GetAllCompanyAsync()
        {
            List<Company> companies = await CompanyService.GetAllCompanyAsync();
            return _Mapper.Map<List<CompanyDto>>(companies);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<CompanyDto> GetCompanyByIdAsync(int id)
        {
            Company company= await CompanyService.GetCompanyByIdAsync(id);
            return _Mapper.Map<CompanyDto>(company);
        }

        // POST api/<CompanyController>
        [HttpPost]
        public async Task AddCompany(CompanyDto companyDto)
        {
            Company company = _Mapper.Map<Company>(companyDto);
            await CompanyService.AddCompany(company);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task UpdateCompanyById(CompanyDto companyDto, int id)
        {
            Company company = _Mapper.Map<Company>(companyDto);
            await CompanyService.UpdateCompanyById(company, id);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task  Delete(int id)
        {
            await CompanyService.Delete( id);
        }
    }
}
