using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BarnacleBudget.Controllers
{
    public class HealthCheckController : Controller
    {
        public IActionResult Ping()
        {
            return Content("healthy");
        }
    }
}
