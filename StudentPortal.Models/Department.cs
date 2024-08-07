using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
