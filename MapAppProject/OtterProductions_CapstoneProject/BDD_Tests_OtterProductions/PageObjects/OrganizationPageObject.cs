using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Tests_OtterProductions.PageObjects
{
    public class OrganizationProfilePageObject : PageObject
    {
        public OrganizationProfilePageObject(IWebDriver webDriver) : base(webDriver)
        {
            _pageName = "Organization";
        }
        public IWebElement IsOrganizationCheckBox => _webDriver.FindElement(By.Name("IsOrganization"));
        public IWebElement fileUploadTextBox => _webDriver.FindElement(By.Name("fileUpload"));
        public IWebElement EmailTextBox => _webDriver.FindElement(By.Name("Email"));
        public IWebElement OrganizationNameTextBox => _webDriver.FindElement(By.Name("OrganizationName"));
        public IWebElement OrganizationDescriptionTextBox => _webDriver.FindElement(By.Name("OrganizationDescription"));
        public IWebElement OrganizationLocationTextBox => _webDriver.FindElement(By.Name("OrganizationLocation"));
        public IWebElement AddressTextBox => _webDriver.FindElement(By.Name("Address"));
        public IWebElement PhoneNumbernTextBox => _webDriver.FindElement(By.Name("PhoneNumber"));
        public IWebElement PasswordTextBox => _webDriver.FindElement(By.Name("OrganizationLoginId"));
        public IWebElement ConfirmPasswordTextBox => _webDriver.FindElement(By.Name("ConfirmPassword"));
        public IWebElement CreateAccounBoxButton => _webDriver.FindElement(By.Id("registerSubmit"));
    }
}
