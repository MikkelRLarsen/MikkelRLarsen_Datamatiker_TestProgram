using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.BinarySeachTree
{
    internal class BinarySeachTreeMain
    {
        public static void BinarySearchTreeMain()
        {
            var test1 = new BinarySeachThees();
            test1.InsertNode(100);
            test1.InsertNode(20);
            test1.InsertNode(10);
            test1.InsertNode(30);
            test1.InsertNode(200);
            test1.InsertNode(150);
            test1.InsertNode(300);
            //test1.InOrderTravel();

            Console.WriteLine(test1.FindBiggest().data);
            //Console.WriteLine(test1.FindSum());
            //test1.PrintAllLeaves();
        }
    }
}
