using Microsoft.AspNetCore.Mvc;
using Movars.Core.Models.ViewModels;

namespace Movars.Core.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index(string id)
        {
            var payment = new PaymentModel
            {
                merchant_code = _configuration.GetValue<string>("QuickTeller:MerchantCode")
            };
            return View();
        }
    }
}
