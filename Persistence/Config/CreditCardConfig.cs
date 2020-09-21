using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class CreditCardConfig
    {
        public CreditCardConfig(EntityTypeBuilder<CreditCard> entityBuilder)
        {
            entityBuilder.Property(x => x.CardNumber)
                .IsRequired().HasMaxLength(16);
            entityBuilder.Property(x => x.ExpirationDate)
                .IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.NameCreditCard)
                .IsRequired().HasMaxLength(30);
            entityBuilder.HasData(
                new CreditCard
                {
                    CreditCardId = 1,
                    CardNumber = "1234567890123456",
                    ExpirationDate = "12/05/2025",
                    NameCreditCard = "Henrry Bustos"
                });
        }
    }
}
