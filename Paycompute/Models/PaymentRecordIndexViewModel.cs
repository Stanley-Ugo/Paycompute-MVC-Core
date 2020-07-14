using Paycompute.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paycompute.Models
{
    public class PaymentRecordIndexViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }

        [Display(Name = "Month")]
        public string PayMonth { get; set; }

        [Display(Name = "Total Earnings")]
        public int TaxYearId { get; set; }

        [Display(Name = "Tatal Deductions")]
        public string Year { get; set; }
        public decimal TotalEarnings { get; set; }

        [Display(Name = "Total Deductions")]
        public decimal TotalDeduction { get; set; }

        [Display(Name = "Net")]
        public decimal NetPayment { get; set; }
    }
}
