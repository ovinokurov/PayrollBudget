using System.ComponentModel.DataAnnotations;

namespace PayrollBudget.API.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(20)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(20)]
        public string NedId { get; set; } = string.Empty;
        
        public DateTime StartDater { get; set; }
        
        public DateTime EndDater { get; set; }

    }
}
