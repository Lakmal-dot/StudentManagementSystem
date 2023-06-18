using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        public string stname { get; set; }

        public string lstname { get; set; }

        public string conperson { get; set; }

        public string connumber { get; set; }

        public string email { get; set; }

        public DateTime dob { get; set; }

        public int age { get; set; }

        public string classroom { get; set; }
    }
}
