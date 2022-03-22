using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class CatViewModel
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

        public Cat Convert()
        {
            return new Cat
            {
                Name = Name,
                Description = Description,
                Charm = Charm,
                Coolness = Coolness,
                Fluidness = Fluidness,
                Softness = Softness,
                Spookiness = Spookiness,
                Wildness = Wildness,
                ImageUri = ImageUri
            };
        }
    }
}
