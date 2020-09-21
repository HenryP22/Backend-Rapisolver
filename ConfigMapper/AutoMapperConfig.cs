using AutoMapper;
using RapiSolver.Commons;
using RapiSolver.Dto;
using RapiSolver.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreditCard, CreditCardDTO>();

            CreateMap<DataCollection<CreditCard>, DataCollection<CreditCardDTO>>();

            CreateMap<Customer, CustomerDTO>();

            CreateMap<DataCollection<Customer>, DataCollection<CustomerDTO>>();

            CreateMap<Location, LocationDTO>();

            CreateMap<DataCollection<Location>, DataCollection<LocationDTO>>();

            CreateMap<Payment, PaymentDTO>();

            CreateMap<DataCollection<Payment>, DataCollection<PaymentDTO>>();

            CreateMap<Reservation, ReservationDTO>();

            CreateMap<DataCollection<Reservation>, DataCollection<ReservationDTO>>();

            CreateMap<Service, ServiceDTO>();

            CreateMap<DataCollection<Service>, DataCollection<ServiceDTO>>();

            CreateMap<ServiceCategory, ServiceCategoryDTO>();

            CreateMap<DataCollection<ServiceCategory>, DataCollection<ServiceCategoryDTO>>();

            CreateMap<Supplier, SupplierDTO>();

            CreateMap<DataCollection<Supplier>, DataCollection<SupplierDTO>>();

            CreateMap<User, UserDTO>();

            CreateMap<DataCollection<User>, DataCollection<UserDTO>>();
        }
    }
}
