namespace StudentPortal.Models
{
    public class CourseViewModel
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        public int Credits { get; set; }
        public Department Department { get; set; }
    }
}
