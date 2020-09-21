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
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _PaymentService;
        private readonly ApplicationDbContext _context;

        public PaymentController(PaymentService PaymentService, ApplicationDbContext context)
        {
            _PaymentService = PaymentService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<PaymentDTO>>> GetAll(int page, int take)
        {
            return await _PaymentService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> GetById(int id)
        {
            if (_PaymentService.Existencia(id) == true)
            {
                return await _PaymentService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(PaymentCreateDTO Payment)
        {
            var result = await _PaymentService.Create(Payment);
            return CreatedAtAction(
                "GetById",
                new { id = result.PaymentId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PaymentUpdateDTO model)
        {
            if (_PaymentService.Existencia(id) == true)
            {
                await _PaymentService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _PaymentService.Remove(id);
            return NoContent();


        }

    }
}
