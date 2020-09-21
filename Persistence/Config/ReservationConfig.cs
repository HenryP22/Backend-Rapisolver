using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Persistence.Config
{
    public class ReservationConfig
    {
        public ReservationConfig(EntityTypeBuilder<Reservation> entityBuiler)
        {
            entityBuiler.Property(x => x.Date)
                .IsRequired().HasMaxLength(15);


            entityBuiler.HasData(
                new Reservation
                {
                    ReservationId = 1,
                    Date = "12/04/2021",
                    Discount = 12.5,
                    Price = 153,
                    LocationId = 1,
                    PaymentId = 1,
                    SupplierId = 1,
                    CustomerId = 1
                });
         }
    }
}
