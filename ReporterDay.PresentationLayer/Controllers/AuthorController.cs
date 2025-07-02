using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReporterDay.BusinessLayer.Abstract;
using ReporterDay.EntityLayer.Entities;
using ReporterDay.PresentationLayer.Models;

namespace ReporterDay.PresentationLayer.Controllers
{
    public class AuthorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService; private readonly SignInManager<AppUser> _signInManager;
        public AuthorController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> CreateArticle()


        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.id = user.Id;
            ViewBag.name = user.Name + " " + user.Surname;
            List<SelectListItem> values = (from x in _categoryService.TGetListAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.categories = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId = user.Id;
            article.CreatedDate = DateTime.Now;
            _articleService.TInsert(article);
            return RedirectToAction("BlogListByWriter", "Article");
        }

        public async Task<IActionResult> MyArticleList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAuthor(user.Id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("UserLogin", "Login");

            var model = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("UserLogin", "Login");

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                TempData["Success"] = "Şifre başarıyla değiştirildi.";
                return RedirectToAction("Profile");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> AboutMe()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("UserLogin", "Login");

            var model = new UserAboutViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl,
                Description = user.Description
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "User");

            var model = new ProfileUpdateViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Description = user.Description,
                ImageUrl = user.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(ProfileUpdateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "User");

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Description = model.Description;
            user.ImageUrl = model.ImageUrl; // sadece URL güncelleniyor

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Success"] = "Profil başarıyla güncellendi.";
                return RedirectToAction("EditProfile");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


    }
}