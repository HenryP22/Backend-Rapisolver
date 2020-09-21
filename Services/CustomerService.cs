using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface CustomerService
    {
        Task<DataCollection<CustomerDTO>> GetAll(int page, int take);
        Task<CustomerDTO> GetById(int id);
        Task<CustomerDTO> Create(CustomerCreateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
