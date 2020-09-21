using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Dto
{
    public class ServiceCategoryCreateDTO
    {
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
    }
    public class ServiceCategoryUpdateDTO
    {
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
    }
    public class ServiceCategoryDTO
    {
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
    }
}
