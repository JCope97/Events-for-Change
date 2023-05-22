using BDD_Tests_OtterProductions.Drivers;
using BDD_Tests_OtterProductions.PageObjects;
using BDD_Tests_OtterProductions.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System;
using System.Diagnostics;
using FluentAssertions;

namespace BDD_Tests_OtterProductions.StepDefinitions
{
    public class TestUser3
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string NewEmail { get; set; }
        public string NewNumber { get; set; }
    }

    [Binding]
    public class MA29StepDefinitions
    {

        private readonly MA29PageObject _MA29Page;
        private readonly LoginPageObject _loginPage;
        private readonly ScenarioContext _scenarioContext;

        private IConfigurationRoot Configuration { get; }
        public MA29StepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
        {
            _MA29Page = new MA29PageObject(browserDriver.Current);
            _loginPage = new LoginPageObject(browserDriver.Current);
            _scenarioContext = context;


            IConfigurationBuilder builder = new ConfigurationBuilder().AddUserSecrets<MA29StepDefinitions>();
            Configuration = builder.Build();
        }

        [Given(@"I am a user that is registered")]
        public void GivenIAmARegisteredUser()
        {

            //TestUser3 user = new TestUser3
            //{
            //    UserName = "johndoe@email.com",
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Email = "johndoe@email.com",
            //    PhoneNumber = "1234567890",
            //    Password = "Pass1234*",//Configuration["userEditPassword"]
            //    NewEmail = "thejohndoe@email.com",
            //    NewNumber = "1111122222"

            //};

            TestUser3 user = new TestUser3
            {
                UserName = "thejohndoe@email.com",//"johndoe@email.com",
                FirstName = "John",
                LastName = "Doe",
                Email = "thejohndoe@email.com", //"johndoe@email.com",
                PhoneNumber = "1111122222", //"1234567890",
                Password = "Pass1234*",//Configuration["userEditPassword"]
                NewEmail = "johndoe@email.com",
                NewNumber = "1111111111"

            };

            if (user.Password == null)
            {
                throw new Exception("Did you forget to set the admin password in user-secrets?");
            }
            Debug.WriteLine("Password = " + user.Password);
            _scenarioContext["CurrentUser"] = user;
        }

        [Given(@"I login")]
        public void GivenILogin()
        {

            // Go to the login page
            _loginPage.GoTo();
            //Thread.Sleep(3000);
            // Now (attempt to) log them in.  Assumes previous steps defined the user
            TestUser3 u = (TestUser3)_scenarioContext["CurrentUser"];
            _loginPage.EnterEmail(u.Email);
            Thread.Sleep(3000);
            _loginPage.EnterPassword(u.Password);
            Thread.Sleep(3000);
            _loginPage.Login();
        }

        [Then(@"the page presents a submit button")]
        public void ThenThePagePresentsASubmitButton()
        {
            _MA29Page.SubmitButton.Should().NotBeNull();
            _MA29Page.SubmitButton.Displayed.Should().BeTrue();

            Assert.That(_MA29Page.SubmitButton.GetAttribute("class"), Does.Contain("editInfoButton"));
        }

        [Then(@"the page presents an explanation message")]
        public void ThenThePagePresentsAnExplanationMessage()

        {
            _MA29Page.ExplanationMessage.Should().NotBeNull();
            _MA29Page.ExplanationMessage.Displayed.Should().BeTrue();

            Assert.That(_MA29Page.ExplanationMessage.GetAttribute("class"), Does.Contain("editInfoExplanation"));

        }

        [Then(@"the page presents a form for editing information")]
        public void ThenThePagePresentsAFormForEditingInformation()
        {
            _MA29Page.EditForm.Should().NotBeNull();
            _MA29Page.EditForm.Displayed.Should().BeTrue();

            Assert.That(_MA29Page.EditForm.GetAttribute("class"), Does.Contain("editInfoForm"));

        }

        [Given(@"I fill out the form")]
        public void GivenIFillOutTheForm()
        {
            // Go to the login page
            _MA29Page.GoTo();
            //Thread.Sleep(3000);
            // Now (attempt to) log them in.  Assumes previous steps defined the user
            TestUser3 u = (TestUser3)_scenarioContext["CurrentUser"];
            _MA29Page.EnterNewEmail(u.NewEmail);
            _MA29Page.EnterNewNumber(u.NewNumber);
            _MA29Page.SubmitEdit();
        }

        [When(@"I fill out the form")]
        public void WhenIFillOutTheForm()
        {
            // Go to the login page
            _MA29Page.GoTo();
            //Thread.Sleep(3000);
            // Now (attempt to) log them in.  Assumes previous steps defined the user
            TestUser3 u = (TestUser3)_scenarioContext["CurrentUser"];
            _MA29Page.EnterNewEmail(u.NewEmail);
            _MA29Page.EnterNewNumber(u.NewNumber);
            _MA29Page.SubmitEdit();
        }
        [Given(@"I click the submit button")]
        public void GivenIClickTheSubmitButton()
        {
            Thread.Sleep(3000);
            _MA29Page.SubmitEdit();
            //_MA29Page.SubmitNewEdit();
        }

        [When(@"I click submit")]
        public void WhenIClickSubmit()
        {
            Thread.Sleep(3000);
            _MA29Page.SubmitEdit();
            //_MA29Page.SubmitNewEdit();
        }

        [When(@"I navigate back to the ""(.*)"" page")]
        public void WhenINavigateBackToThePage(string pageName)
        {
            _MA29Page.GoTo(pageName);
        }

        [Then(@"I can see my updated information in the form")]
        public void ThenICanSeeMyUpdatedInformationInTheForm()
        {
            _scenarioContext.Pending();
        }

    }
}