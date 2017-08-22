using System.Collections.Generic;

namespace OwnersPets.Core.DTOs
{
    public class OwnerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PetDTO> Pets { get; set; }
    }
}
