using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class AllocateClass
    {
        [Key]
        public int id { get; set; }

        public string teacher { get; set; }
        public string classroom { get; set; }
    }
}
