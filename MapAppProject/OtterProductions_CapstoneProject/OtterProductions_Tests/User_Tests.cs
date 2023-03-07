using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OtterProductions_CapstoneProject.Controllers;
using OtterProductions_CapstoneProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;
//using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace OtterProductions_Tests
{
   // [TestClass]
    public class User_Tests
    {
       
         private    MapAppUser MakeValidUser()
        {
            MapAppUser mapAppUser = new MapAppUser
            {
                AspnetIdentityId = "aa23cce0-d16a-45f3-8f7b-cd914bcd6624",
                Id = 1,
            };
            return mapAppUser;
        }



        private UserManager<ApplicationUser> _userManager;
        
        private IConfigurationRoot _configuration;

        
        private DbContextOptions<MapAppDbContext> _options;


        
        public User_Tests()
        {
           
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _options = new DbContextOptionsBuilder<MapAppDbContext>()
                .UseSqlServer(_configuration.GetConnectionString("MapAppConnection"))
                .Options;
        }

        //private MapAppUser ValidTestingItems()
        //{
        //    MapAppUser user = new MapAppUser();
        //    {
        //        user.Id = 1;
        //        user.AspnetIdentityId = "1234";
        //        //user.FirstName = "John";
        //        //user.LastName = "Doe";

        //    };

        //    return user;


        //[Test]
        //public void UserWithRequiredFields_OnCreate_ShouldBeCreate()
        //{
        //    //Arrange 
        //    // Prepare the user object...
        //    var connectionString = "MapAppConnection";

        //    var options = new DbContextOptionsBuilder<MapAppDbContext>().UseSqlServer(connectionString).Options;

        //    var _context = new MapAppDbContext(options);


        //    MapAppUser user = new MapAppUser();
        //    user.Id = 1;
        //    user.AspnetIdentityId = "54e45004-34be-4131-832a-0fe671c169b0";


        //    //Act
        //    var result = _context.MapAppUsers.Add(user);
        //    var id = _context.SaveChanges();

        //    //Assert
        //    Assert.AreEqual(id, user.Id);
        //}


        //private UserManager<IdentityUser> _userManager;

        [SetUp]
        public void Setup()
        {
            // Set up a new in-memory database context
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<AuthenticationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            var dbContext = new AuthenticationDbContext(options);

            // Initialize a new user store
            var userStore = new UserStore<ApplicationUser>(dbContext);

            // Initialize a new user manager with the user store and any necessary options
            _userManager = new UserManager<ApplicationUser>(userStore, null, new PasswordHasher<ApplicationUser>(), null, null, null, null, null, null);
        }

        [Test]
        public void TestUserManager()
        {
            try
            {
                var user = new ApplicationUser
                {
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "346366363663",
                    UserName = "Johndoe@gmail.com",
                    Email = "Johndoe@gmail.com"

                };
                var password = "Test@123!";
                var result = _userManager.CreateAsync(user, password).Result;
                Assert.IsTrue(result.Succeeded);

                // Check that the user was added to the user store
                var foundUser = _userManager.FindByNameAsync("Johndoe@gmail.com").Result;
                Assert.IsNotNull(foundUser);
                Assert.AreEqual(user.Id, foundUser.Id);

                // Add the user's email address
                foundUser.Email = "Johndoe@gmail.com";
                result = _userManager.UpdateAsync(foundUser).Result;
                Assert.IsTrue(result.Succeeded);

                // Check that the user's email was added in the user store
                foundUser = _userManager.FindByIdAsync(user.Id).Result;
                Assert.IsNotNull(foundUser);
                Assert.AreEqual("Johndoe@gmail.com", foundUser.Email);

       
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }


        [Test]
        public void ValidUser_IsValid()
        {
            // Arrange
             MapAppUser user = MakeValidUser();
            

            // Act
            
             ModelValidator mv = new ModelValidator(user);

            // Assert
                      
            Assert.That(mv.Valid, Is.True);
        }
        
       

    }
}

