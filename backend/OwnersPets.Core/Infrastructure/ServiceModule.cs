using Ninject.Modules;
using OwnersPets.Core.Interfaces;
using OwnersPets.Core.Services;

namespace OwnersPets.Core.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOwnerService>().To<OwnerService>();
            Bind<IPetService>().To<PetService>();
        }
    }
}
