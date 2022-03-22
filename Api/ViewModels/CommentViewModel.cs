using Domain.Models;

namespace Api.ViewModels
{
    public class CommentViewModel
    {
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public CommentViewModel(Comment c, string user)
        {
            User = user;
            Date = c.CreatedAt;
            Comment = c.Message;
        }
    }
}
