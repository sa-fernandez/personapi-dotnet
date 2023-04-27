using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface IPersonaRepository
    {
        Task<Persona> CreatePersonaAsync(Persona persona);
        Task<Persona> GetPersonaAsync(int id);
        IEnumerable<Persona> GetPersonas();
        Task<bool> UpdatePersonaAsync(Persona persona);
        Task<bool> DeletePersonaAsync(int id);
    }
}
