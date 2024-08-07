namespace StudentPortal.Models
{
    public class CourseViewModel
    {
        public int CourseID { get; set; } = 0;
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
