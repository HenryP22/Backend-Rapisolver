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
    public class LocationServiceImpl : LocationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LocationServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LocationDTO> Create(LocationCreateDTO model)
        {
            var entry = new Location
            {
                LocationId = model.LocationId,
                Country = model.Country,
                City = model.City,
                Address = model.Address
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<LocationDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Location
            {
                LocationId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, LocationUpdateDTO model)
        {
            var entry = _context.Locations.Single(x => x.LocationId == id);

            entry.LocationId = model.LocationId;
            entry.Country = model.Country;
            entry.City = model.City;
            entry.Address = model.Address;

            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<LocationDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<LocationDTO>>(
                await _context.Locations
                .OrderByDescending(x => x.LocationId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<LocationDTO> GetById(int id)
        {
            return _mapper.Map<LocationDTO>(
                await _context.Locations.SingleAsync(x => x.LocationId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Locations.Where(x => x.LocationId == id).FirstOrDefault() == null)
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
