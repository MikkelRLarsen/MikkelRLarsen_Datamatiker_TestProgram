using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProgram.Graph.Adjacency_List;

namespace xUnitTest.Algoritmer
{
	public class DijkstraTests
	{
		private class TestEntity : Entity
		{
			public TestEntity(Guid id)
			{
				Id = id;
			}
		}

		private Graph<TestEntity> CreateGraph(
			(Guid from, Guid to, int weight)[] edges,
			Guid[] nodes)
		{
			var entities = nodes.Select(id => new TestEntity(id)).ToList();

			var graphNodes = entities.Select(e =>
			{
				var nodeEdges = edges
					.Where(edge => edge.from == e.Id)
					.Select(edge => new GraphEdge<TestEntity>(edge.weight, edge.to))
					.ToArray();

				return new GraphNode<TestEntity>(nodeEdges, e);
			}).ToArray();

			return new Graph<TestEntity>(graphNodes);
		}

		private List<List<Guid>> TraversePaths(DijkstraResult<TestEntity> root, Guid target)
		{
			var result = new List<List<Guid>>();

			void DFS(DijkstraResult<TestEntity> node, List<Guid> path)
			{
				path.Add(node.Entity.Entity.Id);

				if (node.Entity.Entity.Id == target)
				{
					result.Add(new List<Guid>(path));
				}

				foreach (var next in node.NextPotentielTermnials)
				{
					DFS(next, path);
				}

				path.RemoveAt(path.Count - 1);
			}

			DFS(root, new List<Guid>());
			return result;
		}

		private List<List<Guid>> Traverse(DijkstraResult<TestEntity> root, Guid target)
		{
			var result = new List<List<Guid>>();

			void DFS(DijkstraResult<TestEntity> node, List<Guid> path)
			{
				path.Add(node.Entity.Entity.Id);

				if (node.Entity.Entity.Id == target)
					result.Add(new List<Guid>(path));

				foreach (var next in node.NextPotentielTermnials)
					DFS(next, path);

				path.RemoveAt(path.Count - 1);
			}

			DFS(root, new List<Guid>());
			return result;
		}

		[Fact]
		public void Should_ReturnStartNode_AsRoot()
		{
			var a = Guid.NewGuid();

			var graph = CreateGraph(Array.Empty<(Guid, Guid, int)>(), new[] { a });

			var result = graph.CalculateDijstra(a, a);

			Assert.Equal(a, result.Entity.Entity.Id);
		}

		[Fact]
		public void Should_Throw_When_NoPathExists()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();

			var graph = CreateGraph(
				Array.Empty<(Guid, Guid, int)>(),
				new[] { a, b });

			Assert.Throws<InvalidOperationException>(() =>
				graph.CalculateDijstra(a, b));
		}

		[Fact]
		public void Should_Handle_Cycles()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();
			var c = Guid.NewGuid();

			var graph = CreateGraph(
				new[]
				{
				(a, b, 1),
				(b, c, 1),
				(c, a, 1) // cycle
				},
				new[] { a, b, c });

			var result = graph.CalculateDijstra(a, c);
			var paths = TraversePaths(result, c);

