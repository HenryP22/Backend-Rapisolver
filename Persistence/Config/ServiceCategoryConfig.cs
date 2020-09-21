using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class ServiceCategoryConfig
    {
        public ServiceCategoryConfig(EntityTypeBuilder<ServiceCategory> entityBuilder)
        {
            entityBuilder.Property(x => x.Name)
                .IsRequired().HasMaxLength(20);
            entityBuilder.HasData(
                new ServiceCategory
                {
                    ServiceCategoryId = 1,
                    Name = "Gasfitero"
                });
        }
    }
}
