using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiSchemaDB_Project.Data;
using MultiSchemaDB_Project.Models;

namespace MultiSchemaDB_Project.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public CreateModel(CustomerDbContext context)
        {
            _context = context;
        }

        // Define the Schema property as public
        [BindProperty(SupportsGet = true)]
        public string Schema { get; set; }

        public void OnGet(string schema)
        {
            Schema = schema;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            switch (Schema)
            {
                case "Schema1":
                    var customer1 = new Schema1Customer
                    {
                        FirstName = Request.Form["FirstName"],
                        LastName = Request.Form["LastName"],
                        Email = Request.Form["Email"]
                    };
                    _context.Schema1Customer.Add(customer1);
                    break;

                case "Schema2":
                    var customer2 = new Schema2Customer
                    {
                        FullName = Request.Form["FullName"],
                        Email = Request.Form["Email"],
                        Phone = Request.Form["Phone"]
                    };
                    _context.Schema2Customer.Add(customer2);
                    break;

                case "Schema3":
                    var customer3 = new Schema3Customer
                    {
                        CompanyName = Request.Form["CompanyName"],
                        ContactPerson = Request.Form["ContactPerson"],
                        Email = Request.Form["Email"],
                        Address = Request.Form["Address"]
                    };
                    _context.Schema3Customer.Add(customer3);
                    break;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Index", new { schema = Schema });
        }
    }
}
