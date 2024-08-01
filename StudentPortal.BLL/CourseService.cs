using StudentPortal.DAL;
using StudentPortal.Models;

namespace StudentPortal.BLL
{
    public class CourseService
    {
        private readonly CourseDAL _courseDAL;

        public CourseService(CourseDAL courseDAL)
        {
            _courseDAL = courseDAL;
        }

        public List<Course> GetCourses()
        {
            return _courseDAL.GetCourses();
        }

        public Course GetCourse(int id)
        {
            return _courseDAL.GetCourse(id);
        }

        public void AddCourse(Course course)
        {
            _courseDAL.AddCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseDAL.UpdateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _courseDAL.DeleteCourse(id);
        }
    }
}
