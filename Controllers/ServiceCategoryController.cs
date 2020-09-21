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
    public class ServiceCategoryController : ControllerBase
    {
        private readonly ServiceCategoryService _ServiceCategoryService;
        private readonly ApplicationDbContext _context;

        public ServiceCategoryController(ServiceCategoryService ServiceCategoryService, ApplicationDbContext context)
        {
            _ServiceCategoryService = ServiceCategoryService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<ServiceCategoryDTO>>> GetAll(int page, int take)
        {
            return await _ServiceCategoryService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceCategoryDTO>> GetById(int id)
        {
            if (_ServiceCategoryService.Existencia(id) == true)
            {
                return await _ServiceCategoryService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ServiceCategoryCreateDTO ServiceCategory)
        {
            var result = await _ServiceCategoryService.Create(ServiceCategory);
            return CreatedAtAction(
                "GetById",
                new { id = result.ServiceCategoryId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ServiceCategoryUpdateDTO model)
        {
            if (_ServiceCategoryService.Existencia(id) == true)
            {
                await _ServiceCategoryService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _ServiceCategoryService.Remove(id);
            return NoContent();


        }

    }
}
