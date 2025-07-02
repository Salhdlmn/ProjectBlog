using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;

namespace ReporterDay.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public DashboardController(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var userName = User.Identity?.Name;
            var articles = _articleService.TGetArticlesByAuthor(userName);

            ViewBag.BlogCount = articles.Count();

            return View();
        }

        [HttpGet]
        public IActionResult GetCommentDistribution()
        {
            var userName = User.Identity?.Name;
            var articles = _articleService.TGetArticlesByAuthor(userName);

            var data = articles.Select(article => new
            {
                article.Title,
                CommentCount = _commentService.TGetListAll().Count(c => c.ArticleId == article.ArticleId)
            }).ToList();

            return Json(data);
        }
    }
}
