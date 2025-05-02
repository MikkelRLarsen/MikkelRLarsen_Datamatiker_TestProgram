using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.DesignPatterns.CompositeDesignPattern
{
    internal abstract class Componant
    {
        public abstract void Add(Componant inputComponant);
        public abstract void Remove(Componant inputComponant);
        public abstract int GetSum();
    }
}
