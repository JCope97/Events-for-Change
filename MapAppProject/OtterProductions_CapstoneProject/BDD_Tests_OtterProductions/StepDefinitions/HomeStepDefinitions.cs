//using System;
//using BDD_Tests_OtterProductions.Drivers;
//using BDD_Tests_OtterProductions.PageObjects;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using TechTalk.SpecFlow;

//namespace BDD_Tests_OtterProductions.StepDefinitions
//{
//    [Binding]
//    public class HomeStepDefinitions
//    {
//        private readonly HomePageObject _homePage;
//        public HomeStepDefinitions(BrowserDriver browserDriver)
//        {
//            _homePage = new HomePageObject(browserDriver.Current);
//        }
//        [Given(@"I am a visitor")]
//        public void GivenIAmAVisitor()
//        {
//            // nothing to do :)
//        }

//        [When(@"I am on the ""([^""]*)"" page")]
//        public void WhenIAmOnThePage(string pageName)
//        {
//            _homePage.GoTo(pageName);
//        }

//        [Then(@"The page title contains ""([^""]*)""")]
//        public void ThenThePageTitleContains(string p0)
//        {
//            _homePage.GetTitle().Should().ContainEquivalentOf(p0, AtLeast.Once());
//        }


//    }
//}
