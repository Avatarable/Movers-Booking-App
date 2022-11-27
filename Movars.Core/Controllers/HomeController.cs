using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Movars.Core.Helpers;
using Movars.Core.Models;
using System.Diagnostics;

namespace Movars.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public AuthMessageSenderOptions Options { get; }

        public HomeController(ILogger<HomeController> logger,
            IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            _logger = logger;
            Options = optionsAccessor.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            TestSender.Execute("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").Wait();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}