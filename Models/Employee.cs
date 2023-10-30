﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]

        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public string City { get; set; }

    }
}
