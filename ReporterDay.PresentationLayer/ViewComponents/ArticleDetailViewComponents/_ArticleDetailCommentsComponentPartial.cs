using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.DataAccessLayer.Context;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailCommentsComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ArticleDetailCommentsComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetCommentsByArticleId(id);
            return View(values);
        }
    }
}
