using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Dto
{
    public class CustomerCreateDTO
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
    public class CustomerUpdateDTO
    {
       
    }
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
