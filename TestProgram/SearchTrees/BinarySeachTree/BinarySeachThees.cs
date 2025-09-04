using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SearchTrees.BinarySeachTree
{
    internal class BinarySeachThees
    {
        private Node? _root;
        private int _sum;

        public BinarySeachThees()
        {
            _root = null;
            _sum = 0;
        }

        public void InsertNode(int insertValue)
        {
            if (_root == null)
            {
                _root = new Node(insertValue);
            }
            else
            {
                _root.Insert(insertValue);
            }
        }

        public void InOrderTravel()
        {
            InOrderTravelHelpingMethod(_root);
        }

        private void InOrderTravelHelpingMethod(Node node)
        {
            if (node != null)
            {

                InOrderTravelHelpingMethod(node.left);
                Console.Write($"{node.data} ");
                InOrderTravelHelpingMethod(node.right);
            }
        }
        public void PrintAllLeaves()
        {
            PrintAllLeavesHelper(_root);
        }

        private void PrintAllLeavesHelper(Node node)
        {
            if (node != null)
            {
                if (node.left == null && node.right == null)
                {
                    Console.Write($"{node.data} ");
                }
                PrintAllLeavesHelper(node.left);
                PrintAllLeavesHelper(node.right);
            }
        }

        public int FindSum()
        {
            _sum = 0;
            if (_root != null)
            {
                FindSumHelper(_root);
            }
            return _sum;
        }

        private void FindSumHelper(Node node)
        {
            if (node != null)
            {
                _sum += node.data;
                FindSumHelper(node.left);
                FindSumHelper(node.right);
            }
        }



        public Node FindBiggest()
        {
            return FindBiggestHelp(_root);
        }
        //private Node FindBiggestHelp(Node node)
        //{
        //    var biggestNode = node;
        //    if (node.right != null)
        //    {
        //        biggestNode = FindBiggestHelp(node.right);
        //    }
        //    return biggestNode;
        //}
        private Node FindBiggestHelp(Node node)
        {
            Node currentNode = node;
            while (currentNode.right != null)
            {
                currentNode = currentNode.right;
            }
            return currentNode;
        }
    }
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public int count;
        public Node(int v)
        {
            data = v;
            left = right = null;
            count = 1;
        }

        public void Insert(int insertValue)
        {
            if (insertValue < data)
            {
                if (left == null)
                {
                    left = new Node(insertValue);
                }
                else
                {
                    left.Insert(insertValue);
                }
            }
            else if (insertValue > data)
            {
                if (right == null)
                {
                    right = new Node(insertValue);
                }
                else
                {
                    right.Insert(insertValue);
                }
            }
            else if (insertValue == data)
            {
                count++;
            }
        }
    }
}
