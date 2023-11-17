using Backend.Extensions;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.DTOs;
using Backend.Models.Params;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repository;

        public StudentService(IRepositoryManager repository) => _repository = repository;

        public async Task<StudentDto> AddStudent(StudentForCreationDto student)
        {
            var studentEntity = student.ToStudent();
            _repository.Student.AddStudent(studentEntity);
            await _repository.Save();
            return studentEntity.ToStudentDto();
        }

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
                .Search(studentParams.SearchTerm)
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
            var student = await _repository.Student.GetStudentById(id, false);
            return student.ToStudentDto();
        }

        public async Task RemoveStudent(int id)
        {
            var student = new Student { StudentId = id };
            _repository.Student.DeleteStudent(student);
            await _repository.Save();
        }

        public async Task UpdateStudent(int StudentId, StudentForUpdateDto student)
        {
            var studentEntity = await _repository.Student.GetStudentById(StudentId, true);
            studentEntity.Name = student.Name;
            studentEntity.Age = student.Age;
            studentEntity.Email = student.Email;
            studentEntity.Phone = student.Phone;
            _repository.Student.UpdateStudent(studentEntity);
            await _repository.Save();
        }
    }
}
