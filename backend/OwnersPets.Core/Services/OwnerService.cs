using OwnersPets.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OwnersPets.Core.DTOs;
using OwnersPets.DAL.Interfaces;
using OwnersPets.DAL.Entities;
using System.Linq;

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
            var result = new List<OwnerDTO>();
            foreach (var owner in owners)
            {
                var ownerDTO = new OwnerDTO
                {
                    Id = owner.Id,
                    Name = owner.Name
                };
                if (owner.Pets != null)
                {
                    ownerDTO.Pets = owner.Pets.Select(c => new PetDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        OwnerId = c.OwnerId,
                        PetType = c.Type
                    }).ToList();
                };
                result.Add(ownerDTO);
            }
            return result;
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
                var result = new OwnerDTO
                {
                    Id = owner.Id,
                    Name = owner.Name
                };
                if (owner.Pets != null)
                {
                    result.Pets = owner.Pets.Select(c => new PetDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        OwnerId = c.OwnerId,
                        PetType = c.Type
                    }).ToList();
                };
                return result;
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

                var ownerModel = new Owner
                {
                    Name = owner.Name,
                };

                unitOfWork.OwnersRepository.Create(ownerModel);
                unitOfWork.SaveAsync();
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
                var ownerModel = new Owner
                {
                    Id = owner.Id,
                    Name = owner.Name
                };
                unitOfWork.OwnersRepository.Update(ownerModel);
                unitOfWork.SaveAsync();
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
                unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
