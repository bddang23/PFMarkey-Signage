using Microsoft.AspNetCore.Mvc;
using Signage.Models;
using System.Diagnostics;

namespace Signage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FrontLobby()
        {
            FrontLobby fl = new FrontLobby();   
            return View(fl);
        }
        public IActionResult CSR()
        {
            CSR csr = new CSR();
            return View(csr);
        }
        public IActionResult Warehouse()
        {
            Warehouse wh = new Warehouse();
            return View(wh);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}