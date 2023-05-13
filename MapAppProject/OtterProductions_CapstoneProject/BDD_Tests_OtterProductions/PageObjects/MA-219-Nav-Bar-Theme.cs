using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BDD_Tests_OtterProductions.Shared;
using System.Collections.ObjectModel;
using BDD_Tests_OtterProductions.PageObjects;

namespace BDD_Tests_OtterProductions.PageObjects
{    public class MA219PageObject : PageObject
    {
        public MA219PageObject(IWebDriver webDriver) : base(webDriver)
        {
            // using a named page (in Common.cs)
            _pageName = "Home";
        }
        public IWebElement NavigationBar => _webDriver.FindElement(By.Id("navMenu"));
        //public IWebElement NavBarHelloLink => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Manage\"]"));
        public IWebElement GoToMap => _webDriver.FindElement(By.CssSelector("a[href=\"/Map/Mappage\"]"));

        public IWebElement GoToLocalEvents => _webDriver.FindElement(By.CssSelector("a[href=\"/Home/BrowsingSearch\"]"));

        public IWebElement GoToRegistration => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Register\"]"));

        public IWebElement GoToLogin => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Login\"]"));

        public IWebElement GoToPrivacy => _webDriver.FindElement(By.CssSelector("a[href=\"/Home/Privacy\"]"));

        public IWebElement GoToFAQ => _webDriver.FindElement(By.CssSelector("a[href=\"/Home/FAQ\"]"));

        //public void Login()
        //{
        //    SubmitButton.Click();
        //}

        public void NavigateToMap()
        {
            GoToMap.Click();
        }

        public void NavigateToLocalEvents()
        {
            GoToLocalEvents.Click();
        }

        public void NavigateToRegistration()
        {
            GoToRegistration.Click();
        }

        public void NavigateToLogin()
        {
            GoToLogin.Click();
        }

        public void NavigateToPrivacy()
        {
            GoToPrivacy.Click();
        }

        public void NavigateToFAQ()
        {
            GoToFAQ.Click();
        }
    }
}
