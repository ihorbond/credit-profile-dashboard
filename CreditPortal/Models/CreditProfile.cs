using System;
using System.Collections.Generic;

namespace CreditPortal.Models
{
    public partial class CreditProfile
    {
        public int Id { get; set; }
        public decimal LineOfCredit { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
