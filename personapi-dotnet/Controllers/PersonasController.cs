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

        [HttpGet("{id}", Name = "GetPersona")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            var persona = await _personaRepository.GetPersonaAsync(id);
            if(persona is null)
            {
                return NotFound();
            }
            return persona;
        }

        [HttpPost(Name = "CreatePersona")]
        public async Task<ActionResult<Persona>> CreatePersona(Persona persona)
        {
            await _personaRepository.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersona), new { id = persona.Cc }, persona);
        } 
    }
}
