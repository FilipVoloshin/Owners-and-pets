using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnersPets.DAL.Interfaces
{
    public interface IRepository { }

    public interface IGenericRepository<T> : IRepository
    {
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        Task<T> GetByIdDeletedAsync(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        Task RestoreAsync(int id);
        IQueryable<T> Query { get; }
        IQueryable<T> Deleted { get; }
    }
}
