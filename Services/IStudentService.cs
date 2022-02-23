using EntitySample.Data.Entities;

namespace EntitySample.Services
{
    public interface IStudentService
    {
        public Task<IList<Student>?> GetAllAsync();

        public Task<Student?> GetOneAsync(int id);

        public Task<Student?> AddAsync(Student entity);

        public Task<Student?>EditAsync(int id,Student entity);

        public Task Remove(int id);
    }
}
