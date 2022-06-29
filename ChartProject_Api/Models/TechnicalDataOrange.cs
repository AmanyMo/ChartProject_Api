using System;
using System.Collections.Generic;

namespace ChartProject_Api.Models
{
    public partial class TechnicalDataOrange
    {
        public short Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Service { get; set; } = null!;
        public DateTime? ContractDate { get; set; }
        public DateTime? ContractExpiryDate { get; set; }
    }
}
