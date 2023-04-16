using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BDD_Tests_OtterProductions.Shared;
using System.Collections.ObjectModel;
using Standups_BDD_Tests.PageObjects;

namespace BDD_Tests_OtterProductions.PageObjects
{
    public class LoginPageObject : PageObject
    {
        public LoginPageObject(IWebDriver webDriver) : base(webDriver)
        {
            // using a named page (in Common.cs)
            _pageName = "Login";
        }

        public IWebElement LoginButton => _webDriver.FindElement(By.Id("buttonLogin"));

        public IWebElement WelcomeMessage => _webDriver.FindElement(By.Id("loginWelcome"));
        public IWebElement NavBarHelloLink => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Manage\"]"));

        public IWebElement EmailInput => _webDriver.FindElement(By.Name("Input.Email"));
        public IWebElement PasswordInput => _webDriver.FindElement(By.Name("Input.Password"));

        public IWebElement SubmitButton => _webDriver.FindElement(By.Id("buttonLogin"));

        public IWebElement GoToRegister => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Register\"]"));


        //public IWebElement GoToRegister => _webDriver.FindElement(By.CssSelector("a[href=\"/Identity/Account/Register\"]"));
        //public IWebElement GoToRegister => _webDriver.FindElement(By.Id("registerLink"));


        public string NavbarWelcomeText()
        {
            return NavBarHelloLink.Text;
        }

        public void EnterEmail(string email)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void Login()
        {
            SubmitButton.Click();
        }

        public void NavigateToRegister()
        {
            GoToRegister.Click();
        }


    }
}