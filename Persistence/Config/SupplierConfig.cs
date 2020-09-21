using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class SupplierConfig
    {
        public SupplierConfig(EntityTypeBuilder<Supplier> entityBuilder)
        {

            entityBuilder.HasData(
                new Supplier
                {
                    SupplierId = 1,
                    UserId = 1,
                    ServiceId = 1,
                    Qualification = 5
                });
        }
    }
}
