using System;
using System.Collections.Generic;
using SitecoreDev.Feature.Articles.ViewModels;

namespace SitecoreDev.Feature.Articles.Services
{
    public interface ICommentService
    {
        IEnumerable<IComment> GetComments(string blogId);
    }
}
