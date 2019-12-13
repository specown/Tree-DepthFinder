using System.Collections.Generic;

namespace Antra.Uzduotis.Objects
{
    public class Saka
    {
        //To initialize a node without any children
        public Saka()
        {
        }

        //To initialize node with children
        public Saka(IList<Saka> sakos)
        {
            Sakos = sakos;
        }

        //Get / Set children of the parent
        public IList<Saka> Sakos { get; set; }
    }
}
