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
    public class BrowseEventRepository_Tests
    {
        //Creating tests for Events to be seen in a window of 2 weeks        
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
                new Event {OrganzationId = 5, EventName = "Cloudy with a chance of free food", EventLocation = "Salem OR", EventTypeId = 1, EventDescription = "Come and enjoy a warm meal", EventDate = _today.AddDays(11).ToDateTime(_zeroTime)},
                new Event {OrganzationId = 4, EventName = "Lifeline", EventLocation = "Corvallis OR", EventTypeId = 1, EventDescription = "Come and enjoy a warm meal", EventDate = _today.AddDays(12).ToDateTime(_zeroTime)},
                new Event {OrganzationId = 5, EventName = "Operation Sandwich", EventLocation = "Monmouth OR", EventTypeId = 1, EventDescription = "Free lunch meals", EventDate = _today.AddDays(12).ToDateTime(_zeroTime)},
                new Event {OrganzationId = 4, EventName = "Summer Heat Rest", EventLocation = "Corvallis OR", EventTypeId = 2, EventDescription = "Come visit if you are thirsty and need water bottles", EventDate = _today.AddDays(65).ToDateTime(_zeroTime)},
            };



            _mockContext = new Mock<MapAppDbContext>();
            _mockEventDbSet = MockHelpers.GetMockDbSet(_event.AsQueryable());
            _mockContext.Setup(ctx => ctx.Events).Returns(_mockEventDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<Event>()).Returns(_mockEventDbSet.Object);
        }

        [Test]
        public void GetAllEventsWithinTwoWeeks_ReturnsAllEvents()
        {
            // Arrange
            IBrowseEventRepository browseEventRepository = new BrowseEventRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            IEnumerable<Event> events = browseEventRepository.GetAllEventsWithinTwoWeeks(today);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(events.Any(en => en.EventName == "Cloudy with a chance of free food"), Is.True);
                Assert.That(events.Any(en => en.EventName == "Lifeline"), Is.True);
                Assert.That(events.Any(en => en.EventName == "Operation Sandwich"), Is.True);
            });
        }

        [Test]
        public void GetAllEventsWithinTwoWeeks_ShouldNotReturnTheEventOutOfWindow()
        {
            // Arrange
            IBrowseEventRepository browseEventRepository = new BrowseEventRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            IEnumerable<Event> events = browseEventRepository.GetAllEventsWithinTwoWeeks(today);

            // Assert
            Assert.That(events.Any(en => en.EventName == "Summer Heat Rest"), Is.False);
        }

        [Test]
        public void GetAllEventsWithinTwoWeeks_ShouldReturnMultipleEventsWithinTheTwoWeekTimeFrame()
        {
            // Arrange
            IBrowseEventRepository browseEventRepository = new BrowseEventRepository(_mockContext.Object);

            // Act
            DateOnly today = _today;
            IEnumerable<Event> events = browseEventRepository.GetAllEventsWithinTwoWeeks(today);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(events.ElementAt(0).EventDate, Is.EqualTo(_today.AddDays(11).ToDateTime(_zeroTime)));
                Assert.That(events.ElementAt(1).EventDate, Is.EqualTo(_today.AddDays(12).ToDateTime(_zeroTime)));
                Assert.That(events.ElementAt(2).EventDate, Is.EqualTo(_today.AddDays(12).ToDateTime(_zeroTime)));
            });
        }
    }
}
