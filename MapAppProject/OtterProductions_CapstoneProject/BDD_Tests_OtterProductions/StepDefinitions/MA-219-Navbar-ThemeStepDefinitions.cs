using BDD_Tests_OtterProductions.Drivers;
using BDD_Tests_OtterProductions.PageObjects;
using BDD_Tests_OtterProductions.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System;
using System.Diagnostics;

namespace BDD_Tests_OtterProductions.StepDefinitions
{

    [Binding]
    public class MA219StepDefinitions
    {
        private readonly MA219PageObject _MA219Page;
        private readonly LoginPageObject _loginPage;
        private readonly ScenarioContext _scenarioContext;

        private IConfigurationRoot Configuration { get; }
        public MA219StepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
        {
            _MA219Page = new MA219PageObject(browserDriver.Current);
            _loginPage = new LoginPageObject(browserDriver.Current);
            _scenarioContext = context;
        }

        //[Given(@"I am on the ""([^""]*)"" page")]
        //public void GivenIAmOnThePage(string pageName)
        //{
        //    _loginPage.GoTo(pageName);
        //}

        [When(@"I click on Map in the navbar")]
        public void WhenIClickOnMapInTheNavbar()
        {
            _MA219Page.NavigateToMap();
        }

        [When(@"I click on Create an Account in the navbar")]
        public void WhenIClickOnCreateanAccountInTheNavbar()
        {
            _MA219Page.NavigateToRegistration();
        }

        [When(@"I click on Login in the navbar")]
        public void WhenIClickOnLoginInTheNavbar()
        {
            _MA219Page.NavigateToLogin();
        }

        [When(@"I click on Privacy in the navbar")]
        public void WhenIClickOnPrivacyInTheNavbar()
        {
            _MA219Page.NavigateToPrivacy();
        }

        [When(@"I click on FAQ in the navbar")]
        public void WhenIClickOnFAQInTheNavbar()
        {
            _MA219Page.NavigateToFAQ();
        }

        [When(@"I click on Local Events in the navbar")]
        public void WhenIClickOnLocalEventsInTheNavbar()
        {
            _MA219Page.NavigateToLocalEvents();
        }

        [Then(@"the page presents a navigation bar")]
        public void ThenThePagePresentsANavigationBar()

        {
            _MA219Page.NavigationBar.Should().NotBeNull();
            _MA219Page.NavigationBar.Displayed.Should().BeTrue();

            Assert.That(_MA219Page.NavigationBar.GetAttribute("class"), Does.Contain("navMenu"));
        }
    }
}
