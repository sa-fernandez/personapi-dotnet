using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class EstudioRepository
    {
        protected readonly PersonaDbContext _context;
        public EstudioRepository(PersonaDbContext context) => _context = context;


    }
}
