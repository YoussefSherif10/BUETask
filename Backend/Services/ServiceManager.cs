using Backend.Interfaces;

namespace Backend.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repository;
        private readonly Lazy<IStudentService> _student;

        public ServiceManager(IRepositoryManager repository)
        {
            _repository = repository;
            _student = new Lazy<IStudentService>(() => new StudentService(_repository));
        }

        public IStudentService Student => _student.Value;
    }
}
