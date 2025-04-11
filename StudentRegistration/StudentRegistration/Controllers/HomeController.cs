using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace StudentRegistration.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
