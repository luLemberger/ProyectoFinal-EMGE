using LicenciasAPI.Dtos;
using LicenciasAPI.Response;

namespace LicenciasAPI.Services
{
    public interface ILicenciaService
    {
        Task<ApiResponse<IEnumerable<LicenciaReadDto>>> GetAllAsync();
        Task<ApiResponse<LicenciaReadDto>> GetByIdAsync(int id);
        Task<ApiResponse<LicenciaReadDto>> CreateAsync(LicenciaCreateDto dto);
        Task<ApiResponse<LicenciaReadDto>> UpdateAsync(int id, LicenciaUpdateDto dto);
        Task<ApiResponse<object>> DeleteAsync(int id);
    }
}
