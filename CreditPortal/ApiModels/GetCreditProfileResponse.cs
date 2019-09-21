using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditPortal.ApiModels
{
    public class GetCreditProfileResponse
    {
        public int Id { get; set; }
        public double LineOfCredit { get; set; }
        public double Balance { get; set; }
    }
}
