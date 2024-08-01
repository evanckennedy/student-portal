using StudentPortal.DAL;
using StudentPortal.Models;

namespace StudentPortal.BLL
{
    public class DepartmentService
    {
        private readonly DepartmentDAL _departmentDAL;

        public DepartmentService(DepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }

        public List<Department> GetDepartments()
        {
            return _departmentDAL.GetDepartments();
        }

        public Department GetDepartment(int id)
        {
            return _departmentDAL.GetDepartment(id);
        }

        public void AddDepartment(Department department)
        {
            _departmentDAL.AddDepartment(department);
        }

        public void UpdateDepartment(Department department)
        {
            _departmentDAL.UpdateDepartment(department);
        }

        public void DeleteDepartment(int id)
        {
            _departmentDAL.DeleteDepartment(id);
        }

    }
}
