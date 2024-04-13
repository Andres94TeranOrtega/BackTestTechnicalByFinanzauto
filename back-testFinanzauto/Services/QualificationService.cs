using back_testFinanzauto.Contexts;
using back_testFinanzauto.Models;

namespace back_testFinanzauto.Services
{
    public class QualificationService
    {
        private readonly Context _context;

        public QualificationService(Context context)
        {
            _context = context;
        }

        public void CreateQualification(QualificationModel qualification)
        {
            _context.Qualification.Add(qualification);
            _context.SaveChanges();
        }

        public List<QualificationModel> GetAllStudentById()
        {
            return _context.Qualification.ToList();
        }

        public QualificationModel GetStudentById(int id)
        {
            return _context.Qualification.FirstOrDefault(s => s.IdStudent == id);
        }

        public void UpdateStudent(QualificationModel qualification)
        {
            _context.Qualification.Update(qualification);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var qualification = _context.Qualification.Find(id);
            if (qualification != null)
            {
                _context.Qualification.Remove(qualification);
                _context.SaveChanges();
            }
        }
    }
}
