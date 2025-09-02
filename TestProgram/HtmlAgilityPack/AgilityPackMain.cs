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
			Valdemarsro().GetAwaiter().GetResult();
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

		public static async Task Valdemarsro()
		{
			var url = "https://www.valdemarsro.dk/carbonara_opskrift/";
			var httpClient = new HttpClient();
			var html = await httpClient.GetStringAsync(url);

			var doc = new HtmlDocument();
			doc.LoadHtml(html);

			// Titel
			var titleNode = doc.DocumentNode.SelectSingleNode("//h1");
			string title = titleNode?.InnerText.Trim() ?? "Ingen titel fundet";

			// Ingredienser kategorier
			var ingredientList = doc.DocumentNode.SelectSingleNode("//ul[@class='ingredientlist content']");
			List<string> ingredients = new List<string>();
			List<string> accessories = new List<string>();
			List<string> serving = new List<string>();

			string currentCategory = "main";

			if (ingredientList != null)
			{
				foreach (var li in ingredientList.SelectNodes("./li"))
				{
					if (li.HasClass("ingredient-header"))
					{
						var headerText = li.InnerText.Trim().ToLower();

						if (headerText.Contains("tilbehør"))
							currentCategory = "accessory";
						else if (headerText.Contains("til servering"))
							currentCategory = "serving";
						else
							currentCategory = "main";

						continue;
					}

					var text = li.InnerText.Trim();
					if (string.IsNullOrWhiteSpace(text)) continue;

					switch (currentCategory)
					{
						case "accessory":
							accessories.Add(text);
							break;
						case "serving":
							serving.Add(text);
							break;
						default:
							ingredients.Add(text);
							break;
					}
				}
			}

			// Fremgangsmåde
			var instructionContainer = doc.DocumentNode.SelectSingleNode("//div[@itemprop='recipeInstructions']");
			List<string> steps = new List<string>();

			if (instructionContainer != null)
			{
				foreach (var p in instructionContainer.SelectNodes(".//p"))
				{
					var text = p.InnerText.Trim();
					if (!string.IsNullOrWhiteSpace(text))
					{
						steps.Add(text);
					}
				}
			}

			// Billede
			var imageNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'recipe-image')]//img[1]");
			string imageUrl = imageNode?.GetAttributeValue("src", "") ?? "Billede ikke fundet";

			// Udskrivning
			Console.WriteLine("Titel: " + title);

			Console.WriteLine("\nIngredienser:");
			foreach (var ing in ingredients)
			{
				Console.WriteLine("- " + ing);
			}

			Console.WriteLine("\nTilbehør:");
			foreach (var acc in accessories)
			{
				Console.WriteLine("- " + acc);
			}

			Console.WriteLine("\nTil servering:");
			foreach (var serv in serving)
			{
				Console.WriteLine("- " + serv);
			}

			Console.WriteLine("\nFremgangsmåde:");
			for (int i = 0; i < steps.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {steps[i]}");
			}

			Console.WriteLine("\nBillede-URL:\n" + imageUrl);
		}

	}
}
