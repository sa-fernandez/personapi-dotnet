using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        protected readonly PersonaDbContext _context;
        public PersonaRepository(PersonaDbContext context) => _context = context;
        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<bool> DeletePersonaAsync(int id)
        {
            var persona = _context.Personas.Find(id);
            if(persona is null)
            {
                return false;
            }
            _context.Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Persona> GetPersonaAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            return persona;
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return _context.Personas.ToList();
        }

        public async Task<bool> UpdatePersonaAsync(Persona persona)
        {
            _context.Personas.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
