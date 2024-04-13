using back_testFinanzauto.Contexts;
using back_testFinanzauto.Models;

namespace back_testFinanzauto.Services
{
    public class TeachersService
    {
        private readonly Context _context;

        public TeachersService(Context context)
        {
            _context = context;
        }

        public void CreateTeachers(TeachersModel teachers)
        {
            _context.Teachers.Add(teachers);
            _context.SaveChanges();
        }

        public List<TeachersModel> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        public TeachersModel GetTeachersById(int id) => _context.Teachers.FirstOrDefault(s => s.IdTeacher == id);

        public void UpdateTeachers(TeachersModel teachers)
        {
            _context.Teachers.Update(teachers);
            _context.SaveChanges();
        }

        public void DeleteTeachers(int id)
        {
            var teachers = _context.Teachers.FirstOrDefault(s => s.IdTeacher == id);
            if (teachers != null)
            {
                _context.Teachers.Remove(teachers);
                _context.SaveChanges();
            }
        }
    }
}
