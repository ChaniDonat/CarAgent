using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class SearchLogging
    {
        public long SearchLoggingId { get; set; }
        public string SearchParameters { get; set; } = null!;
        public int Count { get; set; }
        public DateTime CrationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
