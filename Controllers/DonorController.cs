using Microsoft.AspNetCore.Mvc;

namespace DisasterResponseHub.Controllers
{
    public class DonorController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewDonors()
        {
            return View();
        }
    }
}
