using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BDD_Tests_OtterProductions.Shared;
using System.Collections.ObjectModel;
using BDD_Tests_OtterProductions.PageObjects;

namespace BDD_Tests_OtterProductions.PageObjects
{
    public class MA29PageObject : PageObject
    {
        public MA29PageObject(IWebDriver webDriver) : base(webDriver)
        {
            // using a named page (in Common.cs)
            _pageName = "EditInfo";
        }
        //public IWebElement NavigationBar => _webDriver.FindElement(By.Id("navMenu"));
        //public IWebElement NavBarHelloLink => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Manage\"]"));
        //public IWebElement GoToMap => _webDriver.FindElement(By.CssSelector("a[href=\"/Map/Mappage\"]"));
        public IWebElement SubmitButton => _webDriver.FindElement(By.Id("editButton"));
        public IWebElement LogInButton => _webDriver.FindElement(By.Id("buttonLogin"));

        public IWebElement LogOutButton => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Login\"]"));
        public IWebElement ExplanationMessage => _webDriver.FindElement(By.Id("editInfoExplanation"));

        public IWebElement NewEmailInput => _webDriver.FindElement(By.Name("Email"));
        public IWebElement NewNumberInput => _webDriver.FindElement(By.Name("PhoneNumber"));

        public IWebElement EditForm => _webDriver.FindElement(By.Id("editInfoForm"));

        public IWebElement EditButton => _webDriver.FindElement(By.Id("editButton"));

        //editInfoExplanation
        public void SubmitEdit()
        {
            SubmitButton.Click();
        }

        public void LogIn()
        {
            LogInButton.Click();
        }

        public void LogOut()
        {
            LogOutButton.Click();
        }

        public void SubmitNewEdit()
        {
            EditButton.Click();
        }


        public void EnterNewEmail(string newEmail)
        {
            NewEmailInput.Clear();
            NewEmailInput.SendKeys(newEmail);
        }

        public void EnterNewNumber(string newNumber)
        {
            NewNumberInput.Clear();
            NewNumberInput.SendKeys(newNumber);
        }
        

        //public void EditExplanation()
        //{
        //    ExplanationMessage.Click();
        //}

        //public void NavigateToMap()
        //{
        //    GoToMap.Click();
        //}


    }
}
