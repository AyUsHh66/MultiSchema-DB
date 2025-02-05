using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MultiSchemaDB_Project.Models
{
    public class CustomerCreateViewModel
    {
        [Required]
        public string Schema { get; set; }
        
        public Dictionary<string, string> Fields { get; set; }

        public CustomerCreateViewModel()
        {
            Fields = new Dictionary<string, string>();
        }
    }
}