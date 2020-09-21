using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class ServiceConfig
    {
        public ServiceConfig(EntityTypeBuilder<Service> entityBuilder)
        {
            entityBuilder.Property(x => x.Name)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Description)
                .IsRequired().HasMaxLength(150);
            entityBuilder.HasData(
                new Service
                {
                    ServiceId = 1,
                    Name = "Arreglo de tubería",
                    Description = "Arreglo de todo tipo de tubería",
                    Price = 50
                });
        }
    }
}
