using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class LocationConfig
    {
        public LocationConfig(EntityTypeBuilder<Location> entityBuilder)
        {
            entityBuilder.Property(x => x.Country)
                .IsRequired().HasMaxLength(16);
            entityBuilder.Property(x => x.City)
                .IsRequired().HasMaxLength(16);
            entityBuilder.Property(x => x.Address)
                .IsRequired().HasMaxLength(50);
            entityBuilder.HasData(
                new Location
                {
                    LocationId = 1,
                    Country = "Perú",
                    City = "Lima",
                    Address = "Avenida escardo, Los Prados de San Miguel"
                });
        }
    }
}
