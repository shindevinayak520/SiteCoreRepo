using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreDev.Feature.Articles.ViewModels;
using SitecoreDev.Feature.Articles.Repositories;
namespace SitecoreDev.Feature.Articles.Services
{
    public class BlogCommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        public BlogCommentService()
        {
            _repository = new FakeBlogCommentRepository();
        }
        public IEnumerable<IComment> GetComments(string blogId)
        {
            return _repository.GetComments(blogId).OrderBy(c => c.DatePosted);
        }
    }
}