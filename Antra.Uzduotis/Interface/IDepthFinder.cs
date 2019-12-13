using Antra.Uzduotis.Objects;
using System.Collections.Generic;

namespace Antra.Uzduotis.Interface
{
    public interface IDepthFinder
    {
        //Interface to call the controller
        int FindDepth(IEnumerator<Saka> rootNode = null, int depth = 0);
    }
}
