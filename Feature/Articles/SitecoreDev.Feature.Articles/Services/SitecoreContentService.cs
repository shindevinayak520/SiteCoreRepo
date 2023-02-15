using Sitecore.Data.Items;
using SitecoreDev.Feature.Articles.Repositories;
using SitecoreDev.Feature.Articles.ViewModels;
using SitecoreDev.Foundation.Repository.Content;

namespace SitecoreDev.Feature.Articles.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        public SitecoreContentService()
        {
            _repository = new SitecoreContentRepository();
        }
        public IArticle GetArticleContent(string contentGuid)
        {
            return _repository.GetContentItem<IArticle>(contentGuid);
        }
    }
}
