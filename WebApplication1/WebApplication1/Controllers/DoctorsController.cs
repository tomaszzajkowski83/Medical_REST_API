using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        IDbService _service;
        public DoctorsController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var response = await _service.GetDoctor(id);
            if (response == null)
            {
                return NotFound($"Nie ma w bazie Lekarza o id: {id}");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorRequestDto value)
        {
            var response = await _service.AddDoctor(value);
            return Created($"Doctors/{response.IdDoctor}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctorInformation(int id, [FromBody] DoctorRequestDto value)
        {
            if (!await _service.UpdateDoctor(id, value))
            {
                return NotFound($"Nie ma w bazie Lekarza o id: {id}");
            }
            return Ok($"Lekarz o ID {id} został zaktualizowany w bazie");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(!await _service.DeleteDoctor(id))
            {
                return NotFound($"Nie ma w bazie Lekarza o id: {id}");
            }
            return Ok($"Lekarz o ID {id} został usunięty z bazy");
        }
    }
}
