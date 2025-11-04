using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAssemblyTest.Models.TournamentTree
{
	public class Tournament
	{
		private Match? _finalMatch = null;

		public Tournament(IList<string> partisipants)
		{
			_finalMatch = CreateNewMatch(partisipants, null);
		}

		private Match CreateNewMatch(IList<string> partisipants, Match? nextMatch)
		{
			Match newMatch = new Match();
			newMatch.NextMatch = nextMatch;

			if (partisipants.Count == 2)
			{
				newMatch.LeftPartisipant = partisipants[0];
				newMatch.RightPartisipant= partisipants[1];
			}
			else if (partisipants.Count == 3)
			{
				int half = (int)Math.Ceiling(partisipants.Count / 2.0);
				newMatch.LeftMatch = CreateNewMatch(partisipants.Take(half).ToList(), newMatch);
				newMatch.RightPartisipant = partisipants[2];
			}
			else
			{
				int half = (int)Math.Ceiling(partisipants.Count / 2.0);
				newMatch.LeftMatch = CreateNewMatch(partisipants.Take(half).ToList(), newMatch);
				newMatch.RightMatch = CreateNewMatch(partisipants.Skip(half).ToList(), newMatch);
			}

			return newMatch;
		}

		public void InOrderTravel()
		{
			InOrderTravelHelpingMethod(_finalMatch);
		}

		private void InOrderTravelHelpingMethod(Match? match)
		{
			if (match != null)
			{

				InOrderTravelHelpingMethod(match.LeftMatch);

				Console.WriteLine($"{(match.LeftPartisipant == null ? "Not Decided Yet" : match.LeftPartisipant)} vs {match.RightPartisipant}");

				InOrderTravelHelpingMethod(match.RightMatch);
			}
		}

		public void PrintAllLeaves()
		{
			PrintAllLeavesHelper(_finalMatch);
		}

		private void PrintAllLeavesHelper(Match match)
		{
			if (match != null)
			{
				if (match.LeftMatch == null && match.RightMatch == null)
				{
					Console.WriteLine($"{(match.LeftPartisipant == null ? "Not Decided Yet" : match.LeftPartisipant)} vs {(match.RightPartisipant == null ? "Not Decided Yet" : match.RightPartisipant)}");
				}
				PrintAllLeavesHelper(match.LeftMatch);
				PrintAllLeavesHelper(match.RightMatch);
			}
		}

		public void PrintTree()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			PrintTreeHelper(_finalMatch, "", true);
		}

		private void PrintTreeHelper(Match? match, string indent, bool last)
		{
			if (match == null) return;

			// Lav node-label
			string label;
			if (match.LeftMatch == null && match.RightMatch == null)
			{
				// Blad med spillere
				label = $"{(match.LeftPartisipant ?? "??")} vs {(match.RightPartisipant ?? "??")}";
			}
			else
			{
				// Mellem-/finalekamp
				label = "Match";
			}

			// Tegn grene
			Console.Write(indent);
			Console.Write(last ? "└─→ " : "├─→ ");
			Console.WriteLine(label);

			// Nyt indryk til børn
			indent += last ? "    " : "│   ";

			var children = new List<Match?>();
			if (match.LeftMatch != null) children.Add(match.LeftMatch);
			if (match.RightMatch != null) children.Add(match.RightMatch);

			for (int i = 0; i < children.Count; i++)
			{
				PrintTreeHelper(children[i], indent, i == children.Count - 1);
			}
		}
	}
}
