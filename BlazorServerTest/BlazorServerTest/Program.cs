using BlazorServerTest.Client.Pages;
using BlazorServerTest.Client.Services;
using BlazorServerTest.Components;
using ShardLibrary.Repository;

namespace BlazorServerTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents()
				.AddInteractiveWebAssemblyComponents();

			builder.Services.AddControllers();

			builder.Services.AddDbContext<ShoppingDBContext>();

			builder.Services.AddSingleton(new HttpClient
			{
				BaseAddress = new Uri("https://localhost:7180/")
			});

			builder.Services.AddHttpClient<IShoppingItemRepository, ShoppingItemRepository>(client =>
			{
				client.BaseAddress = new Uri("https://localhost:7180/");
			});

			builder.Services.AddHttpClient<IShoppingService, ShoppingService>(client =>
			{
				client.BaseAddress = new Uri("https://localhost:7180/");
			});

			builder.Services.AddHttpClient<IBookService, BookService>(client =>
			{
				client.BaseAddress = new Uri("https://localhost:7180/");
			});

			builder.Services.AddHttpClient("LocalAPI", client =>
			{
				client.BaseAddress = new Uri("https://localhost:7180/");
			});


			var app = builder.Build();

			// Map controllers
			app.MapControllers();

			// Map Blazor endpoints
			app.MapBlazorHub();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode()
				.AddInteractiveWebAssemblyRenderMode()
				.AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

			app.Run();

		}
	}
}
