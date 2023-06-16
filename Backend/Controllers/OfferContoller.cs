using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    public class OfferController : Controller
    {
        private readonly ILogger<OfferController> _logger;

        public OfferController(ILogger<OfferController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Resedentials()
        {
            return View();
        }

        [Route("Offer/Resedentials/Leasing")]
        public IActionResult ResLeasing()
        {
            return View();
        }

        [Route("Offer/Resedentials/Leasing/flat")]
        public IActionResult FlaLeasing()
        {
            return View();
        }

        [Route("Offer/Resedentials/Leasing/room")]
        public IActionResult RomLeasing()
        {
            return View();
        }

        [Route("Offer/Resedentials/Leasing/house")]
        public IActionResult HosLeasing()
        {
            return View();
        }

        [Route("Offer/Resedentials/Sale")]
        public IActionResult ResSale()
        {
            return View();
        }

        [Route("Offer/Resedentials/sale/flat")]
        public IActionResult FlaSale()
        {
            return View();
        }

        [Route("Offer/Resedentials/sale/room")]
        public IActionResult RomSale()
        {
            return View();
        }

        [Route("Offer/Resedentials/sale/house")]
        public IActionResult HosSale()
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