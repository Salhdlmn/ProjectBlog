using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.EntityLayer.Entities;
using ReporterDay.PresentationLayer.Helpers;

namespace ReporterDay.PresentationLayer.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _articleService = articleService;
            _userManager = userManager;
        }

        public IActionResult ArticleDetail(string id)
        {
            try
            {
                int decryptedId = int.Parse(EncryptionHelper.Decrypt(id));
                ViewBag.i = decryptedId;
                ViewBag.EncryptedId = id;

                return View(); // veya makale modelini de istersen view'a yolla
            }
            catch
            {
                return BadRequest("Geçersiz bağlantı");
            }
        }

        public async Task<IActionResult> BlogListByWriter()
        {
            var user = await _userManager.GetUserAsync(User);
            var blogs=_articleService.TGetListAll().Where(b=>b.AppUserId==user.Id).ToList();
            return View(blogs);
        }

    }
}
