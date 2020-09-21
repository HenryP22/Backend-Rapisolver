using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Entity
{
    public class CreditCard
    {   
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string NameCreditCard { get; set; }
    }
}
