using Domain.Models;

namespace Domain.Services
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        IList<Comment> GetAllCommentsFromCat(int catId);
        bool Add(Comment comment, string user);
    }
}
