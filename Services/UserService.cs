using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface UserService
    {
        Task<DataCollection<UserDTO>> GetAll(int page, int take);
        Task<UserDTO> GetById(int id);
        Task<UserDTO> Create(UserCreateDTO model);
        Task Update(int id, UserUpdateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
