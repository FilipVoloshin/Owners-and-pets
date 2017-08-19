using OwnersPets.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace OwnersPets.DAL.Contexts
{
    public class OwnersPetsInitializer : DropCreateDatabaseIfModelChanges<OwnersPetsContext>
    {
        protected override void Seed(OwnersPetsContext context)
        {
            #region Pets initializer

            Pet pet1 = new Pet
            {
                Id = 1,
                Name = "Maus",
                Type = PetType.Cat,
            };
            Pet pet2 = new Pet
            {
                Id = 2,
                Name = "Ronald",
                Type = PetType.Dog,
            };
            Pet pet3 = new Pet
            {
                Id = 3,
                Name = "Chichico",
                Type = PetType.Dog,
            };
            Pet pet4 = new Pet
            {
                Id = 4,
                Name = "Spider man",
                Type = PetType.Spider,
            };
            Pet pet5 = new Pet
            {
                Id = 5,
                Name = "Drako",
                Type = PetType.Lizard,
            };
            Pet pet6 = new Pet
            {
                Id = 6,
                Name = "Chokorab",
                Type = PetType.Rabbit,
            };
            Pet pet7 = new Pet
            {
                Id = 7,
                Name = "Drakarus",
                Type = PetType.Lizard,
            };
            Pet pet8 = new Pet
            {
                Id = 8,
                Name = "Golden",
                Type = PetType.Fish,
            };
            Pet pet9 = new Pet
            {
                Id = 9,
                Name = "Fi-fi",
                Type = PetType.Bird,
            };
            Pet pet10 = new Pet
            {
                Id = 10,
                Name = "Marnie",
                Type = PetType.Hamster,
            };
            Pet pet11 = new Pet
            {
                Id = 11,
                Name = "Spider man",
                Type = PetType.Spider,
            };
            Pet pet12 = new Pet
            {
                Id = 12,
                Name = "Django free",
                Type = PetType.Other,
            };
            Pet pet13 = new Pet
            {
                Id = 13,
                Name = "Aquamen",
                Type = PetType.Fish,
            };
            Pet pet14 = new Pet
            {
                Id = 14,
                Name = "Rattata",
                Type = PetType.Rat,
            };

            context.Pets.AddRange(new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6,pet7,
            pet8, pet9, pet10, pet11, pet12, pet13, pet14});

            #endregion

            #region Owners initializer

            Owner owner1 = new Owner
            {
                Id = 1,
                Name = "Filip",
                Pets = new List<Pet> { pet1, pet2 }
            };

            Owner owner2 = new Owner
            {
                Id = 2,
                Name = "Oleg",
                Pets = new List<Pet> { pet3, pet4, pet5, pet6 }
            };

            Owner owner3 = new Owner
            {
                Id = 3,
                Name = "Andrey",
                Pets = new List<Pet> { pet7, pet8, pet9 }
            };

            Owner owner4 = new Owner
            {
                Id = 4,
                Name = "Anna",
                Pets = new List<Pet> { pet10, pet11 }
            };

            Owner owner5 = new Owner
            {
                Id = 5,
                Name = "Galina",
                Pets = new List<Pet> { pet12, pet13 }
            };

            Owner owner6 = new Owner
            {
                Id = 5,
                Name = "Galina",
                Pets = new List<Pet> { pet14 }
            };

            context.Owners.AddRange(new List<Owner> { owner1, owner2, owner3, owner4, owner5, owner6 });

            #endregion

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
