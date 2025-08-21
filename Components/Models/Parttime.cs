using System.ComponentModel.DataAnnotations;

namespace OOP_final.Components.Models
{
    public class Parttime : Employee
    {
        [Range(1, double.MaxValue, ErrorMessage = "Hourly rate must be greater than 0")]
        public decimal HourlyRate { get; set; }

        [Range(1, 80, ErrorMessage = "Hours per week must be between 1 and 80")]
        public int HoursPerWeek { get; set; }
    }
}
