using System.ComponentModel.DataAnnotations;

namespace OOP_final.Components.Models
{
    public class Fulltime : Employee
    {
        [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "Annual salary must be greater than 0")]
        public decimal AnnualSalary { get; set; }
    }
}
