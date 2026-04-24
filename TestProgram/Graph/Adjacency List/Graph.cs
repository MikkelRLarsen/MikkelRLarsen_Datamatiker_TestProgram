using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestProgram.Heaps;
using TestProgram.RingBuffers;

namespace TestProgram.Graph.Adjacency_List
{
	public class Graph<T> where T : Entity
	{
		public Graph(GraphNode<T>[] graphNodes)
		{
			GraphNodes = graphNodes;
		}

		public GraphNode<T>[] GraphNodes { get; set; }
	}

	public class GraphNode<T> where T : Entity
	{
		public GraphNode(GraphEdge<T>[] edges, T entity)
		{
			Edges = edges;
			Entity = entity;
		}

		public GraphEdge<T>[] Edges { get; set; }
		public T Entity { get; set; }
	}
	public class GraphEdge<T> where T : Entity
	{
		public GraphEdge(int weight, Guid toEntityId)
		{
			Weight = weight;
			ToEntityId = toEntityId;
		}

		public int Weight { get; set; }
		public Guid ToEntityId {  get; set; }
	}
	public class Entity
	{
		public Guid Id { get; protected set; }
	}

	public static class Dijsktra
	{
		public static DijkstraResult<T> CalculateDijstra<T>(this Graph<T> graph, Guid startId, Guid needleId) where T : Entity
		{
			// Before
			MinHeap<Guid> heap = new MinHeap<Guid>();
			Dictionary<Guid, DijkstraNode<T>> dict = new Dictionary<Guid, DijkstraNode<T>>();

			foreach(GraphNode<T> node in graph.GraphNodes)
			{
				DijkstraNode<T> dNode = new(
					node: node,
					pathDistance: node.Entity.Id == startId ? 0 : int.MaxValue);

				heap.Enqueue(dNode.pathDistance, node.Entity.Id);
				dict.Add(node.Entity.Id, dNode);
			}

			// Edge case
			if (startId == needleId)
			{
				if (!dict.ContainsKey(startId))
					throw new InvalidOperationException("Start node not found in graph");

				return new DijkstraResult<T>(dict[startId].node);
			}

			// Do it
			while (heap.Any())
			{
				DijkstraNode<T>? dNode = GetNextNode<T>(heap, dict);
				if (dNode is null)
					break;

				dNode.visited = true;

				foreach(GraphEdge<T> edge in dNode.node.Edges)
				{
					DijkstraNode<T>? edgeNode = dict.GetValueOrDefault(edge.ToEntityId);
					if (edgeNode == null) throw new InvalidOperationException();

					int potentielWeight = edge.Weight + dNode.pathDistance;

					if(potentielWeight <= edgeNode.pathDistance)
					{
						edgeNode.SetPrevNode(dNode.node.Entity.Id, potentielWeight);
						heap.Enqueue(edgeNode.pathDistance, edgeNode.node.Entity.Id);
					}
				}
			}

			// After
			if (!dict[needleId].prevNodes.Any()) throw new InvalidOperationException();

			return DijkstraResult<T>.Recursion(
				dResultDict: new Dictionary<Guid, DijkstraResult<T>>(),
				dNodeDict: dict,
				nextNodeId: needleId,
				currentNodeId: needleId,
				isNeedle: true)
				[startId];
		}

		private static DijkstraNode<T>? GetNextNode<T>(MinHeap<Guid> heap, Dictionary<Guid, DijkstraNode<T>> dict) where T : Entity
		{
			while (heap.Any())
			{
				int pathD = heap.GetPeakQueueValue();

				if (pathD is int.MaxValue)
					return null;

				DijkstraNode<T>? dNode = dict.GetValueOrDefault(heap.Dequeue());
				if (dNode == null) throw new InvalidOperationException();

				if (dNode.visited is true) 
					continue;

				if (dNode.pathDistance == pathD) 
					return dNode;
			}
			return null;
		}
	}

	public class DijkstraNode<T> where T : Entity
	{
		public GraphNode<T> node { get; init; }
		public HashSet<Guid> prevNodes { get; private set; }
		public int pathDistance { get; private set; }
		public bool visited { get; set; }

		public DijkstraNode(GraphNode<T> node, int pathDistance)
		{
			this.node = node;
			prevNodes = new HashSet<Guid>();
			this.pathDistance = pathDistance;
			visited = false;
		}

		public void SetPrevNode(Guid nodeGuid, int weight)
		{
			if (weight < pathDistance)
			{
				prevNodes.Clear();
				prevNodes.Add(nodeGuid);
				pathDistance = weight;
			}
			else if (weight == pathDistance)
			{
				prevNodes.Add(nodeGuid);
			}
		}
	}

	public class DijkstraResult<T> where T : Entity
	{
		public DijkstraResult(GraphNode<T> entity)
		{
			Entity = entity;
		}

		public HashSet<DijkstraResult<T>> NextPotentielTermnials { get; private set; } = new HashSet<DijkstraResult<T>>();
		public GraphNode<T> Entity { get; private set; }

		public static Dictionary<Guid, DijkstraResult<T>> Recursion<T>(
			Dictionary<Guid, DijkstraResult<T>> dResultDict, 
			Dictionary<Guid, DijkstraNode<T>> dNodeDict, 
			Guid nextNodeId,
			Guid currentNodeId,
			bool isNeedle = false) 
			where T : Entity
		{
			// Pre
			DijkstraNode<T> dNode = dNodeDict[currentNodeId];

			if (dResultDict.ContainsKey(currentNodeId) is false)
				dResultDict.Add(currentNodeId, new DijkstraResult<T>(dNode.node));

			// Recurse
			if (dNode.prevNodes.Any())
			{
				foreach (Guid nodeId in dNode.prevNodes)
				{
					Recursion(dResultDict, dNodeDict, currentNodeId, nodeId);
				}
			}

			// Post
			if (isNeedle is false)
			{
				DijkstraResult<T> dResult = dResultDict[currentNodeId];
				dResult.NextPotentielTermnials.Add(dResultDict[nextNodeId]);
			}

			return dResultDict;
		}
	}
}
