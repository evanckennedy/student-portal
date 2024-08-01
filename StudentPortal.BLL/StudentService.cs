using StudentPortal.DAL;
using StudentPortal.Models;

namespace StudentPortal.BLL
{
    public class StudentService
    {
        private readonly StudentDAL _studentDAL;

        public StudentService(StudentDAL studentDAL)
        {
            _studentDAL = studentDAL;
        }

        public List<Student> GetStudents()
        {
            return _studentDAL.GetStudents();
        }

        public Student GetStudent(int id)
        {
            return _studentDAL.GetStudent(id);
        }

        public void AddStudent(Student student)
        {
            _studentDAL.AddStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentDAL.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {

            _studentDAL.DeleteStudent(id);
        }



    }
}
