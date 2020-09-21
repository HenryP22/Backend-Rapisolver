using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Entity
{
    public class Supplier
    {
        public int SupplierId { get;  set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Qualification { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
