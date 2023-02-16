using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Services
{
    class SitecoreHelpers
    {
        public string GetItemTitle(string path)
        {
            Sitecore.Data.Database masterDb =
            Sitecore.Configuration.Factory.GetDatabase("master");
            Sitecore.Data.Items.Item item = masterDb.Items[path];
            return item["Title"];
        }
    }
}
