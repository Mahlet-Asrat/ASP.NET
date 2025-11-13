using AutoMapper;
using SchoolApi.SchoolProject.Repositories;
using SchoolApi.SchoolProject.Dtos;

namespace SchoolApi.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _repo;
        private readonly IMapper _mapper;

        public SchoolService(ISchoolRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ReadSchoolDto>> GetAllAsync(CancellationToken ct = default)
        {
            var schools = await _repo.GetAllASync(ct);
            return _mapper.Map<IEnumerable<ReadSchoolDto>>(schools);
        }

        public async Task<ReadSchoolDto?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var school = await _repo.GetByIdAsync(id, ct);
            return school is null ? null : _mapper.Map<ReadSchoolDto>(school);
        }

        public async Task<ReadSchoolDto> CreateAsync(CreateSchoolDto dto, CancellationToken ct = default)
        {
            var newSchool = _mapper.Map<SchoolProject.Models.School>(dto);
            var added = await _repo.AddAsync(newSchool, ct);
            return _mapper.Map<ReadSchoolDto>(added);
        }

        public async Task UpdateAsync(int id, UpdateSchoolDto dto, CancellationToken ct = default)
        {
            var find = await _repo.GetByIdAsync(id, ct);
            if (find is null)
            {
                throw new KeyNotFoundException("School not found");
            }
            _mapper.Map(dto, find);
            await _repo.UpdateAsync(find, ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var existing = await _repo.GetByIdAsync(id, ct);

            if (existing is null) throw new KeyNotFoundException("School not found");

            await _repo.DeleteAsync(existing, ct);
        }

    }
}
