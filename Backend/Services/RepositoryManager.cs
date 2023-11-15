using Backend.Data;
using Backend.Interfaces;

namespace Backend.Services
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IStudentRepository> _student;

        public RepositoryManager(AppDbContext appDbContext)
        {
            _context = appDbContext;
            _student = new Lazy<IStudentRepository>(() => new StudentRepository(appDbContext));
        }

        public IStudentRepository Student => _student.Value;

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
