using BlazorTest.ServiceLifeTimeTest.ScopedServiceFolder;
using BlazorTest.ServiceLifeTimeTest.SingletongServiceFolder;
using BlazorTest.ServiceLifeTimeTest.TransientServiceFolder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp2
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddSingleton<ISingletonService, SingletonService>();
			builder.Services.AddScoped<IScopedService, ScopedService>();
			builder.Services.AddTransient<ITransientService, TransientService>();

			await builder.Build().RunAsync();
		}
	}
}
