using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Dto
{
    public class Car1Dto
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
