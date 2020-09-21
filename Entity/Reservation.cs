using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Entity
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Date { get; set; }
        public double Discount { get; set; }
        [Range(0, 999.99)]
        public double Price { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
