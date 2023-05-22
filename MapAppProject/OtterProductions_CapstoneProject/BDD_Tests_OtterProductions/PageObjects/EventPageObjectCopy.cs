using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OtterProductions_CapstoneProject.Models;
using System;
using System.Collections.Generic;

namespace BDD_Tests_OtterProductions.PageObjects
{
    public class EventPageObject : PageObject
    {
        private readonly IWebDriver _driver;

        public EventPageObject(IWebDriver driver) : base(driver)
        {
            // Set the page name
            _driver = driver;
            _pageName = "Events";
        }

        public IWebElement AddNewEventButton => _driver.FindElement(By.CssSelector("a.search-button.btn.btn-sm.btn-primary.dark-background"));

        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            IReadOnlyCollection<IWebElement> eventRows = _driver.FindElements(By.CssSelector("table.table.table-striped tbody tr"));

            foreach (var row in eventRows)
            {
                IWebElement eventNameElement = row.FindElement(By.CssSelector("td:nth-child(1)"));
                IWebElement eventLocationElement = row.FindElement(By.CssSelector("td:nth-child(2)"));
                IWebElement eventDescriptionElement = row.FindElement(By.CssSelector("td:nth-child(3)"));
                IWebElement eventTypeElement = row.FindElement(By.CssSelector("td:nth-child(4)"));
                IWebElement eventDateElement = row.FindElement(By.CssSelector("td:nth-child(5)"));

                string eventTypeText = eventTypeElement.Text;
                int eventTypeId = int.Parse(eventTypeElement.GetAttribute("data-event-type-id"));

                Event ev = new Event
                {
                    EventName = eventNameElement.Text,
                    EventLocation = eventLocationElement.Text,
                    EventDescription = eventDescriptionElement.Text,
                    EventDate = DateTime.Parse(eventDateElement.Text),
                    EventTypeId = eventTypeId // Assuming EventTypeId is an int property in the Event model
                };

                events.Add(ev);
            }

            return events;
        }

        public void ClickAddNewEventButton()
        {
            AddNewEventButton.Click();
        }
    }
}
