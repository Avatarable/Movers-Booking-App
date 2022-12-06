using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movars.Core.Helpers;
using Movars.Core.Models;
using Movars.Core.Models.DTOs;
using Movars.Core.Models.ViewModels;
using Movars.Core.Services.Interfaces;
using NuGet.Protocol.Core.Types;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Movars.Core.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IBidService _bidService;
        private readonly UserManager<ApplicationUser> _userManager;
        public static ConfirmDetails confirmDetails;

        public PaymentController(IConfiguration configuration, IBidService bidService, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _bidService = bidService;
            _userManager = userManager;
            confirmDetails = new ConfirmDetails();
        }
        
        public async Task<IActionResult> Index(string id)
        {
            var bid = await _bidService.GetBidById(id);

            if(bid == null) return RedirectToAction("Index", "Dashboard");

            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });		// returns to login if no logged in user
            }

            var paymentDetails = new PaymentModel
            {
                merchant_code = _configuration.GetValue<string>("QuickTeller:MerchantCode"),
                pay_item_id = _configuration.GetValue<string>("QuickTeller:PayItemId"),
                site_redirect_url = _configuration.GetValue<string>("QuickTeller:RedirectUri"),
                txn_ref = Generator.Reference(),
                pay_item_name = bid.Request.RoomsCount == 0 ? "Studio Apartment Move" : $"{ bid.Request.RoomsCount} Rooms Move",
                amount = bid.Amount,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = ""
            };

            //confirmDetails = new ConfirmDetails();
            confirmDetails.txn_ref = paymentDetails.txn_ref;
            confirmDetails.merchant_code = paymentDetails.merchant_code;
            confirmDetails.amount = paymentDetails.amount;

            return View(paymentDetails);
        }

        public async Task<IActionResult> ConfirmPayment()
        {
            var response = await ProcessHttpRequest();

            return RedirectToAction("Index", "Dashboard");
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        private async Task<ConfirmPaymentResponse> ProcessHttpRequest()
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Movars");

            return await ProcessTransactionsAsync(client);

        }
        private static async Task<ConfirmPaymentResponse> ProcessTransactionsAsync(HttpClient client)
        {
            await using Stream stream =  await client.GetStreamAsync($"https://qa.interswitchng.com/collections/api/v1/gettransaction.json?merchantcode={confirmDetails.merchant_code}&transactionreference={confirmDetails.txn_ref}&amount={confirmDetails.amount} ");
            var response =  await JsonSerializer.DeserializeAsync<ConfirmPaymentResponse>(stream);
            return response;
        }
    }
}
