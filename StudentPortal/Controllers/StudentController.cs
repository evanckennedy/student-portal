using Microsoft.AspNetCore.Mvc;
using StudentPortal.BLL;
using StudentPortal.Models;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        private readonly DepartmentService _departmentService;

        public StudentController(StudentService studentService, DepartmentService departmentService) 
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        // index page for the admin showing a list of all students
        // alongwith the department name they are enrolled in and
        // options to delete and update the student
        public IActionResult Index() 
        {
            var students = _studentService.GetStudents();
            return View(students);
        }

        // a registration page for the students to register themselves
        // with their name, email and the department in which they want
        // to be enrolled from a dropdown list of all departments
        [HttpGet]
        public IActionResult RegisterStudent() 
        {
            var departments = _departmentService.GetDepartments();
            if (departments == null || !departments.Any())
            {
                throw new Exception("No departments found.");
            }
            var studentDepartmentModel = new StudentViewModel
            {
                Departments = departments
            };
            return View(studentDepartmentModel);
        }

        // the post methods redirects the student to their profile page
        [HttpPost]
        public IActionResult RegisterStudent(StudentViewModel studentViewModel) 
        {
            if (ModelState.IsValid) 
            {
                var student = new Student 
                {
                    StudentName = studentViewModel.StudentName,
                    StudentEmail = studentViewModel.StudentEmail,
                    DepartmentID = studentViewModel.DepartmentID,
                    Department = _departmentService.GetDepartments().FirstOrDefault(d => d.DepartmentID == studentViewModel.DepartmentID)
                };
                _studentService.AddStudent(student);
                return RedirectToAction("StudentProfile", new { id = student.StudentID });
                //return RedirectToAction("Index");
            }
            studentViewModel.Departments = _departmentService.GetDepartments();
            return View(studentViewModel);
        }

        // it shows all the information to the student about himself along
        // with their department, transcripts (transcript is based on the
        // credits student recieved in a particular course), and a button to go
        // to the page to see all the courses the student is enrolled in; i.e.,
        // 'StudentProfile()' has relation with both department and course entity
        [HttpGet]
        public IActionResult StudentProfile(int id) {
            var student = _studentService.GetStudent(id);
            if (student == null) 
            {
                return NotFound();
            }
            return View(student);
        }

        // it displays a list of all the courses the student is enrolled in with
        // an option to drop a course; by default the student is enrolled in all
        // the courses offered in a department
        [HttpGet]
        public IActionResult EnrolledCourses(int studentID) 
        {
            var student = _studentService.GetStudent(studentID);
            if (student == null) 
            {
                return NotFound();
            }
            var courses = student.Courses.ToList();
            return View(courses);
        }

        // it is for the admin to make change in student name,
        // student email and their department
        [HttpGet]
        public IActionResult UpdateStudent(int id) 
        {
            var student = _studentService.GetStudent(id);
            if (student == null) 
            {
                return NotFound();
            }
            var StudentDepartmentmodel = new StudentViewModel 
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                StudentEmail = student.StudentEmail,
                DepartmentID = student.DepartmentID,
                Departments = _departmentService.GetDepartments()
            };
            return View(StudentDepartmentmodel);
        }

        // the post redirects the admin to the index page
        [HttpPost]
        public IActionResult UpdateStudent(StudentViewModel studentViewModel) 
        {
            if (ModelState.IsValid) 
            {
                var student = new Student 
                {
                    StudentID = studentViewModel.StudentID,
                    StudentName = studentViewModel.StudentName,
                    StudentEmail = studentViewModel.StudentEmail,
                    DepartmentID = studentViewModel.DepartmentID

                };
                _studentService.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            studentViewModel.Departments = _departmentService.GetDepartments();
            return View(studentViewModel);
        }

        // it is for the admin to delete a student
        [HttpGet]
        public IActionResult DeleteStudent(int id) 
        {
            var student = _studentService.GetStudent(id);
            if (student == null) 
            {
                return NotFound();
            }
            return View(student);
        }

        // the post redirects the admin to the index page
        [HttpPost]
        public IActionResult DeleteConfirmed(int id) 
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
