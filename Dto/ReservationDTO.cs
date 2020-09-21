using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Dto
{
    public class ReservationCreateDTO
    {
        public int ReservationId { get; set; }
        public string Date { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public int LocationId { get; set; }
        public int PaymentId { get; set; }
        public int SupplierId { get; set; }
        public int CustomerId { get; set; }
    }
    public class ReservationUpdateDTO
    {
        public int ReservationId { get; set; }
        public string Date { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public int LocationId { get; set; }
        public int PaymentId { get; set; }
        public int SupplierId { get; set; }
        public int CustomerId { get; set; }
    }
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        public string Date { get; set; }
        public double Discount { get; set; }
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
