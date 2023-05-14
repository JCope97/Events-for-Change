using Microsoft.AspNetCore.Identity;

namespace OtterProductions_CapstoneProject.Areas.Identity.Data
{
    public static class WebApplicationExtensions
    {
        public static WebApplication SeedData(this WebApplication application)
        {
            if (application == null)
            {

            }

            using(var scope = application.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var userRole = new IdentityRole(RoleConstants.USER);
                var organizationRole = new IdentityRole(RoleConstants.ORGANIZATION);

                //if (!roleManager.Roles.Any())
                //{
                //    roleManager.CreateAsync(userRole).GetAwaiter().GetResult();
                //    roleManager.CreateAsync(organizationRole).GetAwaiter().GetResult();
                //}
            }


            return application;
        }
    }
}
