using System.ComponentModel.DataAnnotations;

namespace MultiSchemaDB_Project.Models
{
    public class Schema2Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FullName { get; set; } // Nullable
        public string? Email { get; set; } // Nullable
        public string? Phone { get; set; } // Nullable
    }
}
