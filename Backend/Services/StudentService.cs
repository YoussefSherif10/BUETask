using Backend.Extensions;
using Backend.Interfaces;
using Backend.Models.DTOs;
using Backend.Models.Params;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repository;

        public StudentService(IRepositoryManager repository) => _repository = repository;

        public async Task<(
            IEnumerable<StudentDto> students,
            PagingInfoDto pagingInfo
        )> GetAllStudents(StudentParams studentParams)
        {
            var students = await _repository
                .Student
                .GetAllStudents()
                .Sort(studentParams.SortBy)
                .Pagination(studentParams.PageNumber, studentParams.PageSize)
                .Filter(studentParams.FilterBy, studentParams.FilterValue)
                .ToStudentDto()
                .ToListAsync();

            var pagingInfo = new PagingInfoDto
            {
                CurrentPage = studentParams.PageNumber,
                ItemsPerPage = studentParams.PageSize,
                TotalItems = await _repository.Student.GetAllStudents().CountAsync()
            };

            return (students, pagingInfo);
        }

        public async Task<StudentDto> GetStudentById(int id)
        {
            var student = await _repository.Student.GetStudentById(id);
            return student.ToStudentDto();
        }
    }
}
