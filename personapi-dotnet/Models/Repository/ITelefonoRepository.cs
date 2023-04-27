using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface ITelefonoRepository
    {
        Task<Telefono> CreateTelefonoAsync(Telefono telefono);
        Telefono GetTelefonoAsync(int id);
        IEnumerable<Telefono> GetTelefonos();
        Task<bool> UpdateTelefonoAsync(Telefono telefono);
        Task<bool> DeleteTelefonoAsync(int id);
    }
}
