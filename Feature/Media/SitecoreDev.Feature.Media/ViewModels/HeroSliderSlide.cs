using Glass.Mapper.Sc.Fields;
using SitecoreDev.Feature.Media.ViewModels;
using SitecoreDev.Foundation.Model;

namespace SitecoreDev.Feature.Media.Models
{
    public class HeroSliderSlide : CmsEntity, IHeroSliderSlide
    {
        public Image Image { get; set; }
        public string MediaUrl { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string AltText { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool IsActive { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}