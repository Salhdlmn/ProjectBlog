using Microsoft.AspNetCore.Mvc;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailAddCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int articleId)
        {
            var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;

            if (!isAuthenticated)
            {
                // Giriş yapmamışsa özel bir view dönebilirsin (örneğin: Giriş yapın butonu olan)
                return View("NotLoggedIn");
            }
            ViewBag.i=articleId;

            return View(); // Giriş yapanlar formu görür
        }
    }

}
