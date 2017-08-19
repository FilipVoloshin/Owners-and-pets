using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OwnersPets.DAL.Entities
{
    public class Owner
    {
        public Owner()
        {
            Pets = new List<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
