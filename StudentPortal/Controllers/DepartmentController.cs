using Microsoft.AspNetCore.Mvc;
using StudentPortal.BLL;
using StudentPortal.Models;
using System.Net.Http.Headers;

namespace StudentPortal.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _departmentService;
        private readonly CourseService _courseService;

        public DepartmentController(DepartmentService departmentService, CourseService courseService) 
        {
            _departmentService = departmentService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetDepartments();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department
                {
                    DepartmentName = departmentViewModel.DepartmentName,
                    DepartmentHead = departmentViewModel.DepartmentHead
                };
                _departmentService.AddDepartment(department);
                return RedirectToAction("Index");
            }
            return View(departmentViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id) 
        {
            var department = _departmentService.GetDepartment(id);
            if (department == null) 
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (ModelState.IsValid)
            {
                Department existingDepartment = _departmentService.GetDepartment(department.DepartmentID);
                if (existingDepartment == null) 
                {
                    return NotFound();
                }

                existingDepartment.DepartmentName = department.DepartmentName;
                existingDepartment.DepartmentHead = department.DepartmentHead;

                _departmentService.UpdateDepartment(existingDepartment);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}
