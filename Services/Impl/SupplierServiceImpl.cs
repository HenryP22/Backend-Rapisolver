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
    public class SupplierServiceImpl : SupplierService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SupplierServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> Create(SupplierCreateDTO model)
        {
            var entry = new Supplier
            {
                SupplierId = model.SupplierId,
                UserId = model.UserId,
                Qualification = model.Qualification
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<SupplierDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Supplier
            {
                SupplierId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, SupplierUpdateDTO model)
        {
            var entry = _context.Suppliers.Single(x => x.SupplierId == id);

            entry.SupplierId = model.SupplierId;
            entry.Qualification = model.Qualification;

            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<SupplierDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<SupplierDTO>>(
                await _context.Suppliers
                .OrderByDescending(x => x.SupplierId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<SupplierDTO> GetById(int id)
        {
            return _mapper.Map<SupplierDTO>(
                await _context.Suppliers.Include(x=>x.User).SingleAsync(x => x.SupplierId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault() == null)
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
