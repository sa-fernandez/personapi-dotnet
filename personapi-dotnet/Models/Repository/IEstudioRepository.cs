using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface IEstudioRepository
    {
        Task<Estudio> CreateEstudioAsync(Estudio estudio);
        Task<Estudio> GetEstudioAsync(int id_prof, int cc_per);
        IEnumerable<Estudio> GetEstudios();
        Task<bool> UpdateEstudioAsync(Estudio estudio);
        Task<bool> DeleteEstudioAsync(int id_prof, int cc_per);

    }
}
