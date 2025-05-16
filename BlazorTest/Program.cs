using BlazorTest.Components;
using BlazorTest.ServiceLifeTimeTest.ScopedServiceFolder;
using BlazorTest.ServiceLifeTimeTest.SingletongServiceFolder;
using BlazorTest.ServiceLifeTimeTest.TransientServiceFolder;
using Domain.Interfaces;
using Services;

namespace BlazorTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddSingleton<ICounterService, CounterService>();
            builder.Services.AddSingleton<ICreateNumber, NewCreateNumber>();

            builder.Services.AddSingleton<ISingletonService, SingletonService>();
            builder.Services.AddScoped<IScopedService, ScopedService>();
            builder.Services.AddTransient<ITransientService, TransientService>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
