using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]

        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]

        public string? Grade { get; set; }



    }
}
