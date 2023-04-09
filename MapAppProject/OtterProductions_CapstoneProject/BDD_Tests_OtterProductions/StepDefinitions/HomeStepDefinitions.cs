using System;
using TechTalk.SpecFlow;

namespace BDD_Tests_OtterProductions.StepDefinitions
{
    [Binding]
    public class HomeStepDefinitions
    {
        [Given(@"I am a visitor")]
        public void GivenIAmAVisitor()
        {
            // nothing to do :)
        }

        [When(@"I am on the ""([^""]*)"" page")]
        public void WhenIAmOnThePage(string pageName)
        {
            throw new PendingStepException();
        }

        [Then(@"The page title contains ""([^""]*)""")]
        public void ThenThePageTitleContains(string p0)
        {
            throw new PendingStepException();
        }
    }
}
