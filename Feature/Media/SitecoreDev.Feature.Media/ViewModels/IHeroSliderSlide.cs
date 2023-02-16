using SitecoreDev.Foundation.Model;
using Glass.Mapper.Sc.Fields;


namespace SitecoreDev.Feature.Media.ViewModels
{
    public interface IHeroSliderSlide : ICmsEntity
    {
        string MediaUrl { get;}
        string AltText { get;}
        bool IsActive { get;}
        Image Image { get;}
    }
}
