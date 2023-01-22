namespace MarketplaceManagement.DataAccess.Abstractions;

public interface IBaseRepository<T>
{
    IQueryable<T> Table { get; }
    Task AddAsync(T entity);
    void Update(T entity);
}
