using System.Collections.Generic;
using SitecoreDev.Feature.Media.ViewModels;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Media.Models
{
    public class HeroSlider : CmsEntity, IHeroSlider
    {
        public IEnumerable<IHeroSliderSlide> Slides { get; set; }

        public List<HeroSliderImageViewModel> HeroImages => throw new System.NotImplementedException();

        public int ImageCount => throw new System.NotImplementedException();

        public bool HasImages => throw new System.NotImplementedException();
    }
}