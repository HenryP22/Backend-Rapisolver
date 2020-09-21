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
    public class CreditCardServiceImpl : CreditCardService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreditCardServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreditCardDTO> Create(CreditCardCreateDTO model)
        {
            var entry = new CreditCard
            {
                CreditCardId = model.CreditCardId,
                CardNumber = model.CardNumber,
                ExpirationDate = model.ExpirationDate,
                NameCreditCard = model.NameCreditCard
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<CreditCardDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new CreditCard
            {
                CreditCardId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, CreditCardUpdateDTO model)
        {
            var entry = _context.CreditCards.Single(x => x.CreditCardId == id);

            entry.CreditCardId = model.CreditCardId;
            entry.CardNumber = model.CardNumber;
            entry.ExpirationDate = model.ExpirationDate;
            entry.NameCreditCard = model.NameCreditCard;

            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<CreditCardDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CreditCardDTO>>(
                await _context.CreditCards
                .OrderByDescending(x => x.CreditCardId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<CreditCardDTO> GetById(int id)
        {
            return _mapper.Map<CreditCardDTO>(
                await _context.CreditCards.SingleAsync(x => x.CreditCardId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.CreditCards.Where(x => x.CreditCardId == id).FirstOrDefault() == null)
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
