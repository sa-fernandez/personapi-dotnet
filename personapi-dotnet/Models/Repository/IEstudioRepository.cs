using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public interface IEstudioRepository
    {
        Task<Estudio> CreateEstudioAsync(Estudio estudio);
        Estudio GetEstudioAsync(int idProf, int ccPer);
        IEnumerable<Estudio> GetEstudios();
        Task<bool> UpdateEstudioAsync(Estudio estudio);
        Task<bool> DeleteEstudioAsync(int idProf, int ccPer);

    }
}
