using DisasterResponseHub.Data;
using DisasterResponseHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DisasterResponseHub.Controllers
{
    public class DonorController : Controller
    {
        [TempData]
        public string Message { get; set; }
        public IRepositoryWrapper _repositoryWrapper { get; }

        public DonorController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Donor donor)
        {
            if (donor != null)
            {
                _repositoryWrapper._RepositoryDonor.Create(donor);
                ViewData["Message"] = $"Donor with Id: {donor.DonorID} was successfully added";
                return RedirectToAction("ViewDonors", "Donor");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ViewDonors()
        {
            var allDonors = _repositoryWrapper._RepositoryDonor.FindAll();
            return View(allDonors);
        }
    }
}
