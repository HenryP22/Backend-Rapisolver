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
    public class SupplierController : ControllerBase
    {
        private readonly SupplierService _SupplierService;
        private readonly ApplicationDbContext _context;

        public SupplierController(SupplierService SupplierService, ApplicationDbContext context)
        {
            _SupplierService = SupplierService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<SupplierDTO>>> GetAll(int page, int take)
        {
            return await _SupplierService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetById(int id)
        {
            if (_SupplierService.Existencia(id) == true)
            {
                return await _SupplierService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(SupplierCreateDTO Supplier)
        {
            var result = await _SupplierService.Create(Supplier);
            return CreatedAtAction(
                "GetById",
                new { id = result.SupplierId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SupplierUpdateDTO model)
        {
            if (_SupplierService.Existencia(id) == true)
            {
                await _SupplierService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _SupplierService.Remove(id);
            return NoContent();


        }

    }
}
