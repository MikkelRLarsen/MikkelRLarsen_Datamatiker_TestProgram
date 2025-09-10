using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SearchTrees.TournamentTree
{
	public class TournamentTreeMain
	{
		public static void TournamentTreeMainMethod()
		{
			List<string> tournamentPartisipants = new List<string>();

			for (int i = 1; i <= 9; i++)
			{
				tournamentPartisipants.Add(i.ToString());
			}

			Tournament tournament = new Tournament(tournamentPartisipants);
			tournament.PrintTree();
			tournament.PrintAllLeaves();
		}
	}
}
