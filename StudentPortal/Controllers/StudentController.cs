using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
