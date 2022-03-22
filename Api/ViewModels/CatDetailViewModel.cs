namespace Api.ViewModels
{
    public class CatDetailViewModel
    {
        public CatViewModel Cat { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
