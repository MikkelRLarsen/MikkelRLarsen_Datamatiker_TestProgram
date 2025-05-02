using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.DesignPatterns.CompositeDesignPattern
{
    internal class CompositeDesignPatternMain
    {
        public static void newMain()
        {
            // Create a tree structure
            Composite root = new Composite();
            root.Add(new Leaf(20));
            root.Add(new Leaf(10));


            Composite comp = new Composite();
            comp.Add(new Leaf(5));
            comp.Add(new Leaf(3));

            root.Add(comp);
            root.Add(new Leaf(2));

            // Add and remove a leaf
            //Leaf leaf = new Leaf(3);
            //root.Add(leaf);
            //root.Remove(leaf);

            int sum = root.GetSum();
            Console.WriteLine(sum);
            // Wait for user
            Console.ReadKey();
        }

    }
}
