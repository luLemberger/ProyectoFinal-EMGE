using AutoMapper;
using LicenciasAPI.Dtos;
using LicenciasAPI.Models;
using LicenciasAPI.Response;
using LicenciasAPI.UnitOfWork;

namespace LicenciasAPI.Services
{
    public class LicenciaService : ILicenciaService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LicenciaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<LicenciaReadDto>>> GetAllAsync()
        {
            var list = await _uow.Licencias.GetAllAsync();
            var dto = list.Select(l => _mapper.Map<LicenciaReadDto>(l));
            return ApiResponse<IEnumerable<LicenciaReadDto>>.Success(dto);
        }

        public async Task<ApiResponse<LicenciaReadDto>> GetByIdAsync(int id)
        {
            var entity = await _uow.Licencias.GetByIdAsync(id);
            if (entity == null)
                return ApiResponse<LicenciaReadDto>.NotFound($"Licencia con id {id} no encontrada.");
            return ApiResponse<LicenciaReadDto>.Success(_mapper.Map<LicenciaReadDto>(entity));
        }

        public async Task<ApiResponse<LicenciaReadDto>> CreateAsync(LicenciaCreateDto dto)
        {
            var entity = _mapper.Map<Licencia>(dto);
            await _uow.Licencias.AddAsync(entity);
            await _uow.CompleteAsync();
            return ApiResponse<LicenciaReadDto>.Success(_mapper.Map<LicenciaReadDto>(entity), "Licencia creada con éxito.");
        }

        public async Task<ApiResponse<LicenciaReadDto>> UpdateAsync(int id, LicenciaUpdateDto dto)
        {
            var entity = await _uow.Licencias.GetByIdAsync(id);
            if (entity == null)
                return ApiResponse<LicenciaReadDto>.NotFound($"Licencia con id {id} no encontrada.");

            _mapper.Map(dto, entity);
            _uow.Licencias.Update(entity);
            await _uow.CompleteAsync();
            return ApiResponse<LicenciaReadDto>.Success(_mapper.Map<LicenciaReadDto>(entity), "Licencia actualizada con éxito.");
        }

        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            var entity = await _uow.Licencias.GetByIdAsync(id);
            if (entity == null)
                return ApiResponse<object>.NotFound($"Licencia con id {id} no encontrada.");

            _uow.Licencias.Remove(entity);
            await _uow.CompleteAsync();
            return ApiResponse<object>.Success(null, "Licencia eliminada con éxito.");
        }
    }
}
