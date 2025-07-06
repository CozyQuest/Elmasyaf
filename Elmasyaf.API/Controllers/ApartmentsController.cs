using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Elmasyaf.Application.Interfaces;
using Elmasyaf.Application.DTOs;

namespace Elmasyaf.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _service;

        public ApartmentsController(IApartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApartmentCardDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Apartment data is required.");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ApartmentCardDTO dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
