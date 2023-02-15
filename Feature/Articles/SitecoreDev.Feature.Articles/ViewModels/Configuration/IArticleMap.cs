using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Maps;
using SitecoreDev.Feature.Articles.ViewModels;

namespace SitecoreDev.Feature.Articles.Models.Configuration
{
    public class IArticleMap : SitecoreGlassMap<IArticle>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.Id(f => f.Id);
                config.Field(f => f.Title).FieldName("Title");
                config.Field(f => f.Body).FieldName("Body");
            });
        }
    }
}