﻿using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;

namespace ReporterDay.PresentationLayer.ViewComponents
{
    public class _ArticleListDefaultComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleListDefaultComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(string page)
        {
            int currentPage = 6;
            int.TryParse(page, out currentPage);
            int pageSize = 6;
            var allArticles = _articleService.TGetArticlesWithCategriesAndAppUsers();
            var paginatedArticles=allArticles.Skip((currentPage-1)*pageSize).Take(pageSize).ToList();
            ViewBag.CurrentPage=currentPage;
            ViewBag.TotalPages=(int)Math.Ceiling((double)allArticles.Count/pageSize);
            return View(paginatedArticles);
        }
   
    }
}
