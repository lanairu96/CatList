using Infrastructure.Contexts;
using Domain.Models;
using Domain.Services;

namespace Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment, int>, ICommentRepository
    {
        private readonly ICatRepository _catRepo;
        private readonly IUserRepository _userRepo;

        public CommentRepository(AppDbContext context, ICatRepository catRepo, IUserRepository userRepo) : base(context)
        {
            _catRepo = catRepo;
            _userRepo = userRepo;
        } 

        public bool Add(Comment comment, string user)
        {
            if (!_catRepo.Exists(comment.CatId))
                return false;

            comment.UserId = _userRepo.GetUserByUsername(user).Id;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return true;
        }

        public IList<Comment> GetAllCommentsFromCat(int catId) => _context.Comments.Where(c => c.CatId == catId).ToList();

        
    }
}
