using Microsoft.AspNetCore.Mvc;

namespace casestudyhospital.Controllers
{
    public class Doctor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
