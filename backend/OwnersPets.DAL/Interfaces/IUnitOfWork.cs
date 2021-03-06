﻿using OwnersPets.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace OwnersPets.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Owner> OwnersRepository { get; }
        IGenericRepository<Pet> PetsRepository { get; }
        Task SaveAsync();
    }
}
