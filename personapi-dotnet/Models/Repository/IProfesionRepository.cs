using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface IProfesionRepository
    {
        Task<Profesion> CreateProfesionAsync(Profesion profesion);
        Task<Profesion> GetProfesionAsync(int id);
        IEnumerable<Profesion> GetProfesiones();
        Task<bool> UpdateProfesionAsync(Profesion profesion);
        Task<bool> DeleteProfesionAsync(int id);
    }
}
