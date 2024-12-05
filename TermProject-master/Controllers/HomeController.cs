using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TermProject.Models;
using Microsoft.EntityFrameworkCore;


namespace TermProject.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext context { get; set; }

        public HomeController(ProductContext ctx) => context = ctx;

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
