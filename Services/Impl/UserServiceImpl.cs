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
    public class UserServiceImpl : UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserServiceImpl(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> Create(UserCreateDTO model)
        {
            var entry = new User
            {
                UserId = model.UserId,
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone,
                Gender = model.Gender
            };

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDTO>(entry);
        }
        public async Task Remove(int id)
        {
            _context.Remove(new User
            {
                UserId = id
            });
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, UserUpdateDTO model)
        {
            var entry = _context.Users.Single(x => x.UserId == id);

            entry.UserId = model.UserId;
            entry.Name = model.Name;
            entry.LastName = model.LastName;
            entry.Email = model.Email;
            entry.Phone = model.Phone;
            entry.Gender = model.Gender;

            await _context.SaveChangesAsync();
        }
        public async Task<DataCollection<UserDTO>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<UserDTO>>(
                await _context.Users
                .OrderByDescending(x => x.UserId)
                .AsQueryable()
                .PagedAsync(page, take));
        }
        public async Task<UserDTO> GetById(int id)
        {
            return _mapper.Map<UserDTO>(
                await _context.Users.SingleAsync(x => x.UserId == id));
        }
        public bool Existencia(int id)
        {
            if (_context.Users.Where(x => x.UserId == id).FirstOrDefault() == null)
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
