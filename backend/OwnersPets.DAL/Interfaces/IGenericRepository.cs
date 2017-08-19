using System.Collections.Generic;
using System.Threading.Tasks;

namespace OwnersPets.DAL.Interfaces
{
    public interface IRepository { }

    public interface IGenericRepository<T> : IRepository
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsycn(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int item);
    }
}
