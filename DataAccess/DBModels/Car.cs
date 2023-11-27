using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Car
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string ModelName { get; set; } = null!;
        public int Passengers { get; set; }
        public string Color { get; set; } = null!;
        public int Year { get; set; }
        public double Price { get; set; }
        public int BranchId { get; set; }
    }
}
