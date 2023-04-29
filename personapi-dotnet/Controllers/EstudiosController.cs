using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiosController : Controller
    {
        private readonly IEstudioRepository _estudioRepository;

        public EstudiosController(IEstudioRepository estudioRepository)
        {
            _estudioRepository = estudioRepository;
        }

        [HttpGet("{id_prof}, {cc_per}", Name = "GetEstudio")]
        public async Task<ActionResult<Estudio>> GetEstudio(int id_prof, int cc_per)
        {
            var estudio = await _estudioRepository.GetEstudioAsync(id_prof, cc_per);
            if (estudio == null)
            {
                return NotFound();
            }
            return estudio;
        }

        [HttpGet(Name = "GetEstudios")]
        public IEnumerable<Estudio> GetEstudios()
        {
            return _estudioRepository.GetEstudios();
        }

        [HttpPost(Name = "CreateEstudio")]
        public async Task<ActionResult<Estudio>> CreateEstudio(Estudio estudio)
        {
            await _estudioRepository.CreateEstudioAsync(estudio);
            return CreatedAtAction(nameof(GetEstudio), new { id_prof = estudio.IdProf, cc_per = estudio.CcPer }, estudio);
        }

        [HttpPut(Name = "UpdateEstudio")]
        public async Task<ActionResult<Estudio>> UpdateEstudio(Estudio estudio)
        {
            await _estudioRepository.UpdateEstudioAsync(estudio);
            return CreatedAtAction(nameof(GetEstudio), new { id_prof = estudio.IdProf, cc_per = estudio.CcPer }, estudio);
        }

        [HttpDelete(Name = "DeleteEstudio")]
        public async Task<IActionResult> DeleteEstudio(int id_prof, int cc_per)
        {
            await _estudioRepository.DeleteEstudioAsync(id_prof, cc_per);
            return Ok();
        }

    }
}
