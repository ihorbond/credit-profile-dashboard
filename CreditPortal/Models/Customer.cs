using System;
using System.Collections.Generic;

namespace CreditPortal.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CreditProfile = new HashSet<CreditProfile>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<CreditProfile> CreditProfile { get; set; }
    }
}
