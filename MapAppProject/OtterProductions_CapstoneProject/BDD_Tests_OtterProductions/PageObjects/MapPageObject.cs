using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BDD_Tests_OtterProductions.Shared;
using System.Collections.ObjectModel;
using BDD_Tests_OtterProductions.PageObjects;

namespace BDD_Tests_OtterProductions.PageObjects
{
    public class MapPageObject : PageObject
    {
        public MapPageObject(IWebDriver webDriver) : base(webDriver)
        {
            // using a named page (in Common.cs)
            _pageName = "Map";
        }

        public IWebElement LocationTextBox => _webDriver.FindElement(By.Id("location"));
        public IWebElement LocationTextBoxButton => _webDriver.FindElement(By.Id("submit"));
        public IWebElement RestroomButton => _webDriver.FindElement(By.Id("restroom"));
        public IWebElement FoodBankButton => _webDriver.FindElement(By.Id("Food Bank"));
        public IWebElement ShelterButton => _webDriver.FindElement(By.Id("Shelter"));





        public IWebElement MapDiv => _webDriver.FindElement(By.Id("map"));

        public IWebElement SideBarList => _webDriver.FindElement(By.Id("places"));


        public void EnterCity(string city)
        {
            LocationTextBox.Clear();
            LocationTextBox.SendKeys(city);
        }

        public void SubmitCity()
        {
            LocationTextBoxButton.Click();
        }

        public void ClickRestroom()
        {
            RestroomButton.Click();
        }

        public void ClickFoodBank()
        {
            FoodBankButton.Click();
        }

        public void ClickShelter()
        {
            ShelterButton.Click();
        }
    }
}