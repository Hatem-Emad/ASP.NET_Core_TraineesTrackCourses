using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Core_Day09.Models;

namespace WebApplication_Core_Day09.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
		{
			_logger = logger;
            this.env = env;
        }

		public IActionResult Index()
		{
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