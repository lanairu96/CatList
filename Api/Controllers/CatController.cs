using Api.ViewModels;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RankCats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatController : ControllerBase
    {
        private readonly ILogger<CatController> _logger;
        private readonly ICatRepository _catRepo;
        private readonly ICommentRepository _commentRepo;
        private readonly IUserRepository _userRepo;
        private readonly IUserResolverService _userResolver;

        public CatController(ILogger<CatController> logger, ICatRepository catRepo, ICommentRepository commentRepo,
            IUserRepository userRepo, IUserResolverService userResolverService)
        {
            _logger = logger;
            _catRepo = catRepo;
            _commentRepo = commentRepo;
            _userRepo = userRepo;
            _userResolver = userResolverService;
        }

        [HttpGet]
        public ActionResult GetAll() => Ok(_catRepo.GetAll());

        [HttpGet, Route("{id}")]
        public ActionResult GetById(int id)
        {
            var cat = _catRepo.GetById(id);
            var comments = _commentRepo.GetAllCommentsFromCat(id);
            return cat != null ?
                Ok(
                    new CatDetailViewModel
                    {
                        Cat = new CatViewModel
                        {
                            Name = cat.Name,
                            Description = cat.Description,
                            Charm = cat.Charm,
                            Coolness = cat.Coolness,
                            Fluidness = cat.Fluidness,
                            Softness = cat.Softness,
                            Spookiness = cat.Spookiness,
                            Wildness = cat.Wildness,
                            ImageUri = cat.ImageUri
                        },
                        Comments = comments.Select(c => new CommentViewModel(c, _userRepo.GetById(c.UserId).UserName)).OrderBy(c => c.Date).ToList()
                    })
                : NotFound();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CatViewModel cat) => Ok(_catRepo.Add(cat.Convert()));

        [HttpPut]
        [Authorize]
        public bool Update(int id, CatViewModel catData)
        {
            var cat = _catRepo.GetById(id);
            cat.CopyValues(catData.Convert());
            return _catRepo.Update(cat);
        }

        [HttpDelete]
        [Authorize]
        public bool Delete(int id) => _catRepo.Delete(id);

        [HttpPost, Route("AddComment")]
        [Authorize]
        public bool AddComment(CommentCreateViewModel model)
        {
            var user = _userResolver.GetUserId();
            return _commentRepo.Add(model.Convert(), user);
        }
    }
}