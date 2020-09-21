using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RapiSolver.Commons;
using RapiSolver.Dto;
using RapiSolver.Entity;
using RapiSolver.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services.Impl
{
    public class CustomerServiceImpl : CustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Create(CustomerCreateDTO model)
        {
            var entry = new Customer
            {
                CustomerId = model.CustomerId,
                UserId = model.UserId
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Customer
            {
                CustomerId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<CustomerDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CustomerDTO>>(
                await _context.Customers
                .OrderByDescending(x => x.CustomerId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<CustomerDTO> GetById(int id)
        {
            return _mapper.Map<CustomerDTO>(
                await _context.Customers.Include(x=>x.User).SingleAsync(x => x.CustomerId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Customers.Where(x => x.CustomerId == id).FirstOrDefault() == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
