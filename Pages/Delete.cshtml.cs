using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiSchemaDB_Project.Data;

namespace MultiSchemaDB_Project.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerDbContext _context;

        public DeleteModel(CustomerDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Schema { get; set; }

        [BindProperty]
        public object Customer { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            switch (Schema)
            {
                case "Schema1":
                    Customer = await _context.Schema1Customer.FindAsync(Id);
                    break;
                case "Schema2":
                    Customer = await _context.Schema2Customer.FindAsync(Id);
                    break;
                case "Schema3":
                    Customer = await _context.Schema3Customer.FindAsync(Id);
                    break;
                default:
                    return RedirectToPage("/Index");
            }

            if (Customer == null) return RedirectToPage("/Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            switch (Schema)
            {
                case "Schema1":
                    var customer1 = await _context.Schema1Customer.FindAsync(Id);
                    if (customer1 != null) _context.Schema1Customer.Remove(customer1);
                    break;
                case "Schema2":
                    var customer2 = await _context.Schema2Customer.FindAsync(Id);
                    if (customer2 != null) _context.Schema2Customer.Remove(customer2);
                    break;
                case "Schema3":
                    var customer3 = await _context.Schema3Customer.FindAsync(Id);
                    if (customer3 != null) _context.Schema3Customer.Remove(customer3);
                    break;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("/Index", new { schema = Schema });
        }
    }
}
