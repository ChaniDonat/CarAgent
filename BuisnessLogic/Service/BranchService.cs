using AutoMapper;
using BuisnessLogic.Dto;
using DataAccess.DBModels;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Service
{
    public class BranchService : IBranchService
    {
        IConfiguration config;
        IBranchRepository _branchRepository;
        IMapper mapper;
        ILogger logger;

        public BranchService(IBranchRepository branchRepository, IMapper mapper, IConfiguration config, ILogger<BranchService> logger)
        {
            _branchRepository = branchRepository;
            this.mapper = mapper;
            this.logger = logger;
            this.config = config;
        }
        
        public async Task AddBranch(Branch branch)
        {
            try
            {
               await _branchRepository.AddBranch(branch);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from brach service, the exception:" + ex.Message);
                throw new Exception("Error in AddBranch_Service function:" + ex.Message);
            }

        }

        public async Task Delete(int id)
        {
            try
            {
                await _branchRepository.Delete(id);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from brach service, the exception:" + ex.Message);
                throw new Exception("Error in Delete_Service function:" + ex.Message);
            }

        }

        public async Task<List<Branch>> GetAllBranchAsync()
        {
            try
            {
                return await _branchRepository.GetAllBranchAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("logging from brach service, the exception:" + ex.Message);
                throw new Exception("Error in GetAllBranchAsync_Service function:" + ex.Message);

            }

        }

        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            try
            {
                return await _branchRepository.GetBranchByIdAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from brach service, the exception:" + ex.Message);
                throw new Exception("Error in GetBranchByIdAsync_Service function:" + ex.Message);

            }

        }

        public async Task UpdateBranchById(Branch branch, int id)
        {
            try
            {
                await _branchRepository.UpdateBranchById(branch, id);
            }
            catch (Exception ex)
            {
                logger.LogError("logging from brach service, the exception:" + ex.Message);
                throw new Exception("Error in UpdateBranchById_Service function:" + ex.Message);

            }

        }
        public BranchInformation GetConfigurationBranch()
        {   //final make in controller
            //BranchInformation branchInformation = new BranchInformation();
            //    config.GetSection("BranchInformation")<BranchInformation>();
            //string value = System.Configuration.ConfigurationManager.AppSettings[key];
            //BranchInformation branchInformation = config.GetSection("BranchInformation").Get<BranchInformation>();
            //logger.LogError("logging from ================== GetConfigurationBranch============ " );
            return null;
        }
    }
}
