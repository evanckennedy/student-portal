namespace StudentPortal.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
