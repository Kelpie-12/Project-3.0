using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Project_3._0
{
    public class Program
    {
     
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(cont =>
            {
                Assembly assembly = typeof(Program).Assembly;
                cont.RegisterAssemblyTypes(assembly)
                                    .Where(t => t.Name.EndsWith("Services"))
                                    .AsImplementedInterfaces()
                                    .SingleInstance();
            });
            builder.Host.ConfigureContainer<ContainerBuilder>(cont =>
            {
                Assembly assembly = typeof(Program).Assembly;
                cont.RegisterAssemblyTypes(assembly)
                                    .Where(t => t.Name.EndsWith("Repository"))
                                    .AsImplementedInterfaces()
                                    .SingleInstance();
            });

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1800);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            
            builder.Services.AddHttpClient("Server", o =>
            {
                o.BaseAddress = new Uri(builder.Configuration.GetRequiredSection("PhotoRoute").GetSection("Server").Value.ToString());

            });

            builder.Services.AddHttpClient("Agent", o =>
            {
                o.BaseAddress = new Uri(builder.Configuration.GetRequiredSection("PhotoRoute").GetSection("Agent").Value.ToString());

            });
            builder.Services.AddHttpClient("Apartment", o =>
            {
                o.BaseAddress = new Uri((builder.Configuration.GetRequiredSection("PhotoRoute").GetSection("Apartment").Value).ToString());
            });
            // builder.WebHost.UseUrls("http://0.0.0.0:8080");

            var app = builder.Build();
            
            app.UseStaticFiles();

            app.MapControllers();
            app.UseSession();


            app.Run();
        }
    }
}
