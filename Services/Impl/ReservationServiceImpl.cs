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
    public class ReservationServiceImpl : ReservationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservationServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationDTO> Create(ReservationCreateDTO model)
        {
            var entry = new Reservation
            {
                ReservationId = model.ReservationId,
                Date = model.Date,
                Discount = model.Discount,
                Price = model.Price,
                LocationId = model.LocationId,
                PaymentId = model.PaymentId,
                SupplierId = model.SupplierId
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReservationDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Reservation
            {
                ReservationId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, ReservationUpdateDTO model)
        {
            var entry = _context.Reservations.Single(x => x.ReservationId == id);

            entry.ReservationId = model.ReservationId;
            entry.Date = model.Date;
            entry.Discount = model.Discount;
            entry.Price = model.Price;
            entry.LocationId = model.LocationId;
            entry.PaymentId = model.PaymentId;
            entry.SupplierId = model.SupplierId;

            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<ReservationDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ReservationDTO>>(
                await _context.Reservations
                .OrderByDescending(x => x.ReservationId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<ReservationDTO> GetById(int id)
        {
            return _mapper.Map<ReservationDTO>(
                await _context.Reservations.SingleAsync(x => x.ReservationId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Reservations.Where(x => x.ReservationId == id).FirstOrDefault() == null)
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
