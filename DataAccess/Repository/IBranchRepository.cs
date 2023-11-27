﻿using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAllBranchAsync();
        Task<Branch> GetBranchByIdAsync(int id);
        Task AddBranch(Branch branch);
        Task UpdateBranchById(Branch branch, int id);
        Task Delete(int id);
    }
}
