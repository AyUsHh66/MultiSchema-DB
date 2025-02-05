using System.ComponentModel.DataAnnotations;

namespace MultiSchemaDB_Project.Models
{
    public class Schema3Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? CompanyName{ get; set; } // Nullable
        public string? ContactPerson { get; set; } // Nullable
        public string? Email { get; set; } // Nullable
        public string? Address { get; set; } // Nullable
    }
}
