namespace StudentPortal.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }
        public List<Course> Courses { get; set; }
    }
}
