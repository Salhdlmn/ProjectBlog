using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.BusinessLayer.Concrete;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleRecentArticlesComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleRecentArticlesComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        


        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetLast5Blog();
            return View(values);  
        }
    }
}
