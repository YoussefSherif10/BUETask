using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOs
{
    public abstract record StudentForManipulationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; init; } = string.Empty;

        [Range(1, 60, ErrorMessage = "Age must be between 1 and 60")]
        public byte Age { get; init; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "Email can't be longer than 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; init; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [MaxLength(15, ErrorMessage = "Phone can't be longer than 15 characters")]
        public string Phone { get; init; } = string.Empty;
    }
}
