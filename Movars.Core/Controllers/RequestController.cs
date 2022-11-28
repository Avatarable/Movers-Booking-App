using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movars.Core.Models;
using Movars.Core.Models.Enums;
using Movars.Core.Models.ViewModels;
using Movars.Core.Services.Interfaces;

namespace Movars.Core.Controllers
{
    [Authorize(Roles = "Admin, Owner")]
    public class RequestController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRequestService _requestService;
        public RequestController(UserManager<ApplicationUser> userManager, IRequestService requestService)
        {
            _userManager = userManager;
            _requestService = requestService;
        }
        // GET: RequestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RequestController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: RequestController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: RequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewRequestViewModel data)
        {
            if (ModelState.IsValid)
            {
                var type = RequestType.Home;
                switch (data.RbRoom)
                {
                    case "home":
                        type = RequestType.Home;
                        break;
                    case "office":
                        type = RequestType.Office;
                        break;
                    case "labour":
                        type = RequestType.Labour;
                        break;
                    case "other":
                        type = RequestType.Others;
                        break;
                    default:
                        type = RequestType.Home;
                        break;
                }

                var roomCount = 1;

                if (data.RbRoom == "room2") roomCount = 2;
                if (data.RbRoom == "room3") roomCount = 3;
                if (data.RbRoom == "room4") roomCount = 4;
                if (data.RbRoom == "roomS") roomCount = 0;


                var request = new Request
                {
                    RoomsCount = roomCount,
                    Floor = data.PickupFloor,
                    PickupDate = data.PickupDate,
                    TotalAmount = default,
                    Owner = await _userManager.GetUserAsync(HttpContext.User),
                    RequestStatus = RequestStatus.Pending,
                    RequestType = type,
                    PickupAddress = new Address { City = data.PickupCity, Country = "Nigeria", State = data.PickupState, Description = data.PickupAddress },
                    DeliveryAddress = new Address { City = data.DropoffCity, Country = "Nigeria", State = data.DropoffState, Description = data.DropoffAddress },
                };
                try
                {
                    await _requestService.CreateRequest(request);
                    return RedirectToAction("Index", "Dashboard");
                }
                catch
                {
                    return View("NewRequest");
                }
            }
            return View("NewRequest", data);
        }

        // GET: RequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestController/Edit/5
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

        // GET: RequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
