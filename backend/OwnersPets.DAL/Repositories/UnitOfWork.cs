using OwnersPets.DAL.Interfaces;
using System.Threading.Tasks;
using OwnersPets.DAL.Entities;
using OwnersPets.DAL.Contexts;
using System;

namespace OwnersPets.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private OwnersPetsContext context;
        private IRepositoryFactory factory;

        public IGenericRepository<Owner> ownersRepository;
        public IGenericRepository<Pet> petsRepository;

        public UnitOfWork(OwnersPetsContext context, IRepositoryFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public IGenericRepository<Owner> OwnersRepository
        {
            get
            {
                return ownersRepository 
                    ?? (ownersRepository = factory.CreateRepository<Owner>(context));
            }
        }

        public IGenericRepository<Pet> PetsRepository
        {
            get
            {
                return petsRepository
                    ?? (petsRepository = factory.CreateRepository<Pet>(context));
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        #region IDisposable Support

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion


    }
}
