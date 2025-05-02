using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestProgram.LinkedLister
{
    internal class LinkedList<T>
    {
        private Link FirstLink;
        private Link LastLink;

        public LinkedList(T linkData)
        {
            FirstLink = new Link(linkData, null);
            LastLink = FirstLink;
        }

        public void Prepend(T newLinkData)
        {
            Link node = new Link(newLinkData, FirstLink);
            FirstLink = node;
        }

        public void Append(T newLinkData)
        {
            Link node = new Link(newLinkData, null);
            LastLink.Next = node;

            LastLink = node;
        }

        public void PrintAll()
        {
            Link? tmp = FirstLink;
            while (tmp != null)
            {
                Console.WriteLine("tmp.data =" + tmp.Data);
                tmp = tmp.Next;
            }
        }

        public void PrintUligeIndex()
        {
            Link? tmp = FirstLink;
            int counter = 0;

            while (tmp != null)
            {
                if (counter % 2 == 1)
                {
                    Console.WriteLine("tmp.data =" + tmp.Data);
                }
                tmp = tmp.Next;
                counter++;
            }
        }

        //public void PrintUligeData()
        //{
        //    Link? tmp = CurrentLink;

        //    while (tmp != null)
        //    {
        //        if (tmp.data % 2 == 1)
        //        {
        //            Console.WriteLine("tmp.data =" + tmp.data);
        //        }
        //        tmp = tmp.next;
        //    }
        //}

        public void Replace(int index, T newLinkData)
        {
            //tmp.data er placeholder værider. Slettets senere
            Link? tmp = FirstLink;
            var newLinkedList = new LinkedList<T>(tmp.Data);
            int indexCounter = 0;

            while (tmp != null)
            {
                if (indexCounter != index)
                {
                    newLinkedList.Append(tmp.Data);
                }
                else
                {
                    newLinkedList.Append(newLinkData);
                }
                indexCounter++;
                tmp = tmp.Next;
            }
            //FirstLink.Next er for at "Slette" tmp.Data fra tidligere
            FirstLink = newLinkedList.FirstLink.Next;
            LastLink = newLinkedList.LastLink;
        }

        public void Slet(int index)
        {
            Link? tmp = FirstLink;
            var newLinkedList = new LinkedList<T>(tmp.Data); 
            int counter = 0;

            while (tmp != null)
            {
                if (counter != index)
                {
                    newLinkedList.Append(tmp.Data);
                }
                counter++;
                tmp = tmp.Next;
            }
            //FirstLink.Next er for at "Slette" tmp.Data fra tidligere
            FirstLink = newLinkedList.FirstLink.Next;
            LastLink = newLinkedList.LastLink;
        }

        public void IndSet(int index, T newLinkData)
        {
            //tmp.data er placeholder værider. Slettets senere
            Link? tmp = FirstLink;
            var newLinkedList = new LinkedList<T>(tmp.Data);
            int counter = 0;

            while (tmp != null)
            {
                newLinkedList.Append(tmp.Data);

                if (counter == index)
                {
                    newLinkedList.Append(newLinkData);
                }
                counter++;

                tmp = tmp.Next;
            }
            //FirstLink.Next er for at "Slette" tmp.Data fra tidligere
            FirstLink = newLinkedList.FirstLink.Next;
            LastLink = newLinkedList.LastLink;
        }

        public void Reverse()
        {
            Link? tmp = FirstLink;
            var newLinkedList = new LinkedList<T>(tmp.Data);

            while (tmp != null)
            {
                if (tmp != FirstLink)
                {
                    newLinkedList.Prepend(tmp.Data);                 
                }

                tmp = tmp.Next;
            }
            FirstLink = newLinkedList.FirstLink;
        }

        public void AddUnderTop(T newLinkData)
        {
            var newLink = new Link(newLinkData, FirstLink.Next);
            FirstLink.Next = newLink;
        }

        public Link ReturnFirst()
        {
            return FirstLink;
        }

        public void RemoveFirst()
        {
            FirstLink = FirstLink.Next;
        }

        public Link ReturnFirstThenDelete()
        {
            var tmp = new Link(FirstLink.Data, FirstLink.Next);
            RemoveFirst();
            return tmp;
        }

        public static LinkedList<T> ReturnLinkedListFromInterval(int minimumIndex, int maxIndex, LinkedList<T> currentList)
        {
            Link? tmp = currentList.FirstLink;
            var newLinkedList = new LinkedList<T>(tmp.Data);
            int counter = 0;

            while (tmp != null)
            {
                if (counter >= minimumIndex && counter <= maxIndex)
                {
                    newLinkedList.Append(tmp.Data);
                }
                counter++;

                tmp = tmp.Next;
            }

            newLinkedList.RemoveFirst();
            return newLinkedList;
        }

        public static LinkedList<T> ConCat(LinkedList<T> list1,  LinkedList<T> list2)
        {
            var newLinkedList = new LinkedList<T>(list1.FirstLink.Data);
            newLinkedList.LastLink = list1.LastLink;
            newLinkedList.LastLink.Next = list2.FirstLink;

            return newLinkedList;
        }

        //public int BeregnSum()
        //{
        //    Link? temp = CurrentLink;

        //    if (temp == null)
        //    {
        //        return 0;
        //    }

        //    int sum = 0;
        //    while (temp != null)
        //    {
        //        sum += (int)temp.data;
        //        temp = temp.Next;
        //    }

        //    return sum;
        //}

        internal class Link
        {
            public T Data;
            public Link? Next;

            public Link(T data, Link? next)
            {
                Data = data;

                Next = next != null ? next : null;
            }
        }
    }
}
