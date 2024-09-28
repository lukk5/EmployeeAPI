using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Repositories;

public interface IBaseRepository<T> where T: class
{
       Task AddAsync(T entity, CancellationToken cancellationToken);
       Task UpdateAsync(T entity,  CancellationToken cancellationToken);
       Task DeleteAsync(Guid id,  CancellationToken cancellationToken);
       Task<T> GetAsync(Guid id,  CancellationToken cancellationToken);
       Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
}

public class BaseRepository<T>(Context context) : IBaseRepository<T>
       where T : class
{
       public async Task AddAsync(T entity, CancellationToken cancellationToken)
       {
              await context.Set<T>().AddAsync(entity, cancellationToken);
              await context.SaveChangesAsync(cancellationToken);
       }

       public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
       {
              context.Set<T>().Update(entity);
              await context.SaveChangesAsync(cancellationToken);
       }

       public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
       {
              var entity = await context.Set<T>().FirstOrDefaultAsync(x=> x.Id , cancellationToken);
              
       }

       public async Task<T> GetAsync(Guid id)
       {
              throw new NotImplementedException();
       }

       public async Task<List<T>> GetAllAsync()
       {
              throw new NotImplementedException();
       }
}