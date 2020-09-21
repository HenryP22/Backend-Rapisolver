using RapiSolver.Commons;
using RapiSolver.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Services
{
    public interface ReservationService
    {
        Task<DataCollection<ReservationDTO>> GetAll(int page, int take);
        Task<ReservationDTO> GetById(int id);
        Task<ReservationDTO> Create(ReservationCreateDTO model);
        Task Update(int id, ReservationUpdateDTO model);
        Task Remove(int id);
        bool Existencia(int id);
    }
}
