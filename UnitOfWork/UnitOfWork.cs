
using LicenciasAPI.Data;
using LicenciasAPI.Repositories;

namespace LicenciasAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly ILicenciaRepository _licenciaRepository;

        public UnitOfWork(ApplicationDbContext context, ILicenciaRepository licenciaRepository)
        {
            _context = context;
            _licenciaRepository = licenciaRepository;
        }

        public ILicenciaRepository Licencias => _licenciaRepository;

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
