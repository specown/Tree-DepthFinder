using Antra.Uzduotis.Controller;
using Antra.Uzduotis.Interface;
using Antra.Uzduotis.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Antra.Uzduotis
{
    class Program
    {
        private static IDepthFinder _depthFinder;

        static void Main(string[] args)
        {
            //Initialize the interface
            _depthFinder = new DepthFinder();

            //A function to initialize a tree that has four levels and is five node deep
            Saka rootNode = InitializeTree();

            int maximumDepth; 

            //Using iteration call the controller and pass the root node
            using (var rootNodeEnum = new List<Saka> { rootNode }.GetEnumerator())
            {
                maximumDepth = _depthFinder.FindDepth(rootNodeEnum);
            }

            Console.WriteLine("Maximum depth of the tree is " + maximumDepth);

            Console.ReadKey();
        }

        public static Saka InitializeTree()
        {
            //Level 3
            Saka node3_1 = new Saka();
            //Level 2
            Saka node2_2 = new Saka();
            Saka node2_1 = new Saka(new List<Saka> { node3_1 });
            //Level 1
            Saka node1_2 = new Saka();
            Saka node1_1 = new Saka(new List<Saka> { node2_1 });
            Saka node1_3 = new Saka(new List<Saka> { node2_2 });
            Saka node1_4 = new Saka();
            //Level 0
            Saka node0_2 = new Saka(new List<Saka> { node1_1, node1_3, node1_4 });
            Saka node0_1 = new Saka(new List<Saka> { node1_2 });
            //Root node
            Saka rootNode = new Saka(new List<Saka> { node0_1, node0_2 });

            return rootNode;
        }
    }
}
