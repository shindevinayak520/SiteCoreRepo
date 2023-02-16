﻿using SitecoreDev.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreDev.Feature.Media.ViewModels
{
    public class HeroSliderViewModel : IHeroSlider
    {
        public List<HeroSliderImageViewModel> HeroImages { get; set; } = new List<HeroSliderImageViewModel>();
        public int ImageCount => HeroImages.Count;
        public bool HasImages => ImageCount > 0;
        public IEnumerable<IHeroSliderSlide> Slides { get; set; }
    }
}