using StudentPortal.Models;

namespace StudentPortal.DAL
{
    public class DepartmentDAL
    {
        private readonly StudentPortalContext _context;

        public DepartmentDAL(StudentPortalContext context) 
        {
            _context = context;
        }

        public List<Department> GetDepartments() 
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartment(int DepartmentID) 
        {
            return _context.Departments.Find(DepartmentID);
        }

        public void AddDepartment(Department department) 
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }


        public void UpdateDepartment(Department department) 
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int DepartmentID) 
        {
            var department = _context.Departments.Find(DepartmentID);
            if (department != null) 
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
    }
}
