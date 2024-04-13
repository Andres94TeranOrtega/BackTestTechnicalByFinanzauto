using System.ComponentModel.DataAnnotations;

namespace back_testFinanzauto.Models
{
    public class QualificationModel
    {
        [Key]
        public int IdGrade { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
        public int IdCourse { get; set; }
        public decimal FirstPeriodQualification { get; set; }
        public decimal SecondPeriodQualification { get; set; }
        public decimal ThirdPeriodQualification { get; set; }
        public decimal Average { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
