using BlazorServerTest.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorServerTest.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			//builder.Services.AddHttpClient<IShoppingService, ShoppingService>(client =>
			//{
			//	client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
			//});

			await builder.Build().RunAsync();
		}
	}
}
