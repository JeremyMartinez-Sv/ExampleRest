using ExampleRest.Models;
using ExampleRest.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExampleRest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPhotoService PhotoService;

        public HomeController(ILogger<HomeController> logger, IPhotoService _photoService)
        {
            _logger = logger;
            PhotoService = _photoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPhotos(DataTableJS request)
        {
            var data = await PhotoService.GetPhotosAsync(request);

            return Json(new
            {
                draw = request.Draw,
                recordsTotal = data.CountTotal,
                recordsFiltered = data.CountFiltered,
                request_ = request,
                data = data.Result
            }); ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
