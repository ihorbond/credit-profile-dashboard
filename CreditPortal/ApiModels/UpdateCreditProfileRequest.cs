using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditPortal.Models
{
    public class UpdateCreditProfileRequest
    {
        [Range(0.00, double.MaxValue, ErrorMessage = "{0} must be within {1} - {2} range")]
        public double WithdrawalAmount { get; set; }
    }
}
