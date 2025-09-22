using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

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
            builder.WebHost.UseUrls("http://0.0.0.0:8080");

            var app = builder.Build();
            // app.MapGet("/", () => "Hello World!");
            // app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            app.UseStaticFiles();
    
            app.MapControllers();
            app.UseSession();


            app.Run();
        }
    }
}
