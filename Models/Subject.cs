using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Subject
    {
        [Key]
        public int id { get; set; }

        public string subjectname { get; set; }
    }
}