			Assert.Single(paths);
			Assert.Equal(new[] { a, b, c }, paths[0]);
		}

		[Fact]
		public void SingleNodeGraph_StartEqualsNeedle()
		{
			var a = Guid.NewGuid();
			var graph = CreateGraph(Array.Empty<(Guid, Guid, int)>(), new[] { a });

			var result = graph.CalculateDijstra(a, a);

			Assert.Empty(result.NextPotentielTermnials);
		}

		[Fact]
		public void TwoNodes_NoEdge_ShouldThrow()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();

			var graph = CreateGraph(Array.Empty<(Guid, Guid, int)>(), new[] { a, b });

			Assert.Throws<InvalidOperationException>(() =>
				graph.CalculateDijstra(a, b));
		}


		[Fact]
		public void Graph_WithCycles_ShouldNotLoop()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();
			var c = Guid.NewGuid();
			var d = Guid.NewGuid();

			var graph = CreateGraph(
				new[]
				{
				(a, b, 1),
				(b, c, 1),
				(c, a, 1), // cycle
                (c, d, 1)
				},
				new[] { a, b, c, d });

			var result = graph.CalculateDijstra(a, d);
			var paths = Traverse(result, d);

			Assert.Single(paths);
			Assert.Equal(new[] { a, b, c, d }, paths[0]);
		}

		[Fact]
		public void Graph_WithManyEqualPaths()
		{
			var a = Guid.NewGuid();
			var nodes = Enumerable.Range(0, 5).Select(_ => Guid.NewGuid()).ToArray();
			var end = Guid.NewGuid();

			var edges = new List<(Guid, Guid, int)>();

			foreach (var n in nodes)
			{
				edges.Add((a, n, 1));
				edges.Add((n, end, 1));
			}

			var graph = CreateGraph(edges.ToArray(), nodes.Append(a).Append(end).ToArray());

			var result = graph.CalculateDijstra(a, end);
			var paths = Traverse(result, end);

			Assert.Equal(nodes.Length, paths.Count);
		}

		[Fact]
		public void LargeLinearGraph()
		{
			var nodes = Enumerable.Range(0, 100)
				.Select(_ => Guid.NewGuid())
				.ToArray();

			var edges = new List<(Guid, Guid, int)>();

			for (int i = 0; i < nodes.Length - 1; i++)
			{
				edges.Add((nodes[i], nodes[i + 1], 1));
			}

			var graph = CreateGraph(edges.ToArray(), nodes);

			var result = graph.CalculateDijstra(nodes[0], nodes[^1]);
			var paths = Traverse(result, nodes[^1]);

			Assert.Single(paths);
			Assert.Equal(100, paths[0].Count);
		}

		[Fact]
		public void Graph_WithZeroWeights()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();
			var c = Guid.NewGuid();

			var graph = CreateGraph(
				new[]
				{
				(a, b, 0),
				(b, c, 0)
				},
				new[] { a, b, c });

			var result = graph.CalculateDijstra(a, c);
			var paths = Traverse(result, c);

			Assert.Single(paths);
		}

		[Fact]
		public void LargeGraph_WithHeavyInterwovenStructure_ShouldBuildCorrectShortestPathDAG()
		{
			var nodes = Enumerable.Range(0, 20)
				.Select(_ => Guid.NewGuid())
				.ToArray();

			var a = nodes[0];
			var i = nodes[8];
			var j = nodes[9];
			var k = nodes[10];
			var l = nodes[11];
			var m = nodes[12];
			var n = nodes[13];
			var o = nodes[14];
			var p = nodes[15];
			var q = nodes[16];
			var r = nodes[17];
			var s = nodes[18];
			var t = nodes[19];

			var graph = CreateGraph(
				new[]
				{
            // Layer 1 (start fan-out)
            (a, nodes[1], 1),
			(a, nodes[2], 1),
			(a, nodes[3], 2),

            // Layer 2 (interweaving core)
            (nodes[1], i, 2),
			(nodes[2], j, 2),
			(nodes[3], j, 1),
			(nodes[2], k, 3),
			(nodes[1], k, 4),

            // Dense mesh middle
            (i, l, 1),
			(j, l, 1),
			(k, l, 1),

			(l, m, 1),
			(l, n, 2),
			(m, n, 1),

            // Cross weaving (important complexity)
            (n, o, 1),
			(m, p, 2),
			(o, p, 1),
			(n, q, 2),
			(p, q, 1),

            // Branch chaos (non-shortest noise paths)
            (q, r, 5),
			(k, r, 10),
			(j, r, 9),

            // Final convergence zone (multiple equal shortest routes)
            (r, s, 2),
			(p, s, 2),
			(o, s, 3),

            // Needle layer
            (s, t, 1),
			(q, t, 4)
				},
				nodes);

			var result = graph.CalculateDijstra(a, t);
			var paths = Traverse(result, t);

			Assert.True(paths.Count >= 2);

			Assert.All(paths, p =>
			{
				Assert.Equal(a, p.First());
				Assert.Equal(t, p.Last());
			});

			// Ensure interwoven structure exists
			var sharedNodes = paths
				.SelectMany(x => x)
				.GroupBy(x => x)
				.Any(g => g.Count() > 1);

			Assert.True(sharedNodes);

			// Ensure noise nodes are not necessarily included
			Assert.Contains(paths, p => p.Contains(s));
		}

		[Fact]
		public void Should_Throw_When_StartNode_NotInGraph()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();

			var graph = CreateGraph(
				Array.Empty<(Guid, Guid, int)>(),
				new[] { b });

			Assert.Throws<InvalidOperationException>(() =>
				graph.CalculateDijstra(a, b));
		}

		[Fact]
		public void Should_Throw_When_TargetNode_NotInGraph()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();

			var graph = CreateGraph(
				Array.Empty<(Guid, Guid, int)>(),
				new[] { a });

			Assert.Throws<KeyNotFoundException>(() =>
				graph.CalculateDijstra(a, b));
		}

		[Fact]
		public void Should_Handle_Complex_EqualCost_DiamondPaths()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();
			var c = Guid.NewGuid();
			var d = Guid.NewGuid();

			var graph = CreateGraph(
				new[]
				{
			(a, b, 1),
			(a, c, 1),
			(b, d, 1),
			(c, d, 1)
				},
				new[] { a, b, c, d });

			var result = graph.CalculateDijstra(a, d);
			var paths = Traverse(result, d);

			Assert.Equal(2, paths.Count);
		}

		[Fact]
		public void Should_Throw_When_EdgePointsToMissingNode()
		{
			var a = Guid.NewGuid();
			var b = Guid.NewGuid();
			var fake = Guid.NewGuid();

			var graph = CreateGraph(
				new[]
				{
			(a, fake, 1)
				},
				new[] { a, b });

			Assert.Throws<InvalidOperationException>(() =>
				graph.CalculateDijstra(a, b));
		}

		[Fact]
		public void Should_Handle_SelfLoop()
		{
			var a = Guid.NewGuid();

			var graph = CreateGraph(
				new[]
				{
			(a, a, 1)
				},
				new[] { a });

			var result = graph.CalculateDijstra(a, a);

			Assert.Equal(a, result.Entity.Entity.Id);
		}
	}
}
