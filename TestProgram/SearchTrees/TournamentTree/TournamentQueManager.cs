using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SearchTrees.TournamentTree
{
	internal class TournamentQueManager
	{
		private int? MaxDepth = null;
		private int? CurrentDepth = 1;
		private Match _finalMatch;
		private Queue<Match> _queue = new Queue<Match>();

		public TournamentQueManager(Match finalMatch)
		{
			_finalMatch = finalMatch;
			//GenerateQue();
			AddMatchesBottomUp(_finalMatch);

			while (_queue.Count > 0)
			{
				Console.WriteLine(_queue.Dequeue().MatchCount);
			}
		}

		private void AddMatchesBottomUp(Match? match)
		{
			if (match == null) return;

			// Gå først ned i børn
			AddMatchesBottomUp(match.LeftMatch);
			AddMatchesBottomUp(match.RightMatch);

			// Tilføj denne kamp til køen når børnene er færdige
			_queue.Enqueue(match);
		}

		private void GenerateQue()
		{
			while (MaxDepth != 0)
			{
				FindMaxDepth();
				AddMatchToQue(_finalMatch);
				MaxDepth--;
			}
			_queue.Enqueue(_finalMatch);

			Console.WriteLine(_queue.Count);
		}

		private void AddMatchToQue(Match match)
		{
			if (match != null)
			{
				if (CurrentDepth == MaxDepth && !_queue.Contains(match))
				{ 
					_queue.Enqueue(match);
				}
				else
				{
					CurrentDepth++;
					AddMatchToQue(match.LeftMatch);
					AddMatchToQue(match.RightMatch);
				}
			}
		}

		private void FindMaxDepth()
		{
			Match tempMatch = _finalMatch;

			while (MaxDepth == null || CurrentDepth < MaxDepth)
			{
				if (tempMatch.LeftMatch != null)
				{
					tempMatch = tempMatch.LeftMatch;
				}

				CurrentDepth++;

				if (tempMatch.LeftMatch == null)
				{
					MaxDepth = CurrentDepth;
				}
			}
			CurrentDepth = 0;
		}

	}
}
