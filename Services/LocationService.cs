using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface LocationService
    {
        Task<DataCollection<LocationDTO>> GetAll(int page, int take);
        Task<LocationDTO> GetById(int id);
        Task<LocationDTO> Create(LocationCreateDTO model);
        Task Update(int id, LocationUpdateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
