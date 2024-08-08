using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.DAL
{
    public class StudentDAL
    {
        private readonly StudentPortalContext _context;

        public StudentDAL(StudentPortalContext context) 
        {
            _context = context;
        }

        public List<Student> GetStudents() 
        {
            return _context.Students.Include(s => s.Department).ToList();
        }

        public Student GetStudent(int StudentID) 
        {
            return _context.Students.Include(m => m.Department).FirstOrDefault(d => d.StudentID == StudentID);
        }

        public void AddStudent(Student student) 
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }


        public void UpdateStudent(Student student) 
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int StudentID) 
        {
            var student = _context.Students.Find(StudentID);
            if (student != null) 
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
