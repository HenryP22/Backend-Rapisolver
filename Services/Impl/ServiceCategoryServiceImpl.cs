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
    public class ServiceCategoryServiceImpl : ServiceCategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServiceCategoryServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceCategoryDTO> Create(ServiceCategoryCreateDTO model)
        {
            var entry = new ServiceCategory
            {
                ServiceCategoryId = model.ServiceCategoryId,
                Name = model.Name
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<ServiceCategoryDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new ServiceCategory
            {
                ServiceCategoryId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, ServiceCategoryUpdateDTO model)
        {
            var entry = _context.ServiceCategories.Single(x => x.ServiceCategoryId == id);

            entry.ServiceCategoryId = model.ServiceCategoryId;
            entry.Name = model.Name;

            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<ServiceCategoryDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ServiceCategoryDTO>>(
                await _context.ServiceCategories
                .OrderByDescending(x => x.ServiceCategoryId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<ServiceCategoryDTO> GetById(int id)
        {
            return _mapper.Map<ServiceCategoryDTO>(
                await _context.ServiceCategories.SingleAsync(x => x.ServiceCategoryId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.ServiceCategories.Where(x => x.ServiceCategoryId == id).FirstOrDefault() == null)
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
