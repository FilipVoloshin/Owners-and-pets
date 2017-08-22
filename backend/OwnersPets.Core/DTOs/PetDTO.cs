using OwnersPets.DAL.Entities;

namespace OwnersPets.Core.DTOs
{

    public class PetDTO
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public PetType PetType { get; set; }

        public int OwnerId { get; set; }

        public virtual OwnerDTO Owner { get; set; }
    }
}
