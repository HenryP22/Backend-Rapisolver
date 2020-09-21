using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface PaymentService
    {
        Task<DataCollection<PaymentDTO>> GetAll(int page, int take);
        Task<PaymentDTO> GetById(int id);
        Task<PaymentDTO> Create(PaymentCreateDTO model);
        Task Update(int id, PaymentUpdateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
