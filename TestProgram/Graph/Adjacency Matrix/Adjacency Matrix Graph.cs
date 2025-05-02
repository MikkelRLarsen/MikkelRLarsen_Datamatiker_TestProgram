using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.Graph.Adjacency_Matrix
{
    internal class Adjacency_Matrix_Graph
    {
        public static NodePath[] Dijkstra(int[,] graph, int startPoint)
        {
            NodePath[] output = new NodePath[graph.GetLength(0)]; // Creates a NodePath foreach rows in Graph

            for (int i = 0; i < graph.GetLength(0); i++) 
            {
                // Sets the every nodepath.value as infinite, if the Nodepath == startPoint set value as 0
                NodePath node = new NodePath(i);
                if (i == startPoint)
                {
                    node.Value = 0;
                }
                output[i] = node;
            }

            for (int count = 0; count < graph.GetLength(1) -1; count++)
            {
                // Finds the next shortest value
                // The next shortest path is a Vector which have not been visited AND which value is lowest <=int.max
                int indexOfNextShortestValue = FindNextShortestValue(output);

                output[indexOfNextShortestValue].Visited = true;

                // Checks each possible Vector that could be connected to indexOfNextShortestValue
                // If VectorIndex have not been visisted AND its connected to indexOfNextShortestValue 
                // AND indexOfNextShortestValue.Value != int.MaxValue(infinite) AND the connected Vectors value is lower than 
                // the currentshortest path (indexOfNextShorttestValue.Value) + the edge between the current Vector and VectorIndex
                for (int vectorIndex = 0; vectorIndex < graph.GetLength(1); vectorIndex++)
                {
                    if (output[vectorIndex].Visited == false 
                        && graph[indexOfNextShortestValue, vectorIndex] != 0
                        && output[indexOfNextShortestValue].Value != int.MaxValue 
                        && output[indexOfNextShortestValue].Value + graph[indexOfNextShortestValue, vectorIndex] < output[vectorIndex].Value)
                    {
                        output[vectorIndex].Value = output[indexOfNextShortestValue].Value + graph[indexOfNextShortestValue, vectorIndex];
                        output[vectorIndex].PrevNode = indexOfNextShortestValue;
                    }
                }
            }
            return output;
        }

        private static int FindNextShortestValue(NodePath[] nodepath)
        {
            int min = int.MaxValue;
            int min_index = -1;

            for (int i = 0; i < nodepath.Length;i++)
            {
                if (nodepath[i].Visited == false && nodepath[i].Value <= min)
                {
                    min = nodepath[i].Value;
                    min_index = i;
                }
            }
            return min_index;
        }


        public class NodePath
        {
            public int Node { get; set; }
            public int Value { get; set; }
            public int? PrevNode { get; set; }
            public bool Visited {  get; set; }

            public NodePath(int node)
            {
                Node = node;
                Value = int.MaxValue;
                Visited = false;
                PrevNode = null;
            }
        }
    }
}
