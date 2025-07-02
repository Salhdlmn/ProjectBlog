using Microsoft.AspNetCore.Mvc;
using ReporterDay.BusinessLayer.Abstract;

namespace ReporterDay.PresentationLayer.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailTagListComponentPartial:ViewComponent
    {
        private readonly ITagService _tagservice;

        public _ArticleDetailTagListComponentPartial(ITagService tagservice)
        {
            _tagservice = tagservice;
        }

        public IViewComponentResult Invoke()
        {
            var values = _tagservice.TGetListAll();
            return View(values);    

        }
    }
}
