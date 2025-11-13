





namespace SchoolApi.Repositories
{
    public interface ISchoolRepository
    {
        Task<Models.School> AddAsync(Models.School school, CancellationToken ct = default);
        Task DeleteAsync(Models.School school, CancellationToken ct = default);
        Task<IEnumerable<Models.School>> GetAllASync(CancellationToken ct = default);
        Task<Models.School?> GetByIdAsync(int id, CancellationToken ct = default);
        Task SaveChangeAsync(CancellationToken ct = default);
        Task UpdateAsync(Models.School school, CancellationToken ct = default);
    }
}