using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class AllocateSubject
    {
        [Key]
        public int id { get; set; }

        public string teacher { get; set; }
        public string subject { get; set; }

    }
}
