using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movars.Core.Models;
using Movars.Core.Models.Enums;
using Movars.Core.Services.Interfaces;

namespace Movars.Core.Controllers
{
    [Authorize]
    public class OwnerController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBidService _bidService;

        public OwnerController(IRequestService requestService, UserManager<ApplicationUser> userManager, IBidService bidService)
        {
            _requestService = requestService;
            _userManager = userManager;
            _bidService = bidService;
        }

        // GET: OwnerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OwnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OwnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OwnerController/Delete/5
        [Authorize(Roles = "Owner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SelectBid(string requestId, string moverId, string bidId, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var request = await _requestService.GetRequestById(requestId);
                var mover = await _userManager.FindByIdAsync(moverId);
                var bid = await _bidService.GetBidById(bidId);
                var alreadyselectedBid = (await _bidService.GetAllBidsByStatus(BidStatus.Accepted)).FirstOrDefault();
                if((request != null) && (mover != null) && (bid != null))
                {
                    request.Mover = mover;
                    bid.Status = BidStatus.Accepted;
                    try
                    {
                        if(alreadyselectedBid != null)
                        {
                            alreadyselectedBid.Status = BidStatus.Rejected;
                            await _bidService.UpdateBid(alreadyselectedBid);
                        }
                        await _requestService.UpdateRequest(request);
                        await _bidService.UpdateBid(bid);
                    }
                    catch
                    {
                        ViewBag.Message = "Cannot select bid";
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
