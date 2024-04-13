using back_testFinanzauto.Contexts;
using back_testFinanzauto.Models;

namespace back_testFinanzauto.Services
{
    public class CoursesService
    {
        private readonly Context _context;

        public CoursesService(Context context)
        {
            _context = context;
        }

        public void CreateCourses(CoursesModel courses)
        {
            _context.Courses.Add(courses);
            _context.SaveChanges();
        }

        public List<CoursesModel> GetAllCoursesById()
        {
            return _context.Courses.ToList();
        }

        public CoursesModel GetCoursesById(int id)
        {
            return _context.Courses.FirstOrDefault(s => s.IdCourse == id);
        }

        public void UpdateCourse(CoursesModel courses)
        {
            _context.Courses.Update(courses);
            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var courses = _context.Courses.FirstOrDefault(s => s.IdCourse == id);
            if (courses != null)
            {
                _context.Courses.Remove(courses);
                _context.SaveChanges();
            }
        }
    }
}
