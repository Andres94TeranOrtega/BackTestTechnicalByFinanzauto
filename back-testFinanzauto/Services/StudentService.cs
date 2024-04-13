using back_testFinanzauto.Contexts;
using back_testFinanzauto.Models;
using Microsoft.EntityFrameworkCore;

namespace back_testFinanzauto.Services
{
    public class StudentService
    {
        private readonly Context _context;

        public StudentService(Context context)
        {
            _context = context;
        }

        public void CreateStudent(StudentsModel student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public List<StudentsModel> GetAllStudentById()
        {
            return _context.Students.ToList();
        }

        public StudentsModel GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.IdStudent == id);
        }

        public void UpdateStudent(StudentsModel student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.IdStudent == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
