using EntitySample.Data.Entities;
using EntitySample.Data;
using Microsoft.EntityFrameworkCore;


namespace EntitySample.Services
{
    public class StudentService : IStudentService
    {
        public readonly MyDbContext _context;
        public StudentService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Student>?> GetAllAsync()
        {
            return _context.Students?.ToList() != null ? await _context.Students.ToListAsync() : new List<Student>();
        }

        public async Task<Student?> GetOneAsync(int id)
        {
            if (_context.Students == null)
                return null;
            return await _context.Students.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> AddAsync(Student entity)
        {
            if (_context.Students == null) return null;

            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Student?> EditAsync(int id, Student enity)
        {
            if (id == null || _context.Students == null) return null;


            var entity = await _context.Students.FindAsync(id);
            return entity;
        }
        public async Task Remove(int id)
        {
            var studentDeleted = _context.Students.FirstOrDefault(s => s.Id == id);
            if (studentDeleted != null)
            {
                _context.Students.Remove(studentDeleted);
                await _context.SaveChangesAsync();
            }
        }
    }
}
