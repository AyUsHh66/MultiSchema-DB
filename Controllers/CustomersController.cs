using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiSchemaDB_Project.Models;
using MultiSchemaDB_Project.Data;

public class CustomersController : Controller
{
    private readonly CustomerDbContext _context;

    public CustomersController(CustomerDbContext context)
    {
        _context = context;
    }

    // GET: Customers Index
    public IActionResult Index()
    {
        return View();
    }

    // GET: API endpoint for fetching customers
    [HttpGet("api/Customers")]
    public async Task<IActionResult> GetCustomers(
        [FromQuery] string schema,
        [FromQuery] string searchQuery = null)
    {
        Console.WriteLine($"GetCustomers endpoint hit. Schema: {schema}, SearchQuery: {searchQuery}");

        if (string.IsNullOrEmpty(schema))
        {
            Console.WriteLine("Schema not specified.");
            return BadRequest("Schema must be specified");
        }

        try
        {
            return schema switch
            {
                "Schema1" => await HandleSchema1Query(searchQuery),
                "Schema2" => await HandleSchema2Query(searchQuery),
                "Schema3" => await HandleSchema3Query(searchQuery),
                _ => BadRequest("Invalid schema")
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetCustomers: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("test-schema1")]
    public async Task<IActionResult> TestSchema1()
    {
        Console.WriteLine("TestSchema1 endpoint hit.");
        try
        {
            var customers = await _context.Schema1Customer.ToListAsync();
            Console.WriteLine($"Fetched {customers.Count} customers from Schema1.");
            return Ok(customers);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in TestSchema1: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("test-schema2")]
    public async Task<IActionResult> TestSchema2()
    {
        Console.WriteLine("TestSchema2 endpoint hit.");
        try
        {
            var customers = await _context.Schema2Customer.ToListAsync();
            Console.WriteLine($"Fetched {customers.Count} customers from Schema2.");
            return Ok(customers);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in TestSchema2: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("test-schema3")]
    public async Task<IActionResult> TestSchema3()
    {
        Console.WriteLine("TestSchema3 endpoint hit.");
        try
        {
            var customers = await _context.Schema3Customer.ToListAsync();
            Console.WriteLine($"Fetched {customers.Count} customers from Schema3.");
            return Ok(customers);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in TestSchema3: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }

    private async Task<IActionResult> HandleSchema1Query(string searchQuery)
    {
        var query = _context.Schema1Customer.AsQueryable();
        if (!string.IsNullOrEmpty(searchQuery))
        {
            query = query.Where(c =>
                c.FirstName.Contains(searchQuery) ||
                c.LastName.Contains(searchQuery) ||
                c.Email.Contains(searchQuery)
            );
        }
        return Ok(await query.ToListAsync());
    }

    private async Task<IActionResult> HandleSchema2Query(string searchQuery)
    {
        var query = _context.Schema2Customer.AsQueryable();
        if (!string.IsNullOrEmpty(searchQuery))
        {
            query = query.Where(c =>
                c.FullName.Contains(searchQuery) ||
                c.Email.Contains(searchQuery) ||
                c.Phone.Contains(searchQuery)
            );
        }
        return Ok(await query.ToListAsync());
    }

    private async Task<IActionResult> HandleSchema3Query(string searchQuery)
    {
        var query = _context.Schema3Customer.AsQueryable();
        if (!string.IsNullOrEmpty(searchQuery))
        {
            query = query.Where(c =>
                c.CompanyName.Contains(searchQuery) ||
                c.ContactPerson.Contains(searchQuery) ||
                c.Email.Contains(searchQuery) ||
                c.Address.Contains(searchQuery)
            );
        }
        return Ok(await query.ToListAsync());
    }

    // CREATE Views and Actions
    public IActionResult Create(string schema)
    {
        ViewBag.Schema = schema;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string schema, [FromForm] object customer)
    {
        if (!ModelState.IsValid)
            return View(customer);

        try
        {
            switch (schema)
            {
                case "Schema1":
                    var schema1Customer = (Schema1Customer)customer;
                    _context.Schema1Customer.Add(schema1Customer);
                    await _context.SaveChangesAsync();
                    break;
                case "Schema2":
                    var schema2Customer = (Schema2Customer)customer;
                    _context.Schema2Customer.Add(schema2Customer);
                    await _context.SaveChangesAsync();
                    break;
                case "Schema3":
                    var schema3Customer = (Schema3Customer)customer;
                    _context.Schema3Customer.Add(schema3Customer);
                    await _context.SaveChangesAsync();
                    break;
                default:
                    return BadRequest("Invalid schema");
            }
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error creating customer: " + ex.Message);
            return View(customer);
        }
    }

    // EDIT Actions
    public async Task<IActionResult> Edit(string schema, int id)
    {
        ViewBag.Schema = schema;

        return schema switch
        {
            "Schema1" => View(await _context.Schema1Customer.FindAsync(id)),
            "Schema2" => View(await _context.Schema2Customer.FindAsync(id)),
            "Schema3" => View(await _context.Schema3Customer.FindAsync(id)),
            _ => NotFound()
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string schema, int id, [FromForm] object customer)
    {
        if (!ModelState.IsValid)
            return View(customer);

        try
        {
            switch (schema)
            {
                case "Schema1":
                    var schema1Customer = (Schema1Customer)customer;
                    _context.Schema1Customer.Update(schema1Customer);
                    await _context.SaveChangesAsync();
                    break;
                case "Schema2":
                    var schema2Customer = (Schema2Customer)customer;
                    _context.Schema2Customer.Update(schema2Customer);
                    await _context.SaveChangesAsync();
                    break;
                case "Schema3":
                    var schema3Customer = (Schema3Customer)customer;
                    _context.Schema3Customer.Update(schema3Customer);
                    await _context.SaveChangesAsync();
                    break;
                default:
                    return BadRequest("Invalid schema");
            }
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error updating customer: " + ex.Message);
            return View(customer);
        }
    }

    // DELETE Actions
    [HttpDelete("api/Customers/{schema}/{id}")]
    public async Task<IActionResult> Delete(string schema, int id)
    {
        Console.WriteLine($"Delete endpoint hit. Schema: {schema}, ID: {id}");
        try
        {
            switch (schema)
            {
                case "Schema1":
                    var schema1Customer = await _context.Schema1Customer.FindAsync(id);
                    if (schema1Customer == null)
                    {
                        Console.WriteLine("Schema1 customer not found.");
                        return NotFound();
                    }
                    _context.Schema1Customer.Remove(schema1Customer);
                    break;
                case "Schema2":
                    var schema2Customer = await _context.Schema2Customer.FindAsync(id);
                    if (schema2Customer == null)
                    {
                        Console.WriteLine("Schema2 customer not found.");
                        return NotFound();
                    }
                    _context.Schema2Customer.Remove(schema2Customer);
                    break;
                case "Schema3":
                    var schema3Customer = await _context.Schema3Customer.FindAsync(id);
                    if (schema3Customer == null)
                    {
                        Console.WriteLine("Schema3 customer not found.");
                        return NotFound();
                    }
                    _context.Schema3Customer.Remove(schema3Customer);
                    break;
                default:
                    Console.WriteLine("Invalid schema specified for delete.");
                    return BadRequest("Invalid schema");
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Delete: {ex.Message}");
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
