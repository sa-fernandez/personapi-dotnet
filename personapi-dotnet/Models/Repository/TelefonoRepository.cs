using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class TelefonoRepository : ITelefonoRepository
    {
        protected readonly PersonaDbContext _context;
        public TelefonoRepository(PersonaDbContext context) => _context = context;

        public async Task<Telefono> CreateTelefonoAsync(Telefono telefono)
        {
            _context.Add(telefono);
            await _context.SaveChangesAsync();
            return telefono;
        }

        public async Task<Telefono> GetTelefonoAsync(string id)
        {
            return await _context.Telefonos.FindAsync(id);
        }

        public IEnumerable<Telefono> GetTelefonos()
        {
            return _context.Telefonos.ToList();
        }
        public async Task<bool> UpdateTelefonoAsync(Telefono telefono)
        {
            _context.Telefonos.Entry(telefono).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTelefonoAsync(string id)
        {
            var telefono = _context.Telefonos.Find(id);
            if (telefono is null)
            {
                return false;
            }
            _context.Remove(telefono);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
