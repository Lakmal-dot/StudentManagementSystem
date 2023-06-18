using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class ClassRoom
    {
        [Key]
        public int id { get; set; }

        public string clsname { get; set; }
    }
}
