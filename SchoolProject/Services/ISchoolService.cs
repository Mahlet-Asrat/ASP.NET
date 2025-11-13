using SchoolApi.SchoolProject.Dtos;

namespace SchoolApi.Services
{
    public interface ISchoolService
    {
        Task<ReadSchoolDto> CreateAsync(CreateSchoolDto dto, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<ReadSchoolDto>> GetAllAsync(CancellationToken ct = default);
        Task<ReadSchoolDto?> GetByIdAsync(int id, CancellationToken ct = default);
        Task UpdateAsync(int id, UpdateSchoolDto dto, CancellationToken ct = default);
    }
}