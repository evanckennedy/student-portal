using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; } = 0;
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Display(Name = "Student Email")]
        public string StudentEmail { get; set; }
        public int DepartmentID { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
