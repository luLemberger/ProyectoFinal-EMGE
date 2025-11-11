using LicenciasAPI.Repositories;

namespace LicenciasAPI.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ILicenciaRepository Licencias { get; }
        Task<int> CompleteAsync();
    }
}
