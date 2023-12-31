using Backend.Models;
using Backend.Models.DTOs;
using Backend.Utils;

namespace Backend.Extensions
{
    public static class StudentQueries
    {
        public static IQueryable<Student> Sort(
            this IQueryable<Student> query,
            StudentSortBy? sortBy
        ) =>
            query = sortBy switch
            {
                StudentSortBy.Name => query.OrderBy(c => c.Name),
                StudentSortBy.Age => query.OrderBy(c => c.Age),
                _ => query.OrderBy(c => c.StudentId)
            };

        public static IQueryable<Student> Filter(
            this IQueryable<Student> query,
            StudentFilterBy? filterBy,
            string? FilterValue
        ) =>
            query = filterBy switch
            {
                StudentFilterBy.Name => query.Where(c => c.Name.Contains(FilterValue)),
                StudentFilterBy.Age => query.Where(c => c.Age >= Convert.ToByte(FilterValue)),
                StudentFilterBy.Email => query.Where(c => c.Email.Contains(FilterValue)),
                _ => query
            };

        public static IQueryable<Student> Search(this IQueryable<Student> query, string? searchTerm) 
        {
            if(!string.IsNullOrEmpty(searchTerm))
                return query.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));

            return query;
        }

        public static IQueryable<StudentDto> ToStudentDto(this IQueryable<Student> query) =>
            query.Select(s => new StudentDto(s.StudentId, s.Name, s.Age, s.Email, s.Phone));

        public static StudentDto ToStudentDto(this Student student) =>
            new(student.StudentId, student.Name, student.Age, student.Email, student.Phone);

        public static Student ToStudent(this StudentForCreationDto student) =>
            new()
            {
                Name = student.Name,
                Age = student.Age,
                Email = student.Email,
                Phone = student.Phone
            };
    }
}
