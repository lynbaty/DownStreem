using downstreem.Dtos.MockDTO;
using downstreem.Models;
using downstreem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace downstreem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpServices<ProjectDTO> _httpService;

        public HomeController(ILogger<HomeController> logger,IHttpServices<ProjectDTO> httpService)
        {
            _logger = logger;
            _httpService = httpService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProject()
        {
            var x = await _httpService.GetbyId(1, "/projects");
            return View(x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}