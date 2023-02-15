using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sitecore.Data.Items;

namespace SitecoreDev.Feature.Media.Repositories
{
    public interface IMediaRepository
    {
        Item GetItem(string contentGuid);
    }
}
