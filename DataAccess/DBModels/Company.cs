using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
