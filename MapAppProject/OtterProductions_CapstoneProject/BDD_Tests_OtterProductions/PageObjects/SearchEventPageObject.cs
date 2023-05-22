using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BDD_Tests_OtterProductions.Shared;
using System.Collections.ObjectModel;
using BDD_Tests_OtterProductions.PageObjects;

namespace BDD_Tests_OtterProductions.PageObjects
{
    public class SearchEventPageObject : PageObject
    {
        public SearchEventPageObject(IWebDriver webDriver) : base(webDriver)
        {
            // using a named page (in Common.cs)
            _pageName = "SearchEvent";
        }

        public IWebElement EventLocation => _webDriver.FindElement(By.Id("EventByLocation"));
        public IWebElement EventName => _webDriver.FindElement(By.Id("EventByName"));

        public IWebElement EventInput => _webDriver.FindElement(By.Id("EventNameInput"));

        public IWebElement EventNameTable => _webDriver.FindElement(By.Id("eventLogTable"));


        public void EnterEventInput(string eventName)
        {
            EventInput.Clear();
            EventInput.SendKeys(eventName);
        }

        public void ClickEventNameSubmit()
        {
            EventName.Click();
        }

    }
}