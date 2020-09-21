using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Dto
{
    public class PaymentCreateDTO
    {
        public int PaymentId { get; set; }
        public int CreditCardId { get; set; }
        public string Description { get; set; }
        public string CvcCreditCard { get; set; }
    }
    public class PaymentUpdateDTO
    {
        public int PaymentId { get; set; }
        public int CreditCardId { get; set; }
        public string Description { get; set; }
        public string CvcCreditCard { get; set; }
    }
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public int CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Description { get; set; }
        public string CvcCreditCard { get; set; }
    }
}
