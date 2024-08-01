using StudentPortal.Models;

namespace StudentPortal.DAL
{
    public class CourseDAL
    {
        private readonly StudentPortalContext _context;

        public CourseDAL(StudentPortalContext context) 
        {
            _context = context;
        }

        public List<Course> GetCourses() 
        {
            return _context.Courses.ToList();
        }

        public Course GetCourse(int CourseID) 
        {
            return _context.Courses.Find(CourseID);
        }

        public void AddCourse(Course course) 
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }


        public void UpdateCourse(Course course) 
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int CourseID) 
        {
            var course = _context.Courses.Find(CourseID);
            if (course != null) 
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}
