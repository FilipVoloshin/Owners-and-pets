using OwnersPets.DAL.Entities;
using System.Data.Entity;

namespace OwnersPets.DAL.Contexts
{
    public partial class OwnersPetsContext : DbContext
    {

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public OwnersPetsContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new OwnersPetsInitializer());
            Database.Initialize(true);
        }

    }
}
