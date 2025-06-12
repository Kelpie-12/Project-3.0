using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;

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
            var app = builder.Build();

            // app.MapGet("/", () => "Hello World!");
            // app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
