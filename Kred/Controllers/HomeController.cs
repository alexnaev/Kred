using Kred.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Kred.Helpers;

namespace Kred.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult App()
        {
            Loan loan = new();
            loan.Payment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.Rate = 10m;
            loan.Amount = 150000m;
            loan.Term = 60;

            return View(loan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(Loan loan)
        {
            var loanHelper = new LoanHelper();

            Loan newLoan = loanHelper.GetPayments(loan);
            return View(newLoan);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}