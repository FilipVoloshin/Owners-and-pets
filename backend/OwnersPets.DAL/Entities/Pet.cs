using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OwnersPets.DAL.Entities
{
    public enum PetType
    {
        Bird,
        Cat,
        Dog,
        Fish,
        Hamster,
        Lizard,
        Rabbit,
        Rat,
        Spider,
        Snake,
        Turtle,
        Other
    }
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public PetType Type { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Owner Owner { get; set; }
    }
}
