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
    public class ServiceController : ControllerBase
    {
        private readonly ServiceService _ServiceService;

        public ServiceController(ServiceService serviceService)
        {
            _ServiceService = serviceService;
        }

        private readonly ApplicationDbContext _context;

        public ServiceController( 
            ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<ServiceDTO>>> GetAll(int page, int take)
        {
            return await _ServiceService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetById(int id)
        {
            if (_ServiceService.Existencia(id) == true)
            {
                return await _ServiceService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ServiceCreateDTO Service)
        {
            var result = await _ServiceService.Create(Service);
            return CreatedAtAction(
                "GetById",
                new { id = result.ServiceId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ServiceUpdateDTO model)
        {
            if (_ServiceService.Existencia(id) == true)
            {
                await _ServiceService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _ServiceService.Remove(id);
            return NoContent();


        }

    }
}
