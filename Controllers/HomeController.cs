using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MultiSchemaDB_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public IActionResult Index()
        {
            // List of available schemas (this can be dynamic if needed)
            var schemas = new List<string> { "Schema1", "Schema2", "Schema3" };

            // Pass the schemas list to the view
            return View(schemas);
        }
    }
}
