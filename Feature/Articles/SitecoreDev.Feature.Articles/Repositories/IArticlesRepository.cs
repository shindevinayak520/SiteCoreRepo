
using Sitecore.Data.Items;
using SitecoreDev.Feature.Articles.ViewModels;

namespace SitecoreDev.Feature.Articles.Repositories
{
    public interface IArticlesRepository
    {
        IArticle GetArticleContent(string contentGuid);
    }
}
