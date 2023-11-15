using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Employees.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext appDbContext)
            : base(appDbContext) { }

        public void AddStudent(Student student) => Create(student);

        public void DeleteStudent(Student student) => Delete(student);

        public IQueryable<Student> GetAllStudents()
        {
            return FindAll();
        }

        public Task<Student> GetStudentById(int id) =>
            FindByCondition(x => x.StudentId == id, false).SingleAsync();

        public void UpdateStudent(Student student) => Update(student);
    }
}
