using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Region
    {
        public Region()
        {
            Branches = new HashSet<Branch>();
        }

        public int Region1 { get; set; }
        public string RegionName { get; set; } = null!;

        public virtual ICollection<Branch> Branches { get; set; }
    }
}
