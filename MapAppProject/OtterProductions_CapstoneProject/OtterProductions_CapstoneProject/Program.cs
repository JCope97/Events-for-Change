using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Data;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OtterProductions_CapstoneProject.Utilities;
using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.DAL.Concrete;


namespace OtterProductions_CapstoneProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("AuthenticationConnection") ?? throw new InvalidOperationException("Connection string 'AuthenticationConnection' not found.");
        var mapConnectionString = builder.Configuration.GetConnectionString("MapAppConnection") ?? throw new InvalidOperationException("Connection string 'MapAppConnection' not found.");

        builder.Services.AddDbContext<AuthenticationDbContext>(options => options
            .UseSqlServer(connectionString));

        //builder.Services.AddDbContext<MapAppDbContext>(options => options
        //.UseLazyLoadingProxies()
        //.UseSqlServer(mapConnectionString)
        //);

        builder.Services.AddDbContext<MapAppDbContext>(options => options
        .UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("MapAppConnection")));

        builder.Services.AddScoped<DbContext, MapAppDbContext>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IBrowseEventRepository, BrowseEventRepository>();
        builder.Services.AddScoped<IEventUserConnectionRepository, EventUserConnectionRepository>();
        builder.Services.Configure<SendGridParams>(builder.Configuration.GetSection("SendGrid"));
        //builder.Services.Configure<BaseUrlConfiguration>(builder.Configuration.GetSection("BaseUrlConfiguration"));
        builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailSettings"));
        builder.Services.AddScoped<IEmailSender, EmailSender>();
        builder.Services
            .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthenticationDbContext>();

        builder.Services.Configure<IdentityOptions>(config =>
        {
            config.SignIn.RequireConfirmedAccount = true;
            config.User.RequireUniqueEmail = true;
            config.SignIn.RequireConfirmedPhoneNumber = false;
            config.SignIn.RequireConfirmedEmail = false;
           // config.SignIn.RequireConfirmedAccount = false;
        });

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

        var app = builder.Build();

        app.SeedData();

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
