using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class ProfesionRepository : IProfesionRepository
    {
        protected readonly PersonaDbContext _context;
        public ProfesionRepository(PersonaDbContext context) => _context = context;

        public async Task<Profesion> CreateProfesionAsync(Profesion profesion)
        {
            _context.Add(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task<Profesion> GetProfesionAsync(int id)
        {
            return await _context.Profesions.FindAsync(id);
        }

        public IEnumerable<Profesion> GetProfesiones()
        {
            return _context.Profesions.ToList();
        }

        public async Task<bool> UpdateProfesionAsync(Profesion profesion)
        {
            _context.Profesions.Entry(profesion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProfesionAsync(int id)
        {
            var profesion = _context.Profesions.Find(id);
            if (profesion is null)
            {
                return false;
            }
            _context.Remove(profesion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
