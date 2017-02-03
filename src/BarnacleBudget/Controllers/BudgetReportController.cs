using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BarnacleBudget.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BarnacleBudget.Controllers
{
    public class BudgetReportController : Controller
    {
        [HttpPost]
        public IActionResult Generate(IFormFile transactions)
        {
            if (transactions == null)
            {
                return RedirectToAction("Index", "Home");
            }

            TransactionReport report = TransactionReport.FromCsvStream(transactions.OpenReadStream());;
            return View(new BudgetReport(report.ComputePortfolio()));
        }
    }
}
