using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : Controller
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonasController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet("{cc}", Name = "GetPersona")]
        public async Task<ActionResult<Persona>> GetPersona(int cc)
        {
            var persona = await _personaRepository.GetPersonaAsync(cc);
            if (persona is null)
            {
                return NotFound();
            }
            return persona;
        }

        [HttpGet(Name = "GetPersonas")]
        public IEnumerable<Persona> GetPersonas()
        {
            return _personaRepository.GetPersonas();
        }

        [HttpPost(Name = "CreatePersona")]
        public async Task<ActionResult<Persona>> CreatePersona(Persona persona)
        {
            await _personaRepository.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersona), new { cc = persona.Cc }, persona);
        }

        [HttpPut(Name = "UpdatePersona")]
        public async Task<ActionResult<Persona>> UpdatePersona(Persona persona)
        {
            await _personaRepository.UpdatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersona), new { cc = persona.Cc }, persona);
        }

        [HttpDelete(Name = "DeletePersona")]
        public async Task<IActionResult> DeletePersona(int cc)
        {
            await _personaRepository.DeletePersonaAsync(cc);
            return Ok();
        }

    }
}
