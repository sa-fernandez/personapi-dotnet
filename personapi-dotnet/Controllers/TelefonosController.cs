using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefonosController : Controller
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonosController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        [HttpGet("{num}", Name = "GetTelefono")]
        public async Task<ActionResult<Telefono>> GetTelefono(string num)
        {
            var telefono = await _telefonoRepository.GetTelefonoAsync(num);
            if (telefono is null)
            {
                return NotFound();
            }
            return telefono;
        }

        [HttpGet(Name = "GetTelefonoes")]
        public IEnumerable<Telefono> GetTelefonos()
        {
            return _telefonoRepository.GetTelefonos();
        }

        [HttpPost(Name = "CreateTelefono")]
        public async Task<ActionResult<Telefono>> CreateTelefono(Telefono telefono)
        {
            await _telefonoRepository.CreateTelefonoAsync(telefono);
            return CreatedAtAction(nameof(GetTelefono), new { num = telefono.Num }, telefono);
        }

        [HttpPut(Name ="UpdateTelefono")]
        public async Task<ActionResult<Telefono>> UpdateTelefono(Telefono telefono)
        {
            await _telefonoRepository.UpdateTelefonoAsync(telefono);
            return CreatedAtAction(nameof(GetTelefono), new { num = telefono.Num }, telefono);
        }

        [HttpDelete(Name = "DeleteTelefono")]
        public async Task<IActionResult> DeleteTelefono(string num)
        {
            await _telefonoRepository.DeleteTelefonoAsync(num);
            return Ok();
        }
    }
}
