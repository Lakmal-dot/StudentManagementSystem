using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public int id { get; set; }

        public string fstname { get; set; }

        public string lstname { get; set; }

        public int connumber { get; set; }

        public string email { get; set; }
    }
}
