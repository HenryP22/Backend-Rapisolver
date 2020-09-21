using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface ServiceService
    {
        Task<DataCollection<ServiceDTO>> GetAll(int page, int take);
        Task<ServiceDTO> GetById(int id);
        Task<ServiceDTO> Create(ServiceCreateDTO model);
        Task Update(int id, ServiceUpdateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
