using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.SchoolProject.Dtos;
using SchoolApi.Services;

namespace SchoolApi.SchoolProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {

        private readonly ISchoolService _schoolService;
        private readonly IValidator<CreateSchoolDto> _createValidator;
        private readonly IValidator<UpdateSchoolDto> _updateValidator;

        public SchoolController(ISchoolService schoolService, IValidator<CreateSchoolDto> createValidator, IValidator<UpdateSchoolDto> updateValidator)
        {
            _schoolService = schoolService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadSchoolDto>>> GetAll()
        {
            var schools = await _schoolService.GetAllAsync();
            return Ok(schools);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadSchoolDto>> GetById(int id)
        {
            var school = await _schoolService.GetByIdAsync(id);
            if(school is null)
            {
                return NotFound("School not found");
            }
            return Ok(school);
        }

        [HttpPost]
        public async Task<ActionResult<ReadSchoolDto>> Create([FromBody] CreateSchoolDto dto)
        {

            var res = await _createValidator.ValidateAsync(dto);
            if (!res.IsValid)
            {
                return BadRequest(res.Errors.Select(e => e.ErrorMessage));
            }
            var created = await _schoolService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateSchoolDto dto)
        {
            try
            {
                var res = await _updateValidator.ValidateAsync(dto);
                if (!res.IsValid)
                {
                    return BadRequest(res.Errors.Select(e => e.ErrorMessage));
                }
                await _schoolService.UpdateAsync(id, dto);
                return NoContent();
            }catch (KeyNotFoundException)
            {
                return NotFound("School not found");
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _schoolService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("School not found");
            }
        } 
    }

}
