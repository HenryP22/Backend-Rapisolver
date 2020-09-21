using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _CreditCardService;
        private readonly ApplicationDbContext _context;

        public CreditCardController(CreditCardService CreditCardService, ApplicationDbContext context)
        {
            _CreditCardService = CreditCardService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<CreditCardDTO>>> GetAll(int page, int take)
        {
            return await _CreditCardService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCardDTO>> GetById(int id)
        {
            if (_CreditCardService.Existencia(id) == true)
            {
                return await _CreditCardService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreditCardCreateDTO CreditCard)
        {
            var result = await _CreditCardService.Create(CreditCard);
            return CreatedAtAction(
                "GetById",
                new { id = result.CreditCardId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreditCardUpdateDTO model)
        {
            if (_CreditCardService.Existencia(id) == true)
            {
                await _CreditCardService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _CreditCardService.Remove(id);
            return NoContent();


        }

    }
}
