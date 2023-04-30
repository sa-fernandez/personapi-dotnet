using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        protected readonly PersonaDbContext _context;
        public EstudioRepository(PersonaDbContext context) => _context = context;

        public async Task<Estudio> CreateEstudioAsync(Estudio estudio)
        {
            _context.Add(estudio);
            await _context.SaveChangesAsync();
            return estudio;
        }

        public async Task<Estudio> GetEstudioAsync(int id_prof, int cc_per)
        {
            var estudio = await _context.Estudios.FindAsync(id_prof, cc_per);
            return estudio;
        }

        public IEnumerable<Estudio> GetEstudios()
        {
            return _context.Estudios.ToList();
        }

        public async Task<bool> UpdateEstudioAsync(Estudio estudio)
        {
            _context.Estudios.Entry(estudio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> DeleteEstudioAsync(int id_prof, int cc_per)
        {
            var estudio = _context.Estudios.Find(id_prof, cc_per);
            if (estudio is null)
            {
                return false;
            }
            _context.Remove(estudio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
