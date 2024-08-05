using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentPortal.BLL;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        private readonly DepartmentService _departmentService;

        public StudentController(StudentService studentService, DepartmentService departmentService) {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        // index page for the admin showing a list of all students
        // alongwith the department name they are enrolled in and
        // options to delete and update the student
        public IActionResult Index() 
        {
            
        }

        // a registration page for the students to register themselves
        // with their name, email and the department in which they want
        // to be enrolled from a dropdown list of all departments
        [HttpGet]
        public IActionResult RegisterStudent() 
        {
            
        }

        // the post methods redirects the student to their profile page
        [HttpPost]
        public IActionResult RegisterStudent(StudentViewModel student) 
        {
            if (ModelState.IsValid) 
            {
                
            }
            return View(student);
        }

        // it shows all the information to the student about himself along
        // with their department, transcripts (transcript is based on the
        // credits student recieved in a particular course), and a button to go
        // to the page to see all the courses the student is enrolled in; i.e.,
        // 'StudentProfile()' has relation with both department and course entity
        [HttpGet]
        public IActionResult StudentProfile() {

        }

        [HttpPost]
        public IActionResult StudentProfile() {

        }

        // it displays a list of all the courses the student is enrolled in with
        // an option to drop a course; by default the student is enrolled in all
        // the courses offered in a department
        [HttpGet]
        public IActionResult EnrolledCourses() {

        }

        [HttpPost]
        public IActionResult EnrolledCourses() {

        }

        // it is for the admin to make change in student name,
        // student email and their department
        [HttpGet]
        public IActionResult UpdateStudent() {

        }

        // the post redirects the admin to the index page
        [HttpPost]
        public IActionResult UpdateStudent() {

        }

        // it is for the admin to delete a student
        [HttpGet]
        public IActionResult DeleteStudent() {

        }

        // the post redirects the admin to the index page
        [HttpPost]
        public IActionResult DeleteStudent() {

        }
    }
}
