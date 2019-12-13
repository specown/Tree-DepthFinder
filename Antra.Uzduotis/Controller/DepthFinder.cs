using System;
using System.Collections.Generic;
using Antra.Uzduotis.Interface;
using Antra.Uzduotis.Objects;

namespace Antra.Uzduotis.Controller
{
    public class DepthFinder : IDepthFinder
    {
        //Finds the maximum depth of tree
        public int FindDepth(IEnumerator<Saka> rootNode = null, int depth = 0)
        {
            //No node exists' or there is nothing else to explore
            if (rootNode == null || !rootNode.MoveNext())
            {
                //Return the current depth
                return depth;
            }

            //Find if a deeper node of the current node exists' and the maximum depth of the children nodes.
            using (var rootNodeInner = rootNode.Current?.Sakos?.GetEnumerator())
            {
                return Math.Max(FindDepth(rootNodeInner, depth + 1), FindDepth(rootNode, depth));
            }
        }
    }
}
