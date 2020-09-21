using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Entity
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Description { get; set; }
        public string CvcCreditCard { get; set; }
    }
}
