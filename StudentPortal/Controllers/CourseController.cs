using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
