using BDD_Tests_OtterProductions.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace YourNamespace
{
    [Binding]
    public class EventSteps
    {
        private IWebDriver driver;
        private EventPageObjectCopy eventPage;

        [Given(@"I am logged in as an organization")]
        public void GivenIAmLoggedInAsAnOrganization()
        {
            // Add your code to log in as an organization
            driver = new ChromeDriver();
            // Login logic
        }

        [When(@"I am on the ""(.*)"" page")]
        public void WhenIAmOnThePage(string pageName)
        {
            // Add your code to navigate to the specified page
            driver.Navigate().GoToUrl("https://yourwebsite.com/" + pageName);
            // Navigation logic
            eventPage = new EventPageObject(driver);
        }

        [Then(@"I should have my event name on the page")]
        public void ThenIShouldHaveMyEventNameOnThePage()
        {
            // Add your code to verify that the event name is displayed on the page
            string eventName = eventPage.EventName.Text;
            // Assertion logic
        }

        [Then(@"I should see the title on the page")]
        public void ThenIShouldSeeTheTitleOnThePage()
        {
            // Add your code to verify that the title is displayed on the page
            string pageTitle = driver.FindElement(By.TagName("h1")).Text;
            // Assertion logic
        }

        [When(@"I click the ""(.*)"" nav link")]
        public void WhenIClickTheNavLink(string linkText)
        {
            // Add your code to click the specified nav link
            IWebElement linkElement = driver.FindElement(By.LinkText(linkText));
            linkElement.Click();
            // Click logic
        }

        [Then(@"I should be routed to ""(.*)"" page")]
        public void ThenIShouldBeRoutedToPage(string pageName)
        {
            // Add your code to verify that the current page URL matches the expected page URL
            string currentUrl = driver.Url;
            // Assertion logic
        }

        [When(@"the Event Name input field is filled in with ""(.*)""")]
        public void WhenTheEventNameInputFieldIsFilledInWith(string eventName)
        {
            // Add your code to enter the event name in the input field
            eventPage.EventName.SendKeys(eventName);
            // Input logic
        }

        [When(@"the Event Location input field is filled in with ""(.*)""")]
        public void WhenTheEventLocationInputFieldIsFilledInWith(string eventLocation)
        {
            // Add your code to enter the event location in the input field
            eventPage.EventLocation.SendKeys(eventLocation);
            // Input logic
        }

        [When(@"the Event Description input field is filled in with ""(.*)""")]
        public void WhenTheEventDescriptionInputFieldIsFilledInWith(string eventDescription)
        {
            // Add your code to enter the event description in the input field
            eventPage.EventDiscription.SendKeys(eventDescription);
            // Input logic
        }

        [When(@"the Event Date with ""(.*)""")]
        public void WhenTheEventDateWith(string eventDate)
        {
            // Add your code to enter the event date in the input field
            eventPage.EventDate.SendKeys(eventDate);
            // Input logic
        }

        [When(@"the Event Type input field with ""(.*)""")]
        public void WhenTheEventTypeInputFieldWith(string eventType)
        {
            // Add your code to select the event type from the dropdown
            SelectElement eventTypeDropdown = new SelectElement(eventPage.EventType);
            eventTypeDropdown.SelectByText(eventType);
            // Select logic
        }

        [When(@"the ""(.*)"" button is clicked")]
        public void WhenTheButtonIsClicked(string buttonId)
        {
            // Add your code to click the specified button
            IWebElement button = driver.FindElement(By.Id(buttonId));
            button.Click();
            // Click logic
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Add your code to clean up after the scenario
            driver.Quit();
        }
    }
}
