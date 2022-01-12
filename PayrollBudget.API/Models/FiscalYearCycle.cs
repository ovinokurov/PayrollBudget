using System.ComponentModel.DataAnnotations;

namespace PayrollBudget.API.Models
{
    public class FiscalYearCycle
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string FiscalYear { get; set; }
        [StringLength(20)]
        public string CycleName { get; set; }
    }
}
