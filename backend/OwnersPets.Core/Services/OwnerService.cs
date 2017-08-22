using OwnersPets.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OwnersPets.Core.DTOs;
using OwnersPets.DAL.Interfaces;
using AutoMapper;
using OwnersPets.DAL.Entities;

namespace OwnersPets.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork unitOfWork;

        public OwnerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OwnerDTO>> GetAllAsync()
        {
            var owners = await unitOfWork.OwnersRepository.GetAllAsync();
            Mapper.Initialize(cfg => cfg.CreateMap<Owner, OwnerDTO>());
            return Mapper.Map<IEnumerable<Owner>, IEnumerable<OwnerDTO>>(owners);
        }

        public OwnerDTO GetById(int id)
        {
            try
            {
                var owner = unitOfWork.OwnersRepository.GetById(id);
                if (owner == null)
                {
                    throw new NullReferenceException(nameof(owner));
                }
                Mapper.Initialize(cfg => cfg.CreateMap<Owner, OwnerDTO>());
                return Mapper.Map<Owner, OwnerDTO>(owner);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(OwnerDTO owner)
        {
            try
            {
                if (owner == null)
                {
                    throw new NullReferenceException(nameof(owner));
                }
                Mapper.Initialize(cfg => cfg.CreateMap<OwnerDTO, Owner>());
                var ownerModel = Mapper.Map<OwnerDTO, Owner>(owner);
                unitOfWork.OwnersRepository.Create(ownerModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(OwnerDTO owner)
        {
            try
            {
                if (owner == null)
                {
                    throw new NullReferenceException(nameof(owner));
                }
                Mapper.Initialize(cfg => cfg.CreateMap<OwnerDTO, Owner>());
                var ownerModel = Mapper.Map<OwnerDTO, Owner>(owner);
                unitOfWork.OwnersRepository.Update(ownerModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            var owner = unitOfWork.OwnersRepository.GetById(id);

            try
            {
                if (owner == null)
                {
                    throw new NullReferenceException(nameof(owner));
                }

                unitOfWork.OwnersRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
