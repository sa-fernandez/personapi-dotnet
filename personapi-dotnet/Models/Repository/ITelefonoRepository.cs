using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface ITelefonoRepository
    {
        Task<Telefono> CreateTelefonoAsync(Telefono telefono);
        Task<Telefono> GetTelefonoAsync(string id);
        IEnumerable<Telefono> GetTelefonos();
        Task<bool> UpdateTelefonoAsync(Telefono telefono);
        Task<bool> DeleteTelefonoAsync(string id);
    }
}
