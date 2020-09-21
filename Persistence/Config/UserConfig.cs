using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class UserConfig
    {
        public UserConfig(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.Property(x => x.Name)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.LastName)
                .IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Email)
                .IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Phone)
                .IsRequired().HasMaxLength(9);
            entityBuilder.Property(x => x.Name)
                .IsRequired().HasMaxLength(10);
            entityBuilder.HasData(
                new User
                {
                    UserId = 1,
                    Name = "Henrry",
                    LastName = "Bustos",
                    Email = "henrry@gmail.com",
                    Phone = "940215570",
                    Gender = "Macho"

                });
        }
    }
}
