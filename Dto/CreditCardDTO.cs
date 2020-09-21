using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Dto
{
    public class CreditCardCreateDTO
    {
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string NameCreditCard { get; set; }
    }
    public class CreditCardUpdateDTO
    {
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string NameCreditCard { get; set; }
    }
    public class CreditCardDTO
    {
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string NameCreditCard { get; set; }
    }
}
