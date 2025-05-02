using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.LinkedLister
{
    internal class LinkedListerMain
    {
        public static void LinkedLister()
        {
            //var linkList = new LinkedList<int>(2);
            //linkList.Prepend(3);
            //linkList.Prepend(5);
            //linkList.Append(1);
            //linkList.Append(9);

            //linkList.Replace(2, 10);
            //linkList.PrintAll();

            //linkList.IndSet(2, 10);
            //linkList.PrintAll();

            var linkList = new LinkedList<string>("123");
            linkList.Prepend("a");
            linkList.Prepend("b");
            linkList.Prepend("c");
            linkList.Append("d");
            linkList.AddUnderTop("top");
            linkList.PrintAll();

            Console.WriteLine();

            var linkList2 = LinkedList<String>.ReturnLinkedListFromInterval(1, 4, linkList);
            linkList2.PrintAll();   

            //linkList.Replace(0, "0");
            //linkList.PrintAll();

            //Console.WriteLine();

            //linkList.Append("prepend");
            //linkList.Prepend("Append");
            //linkList.PrintAll();
            

            //Console.WriteLine();

            //linkList.Slet(1);
            //linkList.PrintAll();

            //Console.WriteLine();

            //linkList.Reverse();
            //linkList.PrintAll();

        }
    }
}
