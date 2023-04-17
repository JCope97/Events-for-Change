using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Cryptography;
using System.Collections.Generic;
using NUnit.Framework;
using System;
using System.Linq;
using OtterProductions_CapstoneProject.DAL.Abstract;
using OtterProductions_CapstoneProject.DAL.Concrete;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.Data;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using NUnit.Framework.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OtterProductions_Tests
{
    public class BrowseEventSearchRepository_Tests
    {
        //Creating tests to make sure EventLocation takes in the data from the form correctly    
        private Mock<MapAppDbContext> _mockContext;
        private Mock<DbSet<Event>> _mockEventDbSet;
        private List<Event> _event;
        private DateOnly _today;
        private TimeOnly _zeroTime;

        [SetUp]
        public void Setup()
        {
            _today = new DateOnly(2023, 2, 25);
            _zeroTime = new TimeOnly(0, 0, 0);
            _event = new List<Event>
            {
                new Event {OrganizationId = 5, EventName = "Cloudy with a chance of free food", EventLocation = "345 Monmouth Ave N, Monmouth, OR 97361", EventTypeId = 1, EventDescription = "Come and enjoy a warm meal", EventDate = _today.AddDays(11).ToDateTime(_zeroTime)},
                new Event {OrganizationId = 4, EventName = "Lifeline", EventLocation = "545 SW 2nd Street Corvallis, OR 97333", EventTypeId = 1, EventDescription = "Come and enjoy a warm meal", EventDate = _today.AddDays(12).ToDateTime(_zeroTime)},
                new Event {OrganizationId = 5, EventName = "Operation Sandwich", EventLocation = "345 Monmouth Ave N, Monmouth, OR 97361", EventTypeId = 1, EventDescription = "Free lunch meals", EventDate = _today.AddDays(12).ToDateTime(_zeroTime)},
                new Event {OrganizationId = 4, EventName = "Summer Heat Rest", EventLocation = "545 SW 2nd Street Corvallis, OR 97333", EventTypeId = 2, EventDescription = "Come visit if you are thirsty and need water bottles", EventDate = _today.AddDays(65).ToDateTime(_zeroTime)},
                new Event {OrganizationId = 2, EventName = "Hunger Helpers 2023", EventLocation = "4570 Center Street Salem, OR - 97301", EventTypeId = 1, EventDescription = "A lot of soup is being made for anyone!", EventDate = _today.AddDays(5).ToDateTime(_zeroTime)},
                new Event {OrganizationId = 2, EventName = "Hunger Helpers day 30 2023", EventLocation = "4570 Center Street Salem, OR - 97301", EventTypeId = 1, EventDescription = "A lot of soup is being made for anyone!", EventDate = _today.AddDays(35).ToDateTime(_zeroTime)},
            };



            _mockContext = new Mock<MapAppDbContext>();
            _mockEventDbSet = MockHelpers.GetMockDbSet(_event.AsQueryable());
            _mockContext.Setup(ctx => ctx.Events).Returns(_mockEventDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Event>()).Returns(_mockEventDbSet.Object);
        }

        [Test]
        public void GetAllEventsWithinTwoWeeksAndTheLocation_ReturnsOnlySalemEventsWithinTwoWeeks()
        {
            // Arrange
            IBrowseEventRepository browseEventRepository = new BrowseEventRepository(_mockContext.Object);

            // Act
            CityState cityStateLocation = new CityState();
            cityStateLocation.address = "Oregon State Capitol 900 Court St NE Salem, OR 97301";
            cityStateLocation.city = "Salem";
            cityStateLocation.state = "OR";
            cityStateLocation.zip = "97301";

            DateOnly today = _today;

            IEnumerable<Event> events = browseEventRepository.GetAllEventsWithinTwoWeeksAndTheLocation(cityStateLocation, today);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(events.Any(en => en.EventName == "Hunger Helpers 2023"), Is.True);
                Assert.That(events.Any(en => en.EventName == "Lifeline"), Is.False);
                Assert.That(events.Any(en => en.EventName == "Hunger Helpers day 30 2023"), Is.False);
            });
        }
    }
}
