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
    public class UserController : ControllerBase
    {
        private readonly UserService _UserService;
        private readonly ApplicationDbContext _context;

        public UserController(UserService UserService, ApplicationDbContext context)
        {
            _UserService = UserService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<DataCollection<UserDTO>>> GetAll(int page, int take)
        {
            return await _UserService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            if (_UserService.Existencia(id) == true)
            {
                return await _UserService.GetById(id);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Create(UserCreateDTO User)
        {
            var result = await _UserService.Create(User);
            return CreatedAtAction(
                "GetById",
                new { id = result.UserId },
                result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UserUpdateDTO model)
        {
            if (_UserService.Existencia(id) == true)
            {
                await _UserService.Update(id, model);
                return NoContent();
            }
            else
                return NotFound();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {

            await _UserService.Remove(id);
            return NoContent();


        }

    }
}
