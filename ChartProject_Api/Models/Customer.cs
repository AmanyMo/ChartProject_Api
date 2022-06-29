using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChartProject_Api.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]

        public string Service { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string ContractDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        

        public string ContractExpiryDate { get; set; }

    }
}
