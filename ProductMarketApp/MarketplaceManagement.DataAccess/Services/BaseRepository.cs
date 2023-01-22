using MarketplaceManagement.DataAccess.Abstractions;
using MarketplaceManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceManagement.DataAccess.Services;

public class BaseRepository<T> : IBaseRepository<T> where T:class
{
    private readonly ApplicationContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IQueryable<T> Table
    { get { return _dbSet; } }

    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }
}
