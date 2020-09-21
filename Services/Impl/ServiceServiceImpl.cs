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
    public class ServiceServiceImpl: ServiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServiceServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceDTO> Create(ServiceCreateDTO model)
        {
            var entry = new Service
            {
                ServiceId = model.ServiceId,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<ServiceDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Service
            {
                ServiceId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, ServiceUpdateDTO model)
        {
            var entry = _context.Services.Single(x => x.ServiceId == id);

            entry.ServiceId = model.ServiceId;
            entry.Name = model.Name;
            entry.Description = model.Description;
            entry.Price = model.Price;

            await _context.SaveChangesAsync();
        }
        
        public async Task<DataCollection<ServiceDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ServiceDTO>>(
                await _context.Services
                .OrderByDescending(x => x.ServiceId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<ServiceDTO> GetById(int id)
        {
            return _mapper.Map<ServiceDTO>(
                await _context.Services.SingleAsync(x => x.ServiceId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Services.Where(x => x.ServiceId == id).FirstOrDefault() == null)
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
