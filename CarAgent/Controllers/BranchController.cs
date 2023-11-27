using AutoMapper;
using BuisnessLogic.Dto;
using BuisnessLogic.Service;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarAgent.Controllers
{
    namespace CarAgent.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BranchController : ControllerBase
        {
            IBranchService _BranchService;
            IMapper _mapper;
            IConfiguration config;
            public BranchController(IBranchService branchService, IMapper mapper, IConfiguration config
)
            {
                _BranchService = branchService;
                _mapper = mapper;
                this.config = config;
            }

            // GET: api/<CompanyController>
            [HttpGet]
            public async Task<List<BranchDto>> GetAllBranchAsync()
            {
               List<Branch> branchs= await _BranchService.GetAllBranchAsync();
               return _mapper.Map<List<BranchDto>>(branchs);
            }

            // GET api/<CompanyController>/5
            [HttpGet("{id}")]
            public async Task<BranchDto> GetBrancyIdAsync(int id)
            {
                Branch branch= await _BranchService.GetBranchByIdAsync(id);
                return _mapper.Map<BranchDto>(branch);
            }

            // POST api/<CompanyController>
            [HttpPost]
            public async Task AddBranch(BranchDto branchDto)
            {
                Branch branch = _mapper.Map<Branch>(branchDto);
                await _BranchService.AddBranch(branch);
            }

            // PUT api/<CompanyController>/5
            [HttpPut("{id}")]
            public async Task UpdateBranchById(BranchDto branchDto, int id)
            {
                Branch branch = _mapper.Map<Branch>(branchDto);
                await _BranchService.UpdateBranchById(branch, id);
            }

            // DELETE api/<CompanyController>/5
            [HttpDelete("{id}")]
            public async Task Delete(int id)
            {
                await _BranchService.Delete(id);
            }
            [HttpGet, Route("GetConfigurationBranch")]
            public BranchInformation GetConfigurationBranch()
            {
                BranchInformation branchInformation = config.GetSection("BranchInformation").Get<BranchInformation>();

                return branchInformation;
            }
        }
    }
}

