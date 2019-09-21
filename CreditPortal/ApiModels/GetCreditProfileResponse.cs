using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditPortal.ApiModels
{
    public class GetCreditProfileResponse
    {
        public int Id { get; set; }
        public decimal LineOfCredit { get; set; }
        public decimal Balance { get; set; }
        public decimal Available
        {
            get => LineOfCredit - Balance;
        }
    }
}
