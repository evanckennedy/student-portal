using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentPortal.BLL;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class CourseController : Controller
    {
        // private fields
        private readonly CourseService _courseService;
        private readonly DepartmentService _departmentService;

        // Constructor
        public CourseController (CourseService courseService, DepartmentService departmentService)
        {
            _courseService = courseService;
            _departmentService = departmentService;
        }
        
        // Actions
        public IActionResult Index()
        {
            var courses = _courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Create()
        {
            // Set ViewBag.Departments to the list of departments retrieved from the DepartmentService
            ViewBag.Departments = _departmentService.GetDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult Create (Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.AddCourse(course);
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _departmentService.GetDepartments();
            return View(course);
        }

        public IActionResult Edit (int id)
        {
            var course = _courseService.GetCourse(id);
            ViewBag.Departments = _departmentService.GetDepartments();
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(int id, Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.UpdateCourse(course);
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _departmentService.GetDepartments();
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = _courseService.GetCourse(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}
