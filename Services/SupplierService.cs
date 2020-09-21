using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface SupplierService
    {
        Task<DataCollection<SupplierDTO>> GetAll(int page, int take);
        Task<SupplierDTO> GetById(int id);
        Task<SupplierDTO> Create(SupplierCreateDTO model);
        Task Update(int id, SupplierUpdateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
