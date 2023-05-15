//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using NUnit.Framework;
//using YourNamespace.Controllers;
//using YourNamespace.Data;
//using YourNamespace.Models;
//using YourNamespace.ViewModels;

//namespace YourNamespace.Tests.Controllers
//{
//    [TestFixture]
//    public class OrganizationControllerTests
//    {
//        private MapAppDbContext _dbContext;
//        private AuthenticationDbContext _authDbContext;
//        private UserManager<MapAppUser> _userManager;
//        private SignInManager<MapAppUser> _signInManager;
//        private OrganizationController _controller;

//        [SetUp]
//        public async Task SetUpAsync()
//        {
//            // Set up an in-memory database and seed it with test data
//            var options = new DbContextOptionsBuilder<MapAppDbContext>()
//                .UseInMemoryDatabase(databaseName: "TestDb")
//                .Options;

//            _dbContext = new MapAppDbContext(options);
//            await _dbContext.Database.EnsureDeletedAsync(); // ensure clean state
//            await _dbContext.Database.EnsureCreatedAsync(); // create schema
//            _dbContext.Organizations.AddRange(GetTestOrganizations());
//            await _dbContext.SaveChangesAsync();

//            // Mock the user manager and sign-in manager
//            var userStoreMock = new Mock<IUserStore<MapAppUser>>();
//            _userManager = new UserManager<MapAppUser>(userStoreMock.Object, null, null, null, null, null, null, null, null);
//            var signInManagerMock = new Mock<SignInManager<MapAppUser>>(_userManager,
//                new Mock<IHttpContextAccessor>().Object, new Mock<IUserClaimsPrincipalFactory<MapAppUser>>().Object, null, null, null, null);
//            _signInManager = signInManagerMock.Object;

//            // Set up the controller with the mock database context and user manager
//            _controller = new OrganizationController(_dbContext, _authDbContext, _userManager, _signInManager);
//        }

//        [TearDown]
//        public async Task TearDownAsync()
//        {
//            // Dispose of the in-memory database and other resources
//            await _dbContext.Database.EnsureDeletedAsync();
//            _dbContext.Dispose();
//        }

//        private List<Organization> GetTestOrganizations()
//        {
//            return new List<Organization>
//            {
//                new Organization
//                {
//                    Id = 1,
//                    Email = "foodbankorganization@gmail.com",
//                    OrganizationDescription = "We are a food bank org",
//                    OrganizationLocation = "Monmouth OR",
//                    OrganizationName = "Food Bank Organization",
//                    PhoneNumber = "123-456-7890",
//                    AspnetIdentityId ="5e0d9a17-1d99-46f0-b085-2f9944a558b0"
//                },
//                new Organization
//                {
//                    Id = 2,
//                    Email = "org2@example.com",
//                    OrganizationDescription = "We are shelter hosting org",
//                    OrganizationLocation = "Salem OR",
//                    OrganizationName = "Shelter Village",
//                    PhoneNumber = "987-654-3210",
//                    AspnetIdentityId = "64699aeb-4386-4ba4-a038-44875d4d5ffe"
//                }
//            };
//        }

//        [Test]
//        public async Task EditOrganization_Get_ReturnsView()
//        {
//            // Arrange
//            var ids = "foodbankorganization@gmail.com";

//            // Act
//            var result = await _controller.EditOrganization(ids);

//            // Assert
//            Assert.IsInstanceOf<ViewResult>(result);
//            var viewResult = (ViewResult)result;
//            Assert.IsNull(viewResult.ViewName); // defaults to action name
//            var model = (OrganizationViewModel)viewResult.Model;
//            Assert.IsNotNull(model);
//            Assert.AreEqual("Food Bank Organization", model.OrganizationName);
//            Assert.AreEqual("We are a food bank org", model.OrganizationDescription);
//            // TODO: add more assertions for the