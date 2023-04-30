using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesionsController : Controller
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionsController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        [HttpGet("{id}", Name = "GetProfesion")]
        public async Task<ActionResult<Profesion>> GetProfesion(int id)
        {
            var profesion = await _profesionRepository.GetProfesionAsync(id);
            if (profesion is null)
            {
                return NotFound();
            }
            return profesion;
        }

        [HttpGet(Name = "GetProfesiones")]
        public IEnumerable<Profesion> GetProfesiones()
        {
            return _profesionRepository.GetProfesiones();
        }

        [HttpPost(Name = "CreateProfesion")]
        public async Task<ActionResult<Profesion>> CreateProfesion(Profesion profesion)
        {
            await _profesionRepository.CreateProfesionAsync(profesion);
            return CreatedAtAction(nameof(GetProfesion), new { id = profesion.Id }, profesion);
        }

        [HttpPut(Name = "UpdateProfesion")]
        public async Task<ActionResult<Profesion>> UpdateProfesion(Profesion profesion)
        {
            await _profesionRepository.UpdateProfesionAsync(profesion);
            return CreatedAtAction(nameof(GetProfesion), new { id = profesion.Id }, profesion);
        }

        [HttpDelete(Name = "DeleteProfesion")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            await _profesionRepository.DeleteProfesionAsync(id);
            return Ok();
        }
    }
}
