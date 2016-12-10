using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            TransactionReport report = TransactionReport.FromCsvStream(transactions.OpenReadStream());
            IEnumerable<StockLot> lots = report.ComputePortfolio();
            return View(lots);
        }
    }
}
