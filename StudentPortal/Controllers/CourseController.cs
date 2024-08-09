using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentPortal.BLL;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    [Authorize(Roles = "Admin")]
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
            List<Course> courses = _courseService.GetCourses();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.GetDepartments();
            if (departments == null || !departments.Any())
            {
                throw new Exception("No departments found.");
            }
            var courseViewModel = new CourseViewModel
            {
                Departments = departments
            };
            return View(courseViewModel);
        }

        [HttpPost]
        public IActionResult Create (CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Hey, use the departmentID, to actually find the department object, and assign it to the new course's department property .Find()
                Department department = _departmentService.GetDepartments().FirstOrDefault(d => d.DepartmentID == courseViewModel.DepartmentID);
                Course course = new Course
                {
                    CourseName = courseViewModel.CourseName,
                    Duration = courseViewModel.Duration,
                    Credits = courseViewModel.Credits,
                    DepartmentID = courseViewModel.DepartmentID,
                    Department = department
                };
                department.Courses.Add(course);
                _courseService.AddCourse(course);
                return RedirectToAction("Index");
            }
            courseViewModel.Departments = _departmentService.GetDepartments();
            return View(courseViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var departments = _departmentService.GetDepartments();
            var course = _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseViewModel = new CourseViewModel
            {
                CourseID = course.CourseID,
                CourseName = course.CourseName,
                Duration = course.Duration,
                Credits = course.Credits,
                DepartmentID = course.DepartmentID,
                Departments = departments
            };
            return View(courseViewModel);
        }

        [HttpPost]
        public IActionResult Update(CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                Course existingCourse = _courseService.GetCourse(courseViewModel.CourseID);
                if (existingCourse == null)
                {
                    return NotFound();
                }
                existingCourse.CourseName = courseViewModel.CourseName;
                existingCourse.Duration = courseViewModel.Duration;
                existingCourse.Credits = courseViewModel.Credits;
                existingCourse.DepartmentID = courseViewModel.DepartmentID;

                _courseService.UpdateCourse(existingCourse);
                return RedirectToAction("Index");
            }
            return View(courseViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            // Create a CourseViewModel and populate it with the course details
            var courseViewModel = new CourseViewModel
            {
                CourseID = course.CourseID,
                CourseName = course.CourseName,
                Duration = course.Duration,
                Credits = course.Credits,
                DepartmentID = course.DepartmentID,
            };
            return View(courseViewModel);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int courseID)
        {
            _courseService.DeleteCourse(courseID);
            return RedirectToAction("Index");
        }
    }
}
