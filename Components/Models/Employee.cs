using System.ComponentModel.DataAnnotations;


namespace OOP_final.Components.Models
{
    public abstract class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Position { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Email { get; set; } = string.Empty;

    }
}

