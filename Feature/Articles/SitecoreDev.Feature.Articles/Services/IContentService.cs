using Sitecore.Data.Items;
using SitecoreDev.Feature.Articles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreDev.Feature.Articles.Services
{
    public interface IContentService
    {
        IArticle GetArticleContent(string contentGuid);
    }
}
