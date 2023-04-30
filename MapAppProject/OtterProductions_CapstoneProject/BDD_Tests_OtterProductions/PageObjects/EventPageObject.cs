using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BDD_Tests_OtterProductions.Shared;
using System.Collections.ObjectModel;
using BDD_Tests_OtterProductions.PageObjects;

namespace BDD_Tests_OtterProductions.PageObjects
{
    public class EventPageObject : PageObject
    {
        public EventPageObject(IWebDriver webDriver) : base(webDriver)
        {
            // using a named page (in Common.cs)
            _pageName = "EventInfo";
        }

        public IWebElement EventLocation => _webDriver.FindElement(By.Id("Location"));
        public IWebElement NavBarHelloLink => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Manage\"]"));
        public IWebElement EventType => _webDriver.FindElement(By.Id("EventType"));
        public IWebElement EventDate => _webDriver.FindElement(By.Id("EventDate"));
        public IWebElement EventDiscription => _webDriver.FindElement(By.Id("EventDiscription"));
        public IWebElement OrganizationName => _webDriver.FindElement(By.Id("OrganizationName"));
        public IWebElement EventName => _webDriver.FindElement(By.Id("EventName"));






        public string NavbarWelcomeText()
        {
            return NavBarHelloLink.Text;
        }

        


    }
}
