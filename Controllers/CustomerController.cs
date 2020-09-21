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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _CustomerService;
        private readonly ApplicationDbContext _context;

        public CustomerController(CustomerService CustomerService, ApplicationDbContext context)
        {
            _CustomerService = CustomerService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<CustomerDTO>>> GetAll(int page, int take)
        {
            return await _CustomerService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetById(int id)
        {
            if (_CustomerService.Existencia(id) == true)
            {
                return await _CustomerService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CustomerCreateDTO Customer)
        {
            var result = await _CustomerService.Create(Customer);
            return CreatedAtAction(
                "GetById",
                new { id = result.CustomerId },
                result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _CustomerService.Remove(id);
            return NoContent();


        }

    }
}
