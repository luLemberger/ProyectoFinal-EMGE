using Microsoft.AspNetCore.Mvc;
using LicenciasAPI.Services;
using LicenciasAPI.Dtos;
using LicenciasAPI.Response;

namespace LicenciasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenciasController : ControllerBase
    {
        private readonly ILicenciaService _service;

        public LicenciasController(ILicenciaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resp = await _service.GetAllAsync();
            return StatusCode(resp.Codigo, resp);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resp = await _service.GetByIdAsync(id);
            return StatusCode(resp.Codigo, resp);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LicenciaCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var firstError = ModelState.Values.SelectMany(v => v.Errors)
                    .FirstOrDefault()?.ErrorMessage ?? "Datos inválidos.";
                return BadRequest(ApiResponse<object>.BadRequest(firstError));
            }

            var resp = await _service.CreateAsync(dto);
            return StatusCode(resp.Codigo, resp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LicenciaUpdateDto dto)
        {
            var resp = await _service.UpdateAsync(id, dto);
            return StatusCode(resp.Codigo, resp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resp = await _service.DeleteAsync(id);
            return StatusCode(resp.Codigo, resp);
        }
    }
}
