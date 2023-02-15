
using System;
using SitecoreDev.Foundation.Model;
namespace SitecoreDev.Feature.Articles.ViewModels
{
    public interface IArticle : ICmsEntity
    {
        Guid Id { get; }
        string Title { get; }
        string Body { get; }
    }
    


}
