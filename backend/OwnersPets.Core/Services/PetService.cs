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
    public class PetService : IPetService
    {
        private readonly IUnitOfWork unitOfWork;

        public PetService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PetDTO>> GetAllAsync()
        {
            var pets = await unitOfWork.PetsRepository.GetAllAsync();
            var result = new List<PetDTO>();
            foreach (var pet in pets)
            {
                var petDTO = new PetDTO
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    PetType = pet.Type,
                    OwnerId = pet.OwnerId
                };
                result.Add(petDTO);
            }
            return result;
        }

        public PetDTO GetById(int id)
        {
            try
            {
                var pet = unitOfWork.PetsRepository.GetById(id);
                if (pet == null)
                {
                    throw new NullReferenceException(nameof(pet));
                }
                var result = new PetDTO
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    PetType = pet.Type,
                    OwnerId = pet.OwnerId
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(PetDTO pet)
        {
            try
            {
                if (pet == null)
                {
                    throw new NullReferenceException(nameof(pet));
                }
                var petModel = new Pet
                {
                    Name = pet.Name,
                    OwnerId = pet.OwnerId,
                    Type = pet.PetType
                };
                unitOfWork.PetsRepository.Create(petModel);
                unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(PetDTO pet)
        {
            try
            {
                if (pet == null)
                {
                    throw new NullReferenceException(nameof(pet));
                }
                var petModel = new Pet
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    OwnerId = pet.OwnerId,
                    Type = pet.PetType
                };

                unitOfWork.PetsRepository.Update(petModel);
                unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            var pet = unitOfWork.PetsRepository.GetById(id);

            try
            {
                if (pet == null)
                {
                    throw new NullReferenceException(nameof(pet));
                }

                unitOfWork.PetsRepository.Delete(id);
                unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
