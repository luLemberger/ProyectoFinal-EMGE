using LicenciasAPI.Data;
using LicenciasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenciasAPI.Repositories
{
    public class LicenciaRepository : Repository<Licencia>, ILicenciaRepository
    {
        public LicenciaRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Licencia>> GetByDNIAsync(string dni)
        {
            return await _dbSet.Where(l => l.DNI == dni).ToListAsync();
        }
    }
}
