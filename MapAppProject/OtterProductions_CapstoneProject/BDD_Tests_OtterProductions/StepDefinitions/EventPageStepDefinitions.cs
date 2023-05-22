using BDD_Tests_OtterProductions.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace BDD_Tests_OtterProductions.StepDefinitions
{
    [Binding]
    public class EventSteps
    {
        private IWebDriver _driver;
        private EventPageObject _eventPage;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _eventPage = new EventPageObject(_driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Given(@"I am logged in as an organization")]
        public void GivenIAmLoggedInAsAnOrganization()
        {
            // Navigate to the login page
            _driver.Navigate().GoToUrl("https://localhost:7196/Identity/Account/Login");

            // Enter the organization credentials
            IWebElement usernameInput = _driver.FindElement(By.Id("username"));
            usernameInput.SendKeys("organization@example.com");

            IWebElement passwordInput = _driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("password123");

            // Click the login button
            IWebElement loginButton = _driver.FindElement(By.Id("loginButton"));
            loginButton.Click();

            // Wait for the login process to complete (e.g., wait for the dashboard page to load)
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url.Contains("dashboard"));
        }

        [When(@"I am on the ""(.*)"" page")]
        public void WhenIAmOnThePage(string pageName)
        {
            string url;

            switch (pageName.ToLower())
            {
                case "events":
                    url = "https://localhost:7196/Organization/Events";
                    break;
                case "createevent":
                    url = "https://localhost:7196/Organization/CreateEvent";
                    break;
                default:
                    throw new NotSupportedException($"Navigation to page '{pageName}' is not supported.");
            }

            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"I should have my event name on the page")]
        public void ThenIShouldHaveMyEventNameOnThePage()
        {
            string expectedEventName = "My Event Name";

            // Retrieve the event name from the page
            IWebElement eventNameElement = _driver.FindElement(By.CssSelector("your-css-selector-for-event-name-element"));
            string actualEventName = eventNameElement.Text;

            // Assert the presence of the event name
            Assert.AreEqual(expectedEventName, actualEventName, $"Expected event name: '{expectedEventName}'. Actual event name: '{actualEventName}'.");
        }


        [Then(@"I should see the title on the page")]
        public void ThenIShouldSeeTheTitleOnThePage()
        {
            string expectedTitle = "Page Title";

            // Retrieve the title from the page
            string actualTitle = _driver.Title;

            // Assert the presence of the title
            Assert.AreEqual(expectedTitle, actualTitle, $"Expected title: '{expectedTitle}'. Actual title: '{actualTitle}'.");
        }

        [Then(@"I should be routed to ""(.*)"" page")]
        public void ThenIShouldBeRoutedToPage(string pageName)
        {
            string expectedPageUrl = "https://localhost:7196/Organization/CreateEvent"; // Replace with the expected URL of the page

            // Retrieve the current page URL
            string actualPageUrl = _driver.Url;

            // Assert the correctness of the page URL
            Assert.AreEqual(expectedPageUrl, actualPageUrl, $"Expected page URL: '{expectedPageUrl}'. Actual page URL: '{actualPageUrl}'.");
        }


        [Given(@"I click the ""(.*)"" nav link")]
        public void GivenIClickTheNavLink(string linkText)
        {
            // Find the nav link element based on the provided link text
            IWebElement navLink = _driver.FindElement(By.LinkText(linkText));

            // Click the nav link
            navLink.Click();
        }


        [Given(@"the Event Name input field is filled in with ""(.*)""")]
        public void GivenTheEventNameInputFieldIsFilledInWith(string eventName)
        {
            // Find the Event Name input field element
            IWebElement eventNameInput = _driver.FindElement(By.Id("eventNameInput")); // Adjust the locator as per your HTML structure

            // Clear the input field
            eventNameInput.Clear();

            // Set the value of the input field to the provided event name
            eventNameInput.SendKeys(eventName);
        }



        [Given(@"the Event Location input field is filled in with ""(.*)""")]
        public void GivenTheEventLocationInputFieldIsFilledInWith(string eventLocation)
        {
            // Find the Event Location input field element
            IWebElement eventLocationInput = _driver.FindElement(By.Id("eventLocationInput"));

            // Clear the input field 
            eventLocationInput.Clear();

            // Set the value of the input field to the provided event location
            eventLocationInput.SendKeys(eventLocation);
        }

        [Given(@"the Event Description input field is filled in with ""(.*)""")]
        public void GivenTheEventDescriptionInputFieldIsFilledInWith(string eventDescription)
        {
            // Find the Event Description input field element
            IWebElement eventDescriptionInput = _driver.FindElement(By.Id("eventDescriptionInput")); 

            // Clear the input field 
            eventDescriptionInput.Clear();

            // Set the value of the input field to the provided event description
            eventDescriptionInput.SendKeys(eventDescription);
        }


        [Given(@"the Event Date with ""(.*)""")]
        public void GivenTheEventDateWith(string eventDate)
        {
            // Find the Event Date input field element
            IWebElement eventDateInput = _driver.FindElement(By.Id("eventDateInput"));

            // Clear the input field (optional, if needed)
            eventDateInput.Clear();

            // Set the value of the input field to the provided event date
            eventDateInput.SendKeys(eventDate);
        }

        [Given(@"the Event Type input field with ""(.*)""")]
        public void GivenTheEventTypeInputFieldWith(string eventType)
        {
            // Find the Event Type input field element
            IWebElement eventTypeInput = _driver.FindElement(By.Id("eventTypeInput"));

            // Clear the input field 
            eventTypeInput.Clear();

            // Set the value of the input field to the provided event type
            eventTypeInput.SendKeys(eventType);
        }


        [Given(@"the ""(.*)"" button is clicked")]
        public void GivenTheButtonIsClicked(string buttonId)
        {
            // Find the button element by its ID
            IWebElement button = _driver.FindElement(By.Id(buttonId));

            // Perform a click operation on the button
            button.Click();
        }

        [Then(@"I should be routed to the ""(.*)"" page")]
        public void ThenIShouldBeRoutedToThePage(string pageName)
        {
            // Implement the verification of the current page after navigation
            string currentUrl = _driver.Url;

            // Verify if the current URL contains the expected page name
            currentUrl.Should().Contain(pageName); 
        }
    }
}
