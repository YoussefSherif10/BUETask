namespace Backend.Interfaces
{
    public interface IRepositoryManager
    {
        public IStudentRepository Student { get; }
        public Task Save();
    }
}
