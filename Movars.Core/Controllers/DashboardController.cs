using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movars.Core.Models;
using Movars.Core.Models.Enums;
using Movars.Core.Services.Interfaces;

namespace Movars.Core.Controllers
{
	public class DashboardController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IRequestService _requestService;
		private readonly IBidService _bidService;

		public DashboardController(SignInManager<ApplicationUser> signInManager, IRequestService requestService, IBidService bidService, UserManager<ApplicationUser> userManager)
		{
			_signInManager = signInManager;
			_requestService = requestService;
			_bidService = bidService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var user = await GetCurrentUserAsync();		// gets curent user

			if(user == null)
			{
				return RedirectToPage("/Account/Login", new { area = "Identity" });		// returns to login if no logged in user
            }

			IEnumerable<Request> requests;
			IEnumerable<Bid> bids;

			var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault(); // get user role

			// use role to direct to the correct dashboard
			if(userRole == RoleTypes.Mover.ToString())
			{
				bids = await _bidService.GetAllBidByMover(user.Id);
				requests = (user.Address != null) ? await _requestService.GetAllRequestsByAddress(user.Address) : await _requestService.GetAllRequests();
				
				return View("Mover");
			}

			requests = await _requestService.GetAllRequestsByOwner(user.Id);			
			ViewData["requests"] = requests;
			ViewData["bids"] = (await _bidService.GetAllBids())
				.Where(b => requests.Contains(b.Request));

            return View();
		}

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public IActionResult NewRequest()
		{
			return View();
		}
	}
}
