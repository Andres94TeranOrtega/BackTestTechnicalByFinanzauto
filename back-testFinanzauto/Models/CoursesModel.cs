using System.ComponentModel.DataAnnotations;

namespace back_testFinanzauto.Models
{
    public class CoursesModel
    {
        [Key]
        public int IdCourse { get; set; }
        public string NamePrograms { get; set; }
        public string TimeIntensity { get; set; }
        public int Credits { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
