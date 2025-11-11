using LicenciasAPI.Models;

namespace LicenciasAPI.Repositories
{
    public interface ILicenciaRepository : IRepository<Licencia>
    {
        Task<IEnumerable<Licencia>> GetByDNIAsync(string dni);
    }
}
