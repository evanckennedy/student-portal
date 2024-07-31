using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
