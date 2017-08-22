using OwnersPets.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OwnersPets.Core.DTOs;
using OwnersPets.DAL.Interfaces;
using AutoMapper;
using OwnersPets.DAL.Entities;

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
            Mapper.Initialize(cfg => cfg.CreateMap<Pet, PetDTO>());
            return Mapper.Map<IEnumerable<Pet>, IEnumerable<PetDTO>>(pets);
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
                Mapper.Initialize(cfg => cfg.CreateMap<Pet, PetDTO>());
                return Mapper.Map<Pet, PetDTO>(pet);
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
                Mapper.Initialize(cfg => cfg.CreateMap<PetDTO, Pet>());
                var petModel = Mapper.Map<PetDTO, Pet>(pet);
                unitOfWork.PetsRepository.Create(petModel);
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
                Mapper.Initialize(cfg => cfg.CreateMap<PetDTO, Pet>());
                var petModel = Mapper.Map<PetDTO, Pet>(pet);
                unitOfWork.PetsRepository.Update(petModel);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
