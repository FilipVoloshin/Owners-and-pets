using OwnersPets.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OwnersPets.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, IEntity
    {
        private DbContext context;
        private IDbSet<T> entities;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Query.ToListAsync();
        }

        public T GetById(int id)
        {
            return Query.SingleOrDefault(d => d.Id == id);
        }

        public void Create(T item)
        {
            try
            {
                if (item == null)
                {
                    throw new NullReferenceException(nameof(item));
                }
                Entities.Add(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T item)
        {
            try
            {
                if (item == null)
                {
                    throw new NullReferenceException(nameof(item));
                }
                context.Entry(item).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var item = GetById(id);

                if (item == null)
                {
                    throw new NullReferenceException(nameof(id));
                }
                item.IsDeleted = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetByIdDeletedAsync(int id)
        {
            return await Deleted.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task RestoreAsync(int id)
        {
            try
            {
                var item = await GetByIdDeletedAsync(id);
                if (item == null)
                {
                    throw new NullReferenceException(nameof(id));
                }
                item.IsDeleted = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected IDbSet<T> Entities => entities ?? (entities = context.Set<T>());
        public IQueryable<T> Query => Entities.Where(x => !x.IsDeleted);
        public IQueryable<T> Deleted => Entities.Where(x => x.IsDeleted);
    }
}
