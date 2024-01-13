using ExampleRest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExampleRest.Controllers
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

        public IActionResult GetPhotos(DataTableJS request)
        {
            var data = new DataTableResponse<string>()
            {
                CountTotal = 20,
                CountFiltered = 5,
                Result = ["1", "2", "3"]
            };

            return Json(new
            {
                draw = request.Draw,
                recordsTotal = data.CountTotal,
                recordsFiltered = data.CountFiltered,
                request_ = request,
                data = data.Result
            }); ;
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
