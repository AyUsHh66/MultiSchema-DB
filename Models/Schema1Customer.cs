using System.ComponentModel.DataAnnotations;


namespace MultiSchemaDB_Project.Models
{
    public class Schema1Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FirstName { get; set; } // Nullable
        public string? LastName { get; set; } // Nullable
        public string? Email { get; set; } // Nullable
    }
}
