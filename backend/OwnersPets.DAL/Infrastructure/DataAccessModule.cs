using Ninject.Extensions.Factory;
using Ninject.Modules;
using OwnersPets.DAL.Contexts;
using OwnersPets.DAL.Interfaces;
using OwnersPets.DAL.Repositories;

namespace OwnersPets.DAL.Infrastructure
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<OwnersPetsContext>().ToSelf();
            Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            Bind<IRepositoryFactory>().ToFactory();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
