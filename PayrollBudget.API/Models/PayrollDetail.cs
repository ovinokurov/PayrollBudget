using System.ComponentModel.DataAnnotations;

namespace PayrollBudget.API.Models
{
    public class PayrollDetail
    {
        public int Id { get; set; }
        //public int EmployeeId { get; set; }
        //public Employee? Employee { get; set; }
        //public int OfficeId { get; set; }
        //public Office? Office { get; set; }
        //public int SacId { get; set; }
        //public Sac? Sac { get; set; }
        [StringLength(20)]
        public string PayPlan { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Grade { get; set; }
        public int Step { get; set; }
        [StringLength(20)]
        public string CAN { get; set; } = string.Empty;
        public DateTime NextWIGI { get; set; }
        public DateTime DepartureDate { get; set; }
        [StringLength(20)]
        public string FY20Actions { get; set; } = string.Empty;
    }
}
