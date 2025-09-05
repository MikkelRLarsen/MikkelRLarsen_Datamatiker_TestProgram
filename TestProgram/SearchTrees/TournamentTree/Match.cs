using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SearchTrees.TournamentTree
{
	public class Match
	{
		public Match? LeftMatch { get; set; } = null;
		public Match? RightMatch { get; set; } = null;
		public string? LeftPartisipant { get; set; }
		public string? RightPartisipant { get; set; }
		public Match? NextMatch { get; set; } = null;
		public int? MatchCount { get; set; }
	}
}
