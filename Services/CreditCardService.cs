using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface CreditCardService
    {
        Task<DataCollection<CreditCardDTO>> GetAll(int page, int take);
        Task<CreditCardDTO> GetById(int id);
        Task<CreditCardDTO> Create(CreditCardCreateDTO model);
        Task Update(int id, CreditCardUpdateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
