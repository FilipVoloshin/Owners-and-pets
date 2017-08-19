using OwnersPets.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace OwnersPets.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Owner> OwnersRepository { get; set; }
        IGenericRepository<Pet> PetsRepository { get; set; }
        Task SaveAsync();
    }
}
