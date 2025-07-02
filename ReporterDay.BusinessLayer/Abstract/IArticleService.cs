using ReporterDay.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporterDay.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
       

        List<Article> TGetArticlesWithAppUser();
        List<Article> TGetArticlesWithCategories();
        List<Article> TGetArticlesWithCategriesAndAppUsers();

        Article TGetArticlesWithAuthorAndCategoriesById(int id);

        List<Article> TGetArticlesByAuthor(string id);
        List<Article> TGetLast5Blog();

        
    }
}