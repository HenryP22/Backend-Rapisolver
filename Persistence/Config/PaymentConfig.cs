using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class PaymentConfig
    {
        public PaymentConfig(EntityTypeBuilder<Payment> entityBuilder)
        {
            entityBuilder.Property(x => x.Description)
                .IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.CvcCreditCard)
                .IsRequired().HasMaxLength(3);
            entityBuilder.HasData(
                new Payment
                {
                    PaymentId = 1,
                    CreditCardId = 1,
                    Description = " Pago de servicio de gasfitería",
                    CvcCreditCard = "123"
                });
        }
    }
}
