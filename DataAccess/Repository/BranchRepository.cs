using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BranchRepository : IBranchRepository
    {
        DBAgentContext _DBAgentContext;
        public BranchRepository(DBAgentContext DBAgentContext)
        {
            _DBAgentContext = DBAgentContext;
        }
        public async Task AddBranch(Branch branch)
        {
            try
            {
                 _DBAgentContext.Branches.Add(branch);
              await  _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in AddBranch_Repository function:" + ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                _DBAgentContext.Remove(_DBAgentContext.Branches.Find(id));
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error in DeleteBranch_Repository function:" + ex.Message);

            }
           
        }

        public async Task<List<Branch>> GetAllBranchAsync()
        {
            try
            {
                return await _DBAgentContext.Branches.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error in GetAllBranchAsync_Repository function:" + ex.Message);

            }

        }

        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            try
            {
                return await _DBAgentContext.Branches.SingleOrDefaultAsync(c => c.BranchId == id);

            }
            catch (Exception ex)
            {

                throw new Exception("Error in GetBranchByIdAsync_Repository function:" + ex.Message);

            }


        }

        public async Task UpdateBranchById(Branch branch, int id)
        {
            try
            {
                _DBAgentContext.Branches.Update(branch);
                await _DBAgentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error in UpdateBranchById_Repository function:" + ex.Message);

            }


        }
        //public async Task AddBranch(Branch branch)
        //{
        //    try
        //    {
        //        _DBAgentContext.Branches.Add(branch);
        //        _DBAgentContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in Add Branches: " + ex.Message);
        //    }
        //}

        //public async Task Delete(int id)
        //{
        //    _DBAgentContext.Remove(_DBAgentContext.Branches.Find(id));
        //    await _DBAgentContext.SaveChangesAsync();
        //}

        //public async Task<List<Branch>> GetAllBranchAsync()
        //{
        //    return await _DBAgentContext.Branches.ToListAsync();
        //}

        //public async Task<Branch> GetBranchByIdAsync(int id)
        //{
        //    return await _DBAgentContext.Branches.SingleOrDefaultAsync(c => c.BranchId == id);

        //}

        //public async Task UpdateBranchById(Branch branch, int id)
        //{
        //    _DBAgentContext.Branches.Update(branch);
        //    await _DBAgentContext.SaveChangesAsync();
        //}
    }
}
