using Backend.Interfaces;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id) =>
            Ok(await _service.Student.GetStudentById(id));
    }
}
