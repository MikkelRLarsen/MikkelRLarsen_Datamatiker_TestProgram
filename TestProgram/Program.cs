using TestProgram.DesignPatterns.CompositeDesignPattern;
using TestProgram.Graph.Adjacency_Matrix;
using TestProgram.LinkedLister;
using TestProgram.SearchTrees.BinarySeachTree;
using TestProgram.SearchTrees.TournamentTree;
using TestProgram.Threads;
using xUnitTest.CalculatorTest;

namespace TestProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
			//LinkedListerMain.LinkedLister();
			//BinarySeachTreeMain.BinarySearchTreeMain();
            //GraphMatrix_Main.GraphMatrixMain();
            //CompositeDesignPatternMain.newMain();

            //Console.WriteLine(GetConnectionString());

            //HtmlAgilityPack.AgilityPackMain.newMain();
            //Threads.ThreadMain.newMain();
            TournamentTreeMain.TournamentTreeMainMethod();
        }

		protected static string GetConnectionString()
		{
			string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string fullName = Path.Combine(desktopPath, "RecipeAppConnectionString");
			//return File.ReadAllText(fullName);
			//File.WriteAllText(fullName, "Data Source = mssql4.unoeuro.com, 1433; Database = foxtrox_dk_db_recipeapp; Integrated Security = false; User ID = foxtrox_dk; Password = A4EHeFypwfnx5h93crmB");
			return File.ReadAllText(fullName);
		}

		public static bool Solution(string str, string ending)
        {
            // TODO: complete
            if (str.Contains(ending) && (str[str.Length] == ending[ending.Length]))
            {
                return true;
            }

            return false;
        }

        public static void PengeTilbage(int Pris, int Betaling, ref int tyver, ref int tier, ref int femmer, ref int toer, ref int ener)
        {
            int tilbageBetaling = Pris - Betaling;

            tyver = (int)(tilbageBetaling / 20);
            tilbageBetaling -= tyver * 20;

            tier = (int)(tilbageBetaling / 10);
            tilbageBetaling -= tier * 10;

            femmer = (int)(tilbageBetaling / 5);
            tilbageBetaling -= femmer * 5;

            toer = (int)(tilbageBetaling / 2);
            tilbageBetaling -= toer * 2;

            ener = (int)(tilbageBetaling / 1);
            tilbageBetaling -= ener * 1;



            //int[] sedler = {20, 10, 5, 2, 1 };
            //
            //for (int i = 0; i < sedler.Length && 0 < tilbageBetaling; i++)
            //{
            //    int amountOfCoins = 0;
            //    if (sedler[i] == 20) tyver += (tilbageBetaling / sedler[i]);
            //    if (sedler[i] == 10) tier += (tilbageBetaling / sedler[i]);
            //    if (sedler[i] == 5) femmer += (tilbageBetaling / sedler[i]);
            //    if (sedler[i] == 2) toer += (tilbageBetaling / sedler[i]);
            //    if (sedler[i] == 1) ener += (tilbageBetaling / sedler[i]);

            //    tilbageBetaling -= tilbage * sedler[i];
            //}

        }

        public static int GetVowelCount(string str)
            {
                int vowelCount = 0;
                char[] vowels = { 'a','e','i', 'o', 'u', ' ' };

                foreach (char character in str)
                {
                    if (vowels.Contains(character)) vowelCount++;
                }

                return vowelCount;
            }

        public static long[] Digitize(long n)
        {
            char[] nString = Convert.ToInt32(n).ToString().ToCharArray();
            Array.Reverse(nString);

            var longs = new List<long>();

            foreach (char number in nString)
            {
                longs.Add((int)number);
            }

            return longs.ToArray();
        }

    }
}
