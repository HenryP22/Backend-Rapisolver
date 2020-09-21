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
    public class PaymentServiceImpl : PaymentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PaymentServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentDTO> Create(PaymentCreateDTO model)
        {
            var entry = new Payment
            {
                PaymentId = model.PaymentId,
                CreditCardId = model.CreditCardId,
                Description = model.Description,
                CvcCreditCard = model.CvcCreditCard
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaymentDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new Payment
            {
                PaymentId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, PaymentUpdateDTO model)
        {
            var entry = _context.Payments.Single(x => x.PaymentId == id);

            entry.PaymentId = model.PaymentId;
            entry.CreditCardId = model.CreditCardId;
            entry.Description = model.Description;
            entry.CvcCreditCard = model.CvcCreditCard;

            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<PaymentDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<PaymentDTO>>(
                await _context.Payments
                .OrderByDescending(x => x.PaymentId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<PaymentDTO> GetById(int id)
        {
            return _mapper.Map<PaymentDTO>(
                await _context.Payments.SingleAsync(x => x.PaymentId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Payments.Where(x => x.PaymentId == id).FirstOrDefault() == null)
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
