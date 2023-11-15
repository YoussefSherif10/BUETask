using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Name))]
    [Index(nameof(Age))]
    public class Student
    {
        public int StudentId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public byte Age { get; set; }

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public string Phone { get; set; } = string.Empty;
    }
}
