using boolflix.Data;
using boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace boolflix.Controllers
{
    public class HomeController : Controller
    {
        private readonly BoolflixContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(BoolflixContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            Random rand = new Random();
            int totalVideoContents = _context.VideoContents.Count();
            Movie rndMovie = (Movie)_context.VideoContents.Skip(rand.Next(totalVideoContents)).First();

            ViewData["JumboCover"] = rndMovie;

            return View();
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