using Microsoft.AspNetCore.Mvc;
using RapiSolver.Commons;
using RapiSolver.Dto;
using RapiSolver.Persistence;
using RapiSolver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiSolver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _ReservationService;
        private readonly ApplicationDbContext _context;

        public ReservationController(ReservationService ReservationService, ApplicationDbContext context)
        {
            _ReservationService = ReservationService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<ReservationDTO>>> GetAll(int page, int take)
        {
            return await _ReservationService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetById(int id)
        {
            if (_ReservationService.Existencia(id) == true)
            {
                return await _ReservationService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ReservationCreateDTO Reservation)
        {
            var result = await _ReservationService.Create(Reservation);
            return CreatedAtAction(
                "GetById",
                new { id = result.ReservationId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ReservationUpdateDTO model)
        {
            if (_ReservationService.Existencia(id) == true)
            {
                await _ReservationService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _ReservationService.Remove(id);
            return NoContent();


        }

    }
}
