using SitecoreDev.Foundation.Model;
using System.Collections.Generic;

namespace SitecoreDev.Feature.Media.ViewModels
{
    public interface IHeroSlider : ICmsEntity
    {
        IEnumerable<IHeroSliderSlide> Slides { get; set; }
        List<HeroSliderImageViewModel> HeroImages { get;}
        int ImageCount { get; }
        bool HasImages { get; }
    }
}
