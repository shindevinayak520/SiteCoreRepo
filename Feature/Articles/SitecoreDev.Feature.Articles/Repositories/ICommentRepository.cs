using System.Collections.Generic;
using SitecoreDev.Feature.Articles.ViewModels;

namespace SitecoreDev.Feature.Articles.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<IComment> GetComments(string blogId);
    }
}