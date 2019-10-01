using System.Diagnostics;
using Challenge.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("privacidade")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
