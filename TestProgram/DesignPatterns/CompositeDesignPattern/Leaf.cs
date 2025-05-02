using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.DesignPatterns.CompositeDesignPattern
{
    internal class Leaf : Componant
    {
        private int _price;

        public Leaf(int price)
        {
            _price = price;
        }

        public override void Add(Componant inputComponant)
        {
            throw new NotImplementedException();
        }

        public override int GetSum()
        {
            return _price;
        }

        public override void Remove(Componant inputComponant)
        {
            throw new NotImplementedException();
        }
    }
}
