using Backend.Models.DTOs;
using Backend.Models.Params;

namespace Backend.Interfaces
{
    public interface IStudentService
    {
        public Task<(IEnumerable<StudentDto> students, PagingInfoDto pagingInfo)> GetAllStudents(
            StudentParams studentParams
        );

        public Task<StudentDto> GetStudentById(int id);

        public Task RemoveStudent(int id);

        public Task<StudentDto> AddStudent(StudentForCreationDto student);

        public Task UpdateStudent(int StudentId, StudentForUpdateDto student);
    }
}
