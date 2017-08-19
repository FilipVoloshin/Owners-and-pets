using System.Data.Entity;

namespace OwnersPets.DAL.Interfaces
{
    public interface IRepositoryFactory
    {
        IGenericRepository<T> CreateRepository<T>(DbContext context)
            where T : class, IEntity;
    }
}
