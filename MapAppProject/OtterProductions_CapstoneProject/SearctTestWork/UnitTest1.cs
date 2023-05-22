
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OtterProductions_CapstoneProject.Areas.Identity.Data;
using OtterProductions_CapstoneProject.Controllers;
using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.DAL.Concrete;
using OtterProductions_CapstoneProject.Data;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.Utilities;
 using NUnit.Framework;
namespace SearctTestWork
{
  
        
      

        [TestFixture]
    public class SearchTests
    {
        private SearchService _searchService;
      

        [SetUp]
        public void Setup()
        {
            // Load the configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            // Create the required dependencies using the configuration
            var connectionString = configuration.GetConnectionString("MapAppConnection");
            var dbContextOptions = new DbContextOptionsBuilder<MapAppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            // Create an instance of the MapAppDbContext using the options
            var dbContext = new MapAppDbContext(dbContextOptions);          
             _searchService = new SearchService(dbContext);

            // Create an instance of the SearchController with the search service
          
        }
        [Test]
        public void Search_ReturnsResults()
        {
            // Arrange
            string orgName = "asf"; string? orgLocation = "";

            // Act
            var results = _searchService.Search(orgName,orgLocation);

            // Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
        }

       
    }

}