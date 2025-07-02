using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;
using System.Reflection.Metadata;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailAboutAuthorComponentPartial:ViewComponent
    {
        private readonly IArticleService? _articleService;

        public _ArticleDetailAboutAuthorComponentPartial(IArticleService? articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _articleService.TGetArticlesWithAuthorAndCategoriesById(id);
            if (values == null)
            {
                return Content(""); // veya hata mesajı gösterilebilir
            }

            return View(values);

            
        }
    }
}
