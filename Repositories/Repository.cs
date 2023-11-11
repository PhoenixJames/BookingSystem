using BookingSystem.Entities;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly BookingSystemContext _context;

    public Repository(BookingSystemContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public async Task DeleteAsync(long id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }
    public IQueryable<T> Query()
    {
        return _context.Set<T>().AsQueryable();
    }
}