using System.ComponentModel.DataAnnotations;

namespace PayrollBudget.API.Models
{
    public class Subtotal
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public Office? Office { get; set; }
        public decimal SalaryWithoutBenefits { get; set; }  
        public decimal CashAwards { get; set; } 
        public decimal SalaryBenefitsCosts { get; set; }
        public decimal CashAwardBenefits { get; set; }
        public decimal TotalSalaryWithBenefits{ get; set; }
        public decimal BenefitPercentage{ get; set; }
        public decimal FTEUsage{ get; set; }
        public decimal FTEAssign{ get; set; }
    }

}
