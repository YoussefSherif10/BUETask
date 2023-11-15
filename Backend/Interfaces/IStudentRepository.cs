using Backend.Models;

namespace Backend.Interfaces
{
    public interface IStudentRepository
    {
        public IQueryable<Student> GetAllStudents();
        public Task<Student> GetStudentById(int id, bool trackChanges);
        public void AddStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(Student student);
    }
}
