namespace StudentPortal.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
