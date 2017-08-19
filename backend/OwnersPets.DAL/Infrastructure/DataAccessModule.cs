using Ninject.Modules;
using OwnersPets.DAL.Contexts;

namespace OwnersPets.DAL.Infrastructure
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<OwnersPetsContext>().ToSelf();
        }
    }
}
