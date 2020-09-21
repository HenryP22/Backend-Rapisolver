using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Dto
{
    public class SupplierCreateDTO
    {
        public int SupplierId { get; set; }
        public int Qualification { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
    }
    public class SupplierUpdateDTO
    {
        public int SupplierId { get; set; }
        public int Qualification { get; set; }
        public int ServiceId { get; set; }
    }
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Qualification { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
