using System.ComponentModel.DataAnnotations;

namespace back_testFinanzauto.Models
{
    public class TeachersModel
    {
        [Key]
        public int IdTeacher { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string LocationTeacher { get; set; }
        public string ClassPrograms { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
