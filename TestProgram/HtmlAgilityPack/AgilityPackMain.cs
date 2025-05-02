using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace TestProgram.HtmlAgilityPack
{
	internal class AgilityPackMain
	{
		public static void newMain()
		{
			Setup();
		}

		static async Task<string> FindRecipeImageUrl(string pageUrl)
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					// Timeout på 30 sekunder
					client.Timeout = TimeSpan.FromSeconds(30);

					// Hent HTML
					string html = await client.GetStringAsync(pageUrl);

					// HtmlDocument bruges til at parse HTML
					HtmlDocument doc = new HtmlDocument();
					doc.LoadHtml(html);  // Load den hentede HTML

					// Finder <div class="image recipe-image">
					var divNode = doc.DocumentNode.SelectSingleNode("//div[@class='image recipe-image']");
					if (divNode != null)
					{
						// Finder første <img> inde i <div>
						var imgNode = divNode.SelectSingleNode(".//img");
						return imgNode?.GetAttributeValue("src", null);  // Returnerer src-attributten af img
					}

					// Hvis der ikke findes et billede
					return null;
				}
				catch (HttpRequestException httpEx)
				{
					Console.WriteLine($"Netværksfejl: {httpEx.Message}");
				}
				catch (TaskCanceledException taskEx)
				{
					Console.WriteLine($"Timeout-fejl: {taskEx.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Generel fejl: {ex.Message}");
				}

				return null;
			}
		}

		// Setup-metoden, som kalder FindRecipeImageUrl og håndterer resultaterne
		static async Task Setup()
		{
			string pageUrl = "https://www.valdemarsro.dk/carbonara_opskrift/";

			try
			{
				// Kald FindRecipeImageUrl og vent på resultatet
				string imageUrl = await FindRecipeImageUrl(pageUrl);
				if (!string.IsNullOrEmpty(imageUrl))
				{
					Console.WriteLine($"Billed-URL fundet: {imageUrl}");
					// Her kan du f.eks. downloade billedet, hvis det er nødvendigt
				}
				else
				{
					Console.WriteLine("Kunne ikke finde et billede i div med klassen 'image recipe-image'.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Fejl i Setup: {ex.Message}");
			}
		}

	}
}
