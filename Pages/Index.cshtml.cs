using Microsoft.AspNetCore.Mvc.RazorPages;
using MultiSchemaDB_Project.Data;
using MultiSchemaDB_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiSchemaDB_Project.Pages;

public class IndexModel : PageModel
{
    private readonly CustomerDbContext _context;

    public IndexModel(CustomerDbContext context)
    {
        _context = context;
    }

    public List<object> Customers { get; set; } = new();
    public string SelectedSchema { get; set; } = string.Empty;
    public string SearchQuery { get; set; } = string.Empty;

    public async Task OnGetAsync(string schema, string searchQuery)
    {
        SelectedSchema = schema;
        SearchQuery = searchQuery;

        Customers = await GetCustomersBySchema(schema, searchQuery);
    }

    private async Task<List<object>> GetCustomersBySchema(string schema, string searchQuery)
    {
        switch (schema)
        {
            case "Schema1":
                var schema1Query = _context.Schema1Customer.AsQueryable();
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    schema1Query = schema1Query.Where(c =>
                        EF.Functions.Like(c.FirstName, $"%{searchQuery}%") ||
                        EF.Functions.Like(c.LastName, $"%{searchQuery}%") ||
                        EF.Functions.Like(c.Email, $"%{searchQuery}%"));
                }
                return await schema1Query.Cast<object>().ToListAsync();

            case "Schema2":
                var schema2Query = _context.Schema2Customer.AsQueryable();
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    schema2Query = schema2Query.Where(c =>
                        EF.Functions.Like(c.FullName, $"%{searchQuery}%") ||
                        EF.Functions.Like(c.Email, $"%{searchQuery}%") ||
                        EF.Functions.Like(c.Phone, $"%{searchQuery}%"));
                }
                return await schema2Query.Cast<object>().ToListAsync();

            case "Schema3":
                var schema3Query = _context.Schema3Customer.AsQueryable();
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    schema3Query = schema3Query.Where(c =>
                        EF.Functions.Like(c.CompanyName, $"%{searchQuery}%") ||
                        EF.Functions.Like(c.ContactPerson, $"%{searchQuery}%") ||
                        EF.Functions.Like(c.Email, $"%{searchQuery}%") ||
                        EF.Functions.Like(c.Address, $"%{searchQuery}%"));
                }
                return await schema3Query.Cast<object>().ToListAsync();

            default:
                return new List<object>();
        }
    }

    public string GetCustomerId(object customer)
    {
        switch (SelectedSchema)
        {
            case "Schema1":
                return (customer as Schema1Customer)?.CustomerID.ToString();
            case "Schema2":
                return (customer as Schema2Customer)?.CustomerID.ToString();
            case "Schema3":
                return (customer as Schema3Customer)?.CustomerID.ToString();
            default:
                return string.Empty;
        }
    }
}
