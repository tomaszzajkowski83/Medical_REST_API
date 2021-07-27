using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        IDbService _service;
        public PrescriptionsController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var response = await _service.GetPrescription(id);
            if (response == null)
            {
                return NotFound($"Nie ma w bazie recepty o id: {id}");
            }
            return Ok(response);
        }
    }
}
