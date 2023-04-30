using BDD_Tests_OtterProductions.Drivers;
using BDD_Tests_OtterProductions.PageObjects;
using BDD_Tests_OtterProductions.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace BDD_Tests_OtterProductions.StepDefinitions
{
    [Binding]
    public class EventPageStepDefinitions
    {
        private readonly EventPageObject _eventPage;
        public EventPageStepDefinitions(BrowserDriver browserDriver)
        {
            _eventPage = new EventPageObject(browserDriver.Current);
        }

        [Then(@"The event location is ""([^""]*)""")]
        public void TheEventTitleIsFreeDinner(string value)
        {
            _eventPage.EventLocation.Text.Should().Be(value);

        }

        [Then(@"The event Type is ""([^""]*)""")]
        public void TheEventTypeIsFreeDinner(string value)
        {
            _eventPage.EventType.Text.Should().Be(value);

        }

        [Then(@"The event discription is ""([^""]*)""")]
        public void TheEventDiscriptionIsComeAndEnjoyAFreeWarmMealFrom(string value)
        {
            _eventPage.EventDiscription.Text.Should().Be(value);

        }

        [Then(@"The event title is ""([^""]*)""")]
        public void TheEventTitleIs(string value)
        {
            _eventPage.EventName.Text.Should().Be(value);

        }

        [Then(@"The event date is ""([^""]*)""")]
        public void TheEventDateIs(string value)
        {
            _eventPage.EventDate.Text.Should().Be(value);

        }


    }
}
