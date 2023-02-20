//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using OtterProductions_CapstoneProject.Data;
//using OtterProductions_CapstoneProject.Utilities;

//namespace OtterProductions_CapstoneProject
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var host = CreateHostBuilder(args).Build();

//            // After Build has been called, all services have been registered (by running Startup)
//            // By using a scope for the services to be requested below, we limit their lifetime to this set of calls.
//            // See: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0#call-services-from-main
//            using (var scope = host.Services.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                try
//                {
//                    // Get the IConfiguration service that allows us to query user-secrets and 
//                    // the configuration on Azure
//                    var config = host.Services.GetRequiredService<IConfiguration>();
//                    // Set password with the Secret Manager tool, or store in Azure app configuration
//                    // dotnet user-secrets set SeedUserPW <pw>

//                    var testUserPw = config["SeedUserPW"];
//                    var adminPw = config["SeedAdminPW"];

//                    SeedUsers.Initialize(services, SeedData.UserSeedData, testUserPw).Wait();
//                    SeedUsers.InitializeAdmin(services, "admin@example.com", "admin", adminPw, "The", "Admin").Wait();
//                }
//                catch (Exception ex)
//                {
//                    var logger = services.GetRequiredService<ILogger<Program>>();
//                    logger.LogError(ex, "An error occurred seeding the DB.");
//                }
//            }
//            // Go ahead and run the app, everything should be ready
//            host.Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}



using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Data;

namespace OtterProductions_CapstoneProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("AuthenticationConnection") ?? throw new InvalidOperationException("Connection string 'AuthenticationConnection' not found.");

        builder.Services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDbContext<MapAppDbContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("MapAppConnection")
           ));
        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthenticationDbContext>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();    
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}
