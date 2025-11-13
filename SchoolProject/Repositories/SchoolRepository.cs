using SchoolApi.Models;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using SchoolApi.SchoolProject.Data;


namespace SchoolApi.SchoolProject.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolDbContext _context;

        public SchoolRepository(SchoolDbContext context)
        {
            _context = context;
        }

        // using dapper
        public async Task<IEnumerable<Models.School>> GetAllASync(CancellationToken ct = default)
        {
            using var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync(ct);
            }
            var sql = "SELECT id, name, director, teachers, students FROM schools";
            var result = await conn.QueryAsync<Models.School>(sql);
            return result;
        }

        public async Task<Models.School?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            using var conn = _context.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync(ct);
            }
            var sql = "SELECT id, name, director, teachers, students FROM schools WHERE id = @Id";
            return await conn.QuerySingleOrDefaultAsync<Models.School>(sql, new { Id = id });
        }

        // using EF Core

        public async Task<Models.School> AddAsync(Models.School school, CancellationToken ct = default)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync(ct);
            return school;
        }

        public async Task UpdateAsync(Models.School school, CancellationToken ct = default)
        {
            _context.Schools.Update(school);
            await _context.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Models.School school, CancellationToken ct = default)
        {
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
        }

        public Task SaveChangeAsync(CancellationToken ct = default) => _context.SaveChangesAsync(ct);
    }
}
