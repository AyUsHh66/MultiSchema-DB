using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiSchemaDB_Project.Data;
using MultiSchemaDB_Project.Models;
using System.Threading.Tasks;

namespace MultiSchemaDB_Project.Pages;

public class EditModel : PageModel
{
    private readonly CustomerDbContext _context;

    public EditModel(CustomerDbContext context)
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
        if (string.IsNullOrEmpty(Schema) || Id == 0) return RedirectToPage("/Index");

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
                if (customer1 != null)
                {
                    customer1.FirstName = Request.Form["FirstName"];
                    customer1.LastName = Request.Form["LastName"];
                    customer1.Email = Request.Form["Email"];
                }
                break;

            case "Schema2":
                var customer2 = await _context.Schema2Customer.FindAsync(Id);
                if (customer2 != null)
                {
                    customer2.FullName = Request.Form["FullName"];
                    customer2.Email = Request.Form["Email"];
                    customer2.Phone = Request.Form["Phone"];
                }
                break;

            case "Schema3":
                var customer3 = await _context.Schema3Customer.FindAsync(Id);
                if (customer3 != null)
                {
                    customer3.CompanyName = Request.Form["CompanyName"];
                    customer3.ContactPerson = Request.Form["ContactPerson"];
                    customer3.Email = Request.Form["Email"];
                    customer3.Address = Request.Form["Address"];
                }
                break;
        }

        await _context.SaveChangesAsync();
        return RedirectToPage("/Index", new { schema = Schema });
    }
}
