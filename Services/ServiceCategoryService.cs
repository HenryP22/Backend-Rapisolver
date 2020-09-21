using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface ServiceCategoryService
    {
        Task<DataCollection<ServiceCategoryDTO>> GetAll(int page, int take);
        Task<ServiceCategoryDTO> GetById(int id);
        Task<ServiceCategoryDTO> Create(ServiceCategoryCreateDTO model);
        Task Update(int id, ServiceCategoryUpdateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
