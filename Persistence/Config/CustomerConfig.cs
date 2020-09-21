using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class CustomerConfig
    {
        public CustomerConfig(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.HasData(
                new Customer
                {
                    CustomerId = 1,
                    UserId = 1
                });
        }
    }
}
