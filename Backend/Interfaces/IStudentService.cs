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
    }
}
