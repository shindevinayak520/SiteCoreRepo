using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreDev.Feature.Articles.ViewModels
{
    public interface IComment
    {
        string Name { get; }
        string Comment { get; }
        DateTime DatePosted { get; }
    }
}
