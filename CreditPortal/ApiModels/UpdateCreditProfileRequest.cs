using System.ComponentModel.DataAnnotations;

namespace CreditPortal.Models
{
    public class UpdateCreditProfileRequest
    {
        [Range(0, double.MaxValue, ErrorMessage = "{0} must be within {1} - {2} range")]
        public decimal WithdrawalAmount { get; set; }
    }
}
