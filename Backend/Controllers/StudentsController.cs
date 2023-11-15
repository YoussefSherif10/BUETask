using Backend.Controllers.Filters;
using Backend.Interfaces;
using Backend.Models.DTOs;
using Backend.Models.Params;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public StudentsController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllStudents([FromQuery] StudentParams studentParams)
        {
            var (students, pagingInfo) = await _service.Student.GetAllStudents(studentParams);
            Response.Headers.Add("X-Pagination", pagingInfo.ToString());
            return Ok(students);
        }

        [HttpGet("{id:int}", Name = "GetStudentById")]
        public async Task<IActionResult> GetStudentById(int id) =>
            Ok(await _service.Student.GetStudentById(id));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            await _service.Student.RemoveStudent(id);
            return NoContent();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddStudent([FromBody] StudentForCreationDto student)
        {
            var createdStudent = await _service.Student.AddStudent(student);
            return CreatedAtRoute(
                "GetStudentById",
                new { id = createdStudent.StudentId },
                createdStudent
            );
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateStudent(
            int id,
            [FromBody] StudentForUpdateDto student
        )
        {
            await _service.Student.UpdateStudent(id, student);
            return NoContent();
        }
    }
}
