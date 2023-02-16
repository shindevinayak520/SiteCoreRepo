using Glass.Mapper.Sc;
using SitecoreDev.Feature.Media.ViewModels;
using SitecoreDev.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreDev.Feature.Media.Services
{
    public class SitecoreMediaContentService
    {
        //private readonly SitecoreContext _sitecoreContext;

        private readonly IContentRepository _repository;
        

        public SitecoreMediaContentService(IContentRepository @object)
        {
            this._repository = @object;
        }

        public IHeroSlider GetHeroSliderContent(string contentGuid)
        {
            if (string.IsNullOrEmpty(contentGuid))
                return null;
            var heroSlider = _repository.GetContentItem<IHeroSlider>(contentGuid);
            heroSlider.Slides = _repository.GetChildren<IHeroSliderSlide>(contentGuid);
            return heroSlider;
        }
    }
}