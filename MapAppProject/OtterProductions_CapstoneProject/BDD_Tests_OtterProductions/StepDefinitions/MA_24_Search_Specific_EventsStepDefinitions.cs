using BDD_Tests_OtterProductions.Drivers;
using BDD_Tests_OtterProductions.PageObjects;
using BDD_Tests_OtterProductions.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using Azure;
using Microsoft.CodeAnalysis.Options;
using Microsoft.SqlServer.Server;
using Moq;
using System.Runtime.Intrinsics.X86;
using OpenQA.Selenium;

namespace BDD_Tests_OtterProductions.StepDefinitions
{
    [Binding]
    public class MA_24_Search_Specific_EventsStepDefinitions
    {

       private readonly SearchEventPageObject _SearchEventPage;

        public MA_24_Search_Specific_EventsStepDefinitions(BrowserDriver browserDriver)
        {
            _SearchEventPage = new SearchEventPageObject(browserDriver.Current);
        }

/*        [Given(@"I am a visitor")]
        public void GivenIAmAVisitor()
        {
            //Nothing
        }*/

/*        [When(@"I am on the ""([^""]*)"" page")]
        public void WhenIAmOnThePage(string pageName)
        {
            _SearchEventPage.GoTo(pageName);
        }*/

        [When(@"I type ""([^""]*)"" in the name form")]
        public void WhenITypeInput(string eventInput)
        {
            _SearchEventPage.EnterEventInput(eventInput);
        }

        [Then(@"I can see an option to search by location or by the event name")]
        public void ThenThePageShowsTwoSubmitButtons()
        {
            _SearchEventPage.EventLocation.Displayed.Should().BeTrue();
            _SearchEventPage.EventName.Displayed.Should().BeTrue();
        }

        [Then(@"it will populate all events with the title ""([^""]*)""")]
        public void ThenThePageContainsATableOfEvents()
        {
            _SearchEventPage.EventNameTable.Displayed.Should().BeTrue();
        }
    }
}
