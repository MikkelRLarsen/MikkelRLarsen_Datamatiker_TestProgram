using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.DesignPatterns.CompositeDesignPattern
{
    internal class Composite : Componant
    {
        private List<Componant> _composites;
        private int _sum;

        public Composite()
        {
            _composites = new List<Componant> ();
        }

        public override void Add(Componant inputComponant)
        {
            _composites.Add(inputComponant);
        }

        public override void Remove(Componant inputComponant)
        {
            _composites.Remove(inputComponant);
        }

        public override int GetSum()
        {
            _sum = 0;
            foreach (Componant componant in _composites)
            {
                _sum += componant.GetSum();
            }
            return _sum;
        }

    }
}
