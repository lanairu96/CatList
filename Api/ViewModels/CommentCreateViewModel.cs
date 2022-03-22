using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class CommentCreateViewModel
    {
        [Required]
        public int CatId { get; set; }

        [Required, StringLength(50)]
        public string Comment { get; set; }


        public Comment Convert()
        {
            return new Comment
            {
                CatId = CatId,
                Message = Comment
            };
        }
    }
}
