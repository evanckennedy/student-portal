namespace StudentPortal.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public int DepartmentID { get; set; }
        public List<Department> Departments { get; set; }
    }
}
