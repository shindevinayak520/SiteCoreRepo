﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;


namespace SitecoreDev.Feature.Media.ViewModels
{
    public class HeroSliderImageViewModel
    {

        public string MediaUrl { get; set; }
        public string AltText { get; set; }
        public bool IsActive { get; set; }

       
    }
}