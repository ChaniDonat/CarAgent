using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public string BranchAddress { get; set; } = null!;
        public string BranchPhone { get; set; } = null!;
        public int RegionId { get; set; }

        public virtual Region Region { get; set; } = null!;
    }
}
