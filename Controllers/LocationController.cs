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
    public class LocationController : ControllerBase
    {
        private readonly LocationService _LocationService;
        private readonly ApplicationDbContext _context;

        public LocationController(LocationService LocationService, ApplicationDbContext context)
        {
            _LocationService = LocationService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<LocationDTO>>> GetAll(int page, int take)
        {
            return await _LocationService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDTO>> GetById(int id)
        {
            if (_LocationService.Existencia(id) == true)
            {
                return await _LocationService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(LocationCreateDTO Location)
        {
            var result = await _LocationService.Create(Location);
            return CreatedAtAction(
                "GetById",
                new { id = result.LocationId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, LocationUpdateDTO model)
        {
            if (_LocationService.Existencia(id) == true)
            {
                await _LocationService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _LocationService.Remove(id);
            return NoContent();


        }

    }
}
