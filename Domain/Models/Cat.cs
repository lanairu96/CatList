using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Cat : AuditableBaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(5000)]
        public string Description { get; set; }

        [Required, Range(0, 100)]
        public int Charm { get; set; }

        [Required, Range(0, 100)]
        public int Coolness { get; set; }

        [Required, Range(0, 100)]
        public int Fluidness { get; set; }

        [Required, Range(0, 100)]
        public int Softness { get; set; }

        [Required, Range(0, 100)]
        public int Spookiness { get; set; }

        [Required, Range(0, 100)]
        public int Wildness { get; set; }

        [Required]
        public string ImageUri { get; set; }

        public ICollection<Comment> Comments { get; private set; }

        public void CopyValues(Cat other)
        {
            Name = other.Name;
            Description = other.Description;
            Charm = other.Charm;
            Coolness = other.Coolness;
            Fluidness = other.Fluidness;
            Softness = other.Softness;
            Spookiness = other.Spookiness;
            Wildness = other.Wildness;
            ImageUri = other.ImageUri;
        }
    }
}
