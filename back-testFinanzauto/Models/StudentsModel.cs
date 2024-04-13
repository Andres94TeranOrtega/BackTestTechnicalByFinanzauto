using System.ComponentModel.DataAnnotations;

namespace back_testFinanzauto.Models
{
    public class StudentsModel
    {
        [Key]
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string LocationStudent { get; set; }
        public string Semester { get; set; }
        public string program { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}
