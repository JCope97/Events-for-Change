using BDD_Tests_OtterProductions.Drivers;
using BDD_Tests_OtterProductions.PageObjects;
using BDD_Tests_OtterProductions.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System;
using System.Diagnostics;

namespace BDD_Tests_OtterProductions.StepDefinitions
{

    public class TestUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }

    [Binding]
    public class LoginStepDefinitions
    {

        private readonly LoginPageObject _loginPage;
        private readonly ScenarioContext _scenarioContext;

       private IConfigurationRoot Configuration { get; }
        public LoginStepDefinitions(ScenarioContext context, BrowserDriver browserDriver)
        {
            _loginPage = new LoginPageObject(browserDriver.Current);
            _scenarioContext = context;


            IConfigurationBuilder builder = new ConfigurationBuilder().AddUserSecrets<LoginStepDefinitions>();
            Configuration = builder.Build();
        }

        [Given(@"I am a visitor")]
        public void GivenIAmAVisitor()
        {
            //Not needed
        }

        [When(@"I am on the ""([^""]*)"" page")]
        public void WhenIAmOnThePage(string pageName)
        {
            _loginPage.GoTo(pageName);
        }

        [Then(@"The page presents a Login button")]
        public void ThenThePagePresentsALoginButton()
        {
            _loginPage.LoginButton.Should().NotBeNull();
            _loginPage.LoginButton.Displayed.Should().BeTrue();

            Assert.That(_loginPage.LoginButton.GetAttribute("class"), Does.Contain("buttonLogin"));
        }

        [Then(@"The page contains a welcome message")]
        public void ThenThePageContainsAWelcomeMessage()
        {
            _loginPage.WelcomeMessage.Should().NotBeNull();
            _loginPage.WelcomeMessage.Displayed.Should().BeTrue();

            Assert.That(_loginPage.WelcomeMessage.GetAttribute("class"), Does.Contain("loginWelcome"));

        }

        [When(@"I click on Don't have an account\? Create one here!")]
        public void WhenIClickOnDontHaveAnAccountCreateOneHere()
        {
            _loginPage.NavigateToRegister();
        }

        [Then(@"I am redirected to the ""([^""]*)"" page")]
        public void ThenIAmRedirectedToThePage(string pageName)
        {
            _loginPage.GetURL().Should().Be(Common.UrlFor(pageName));
        }

        [Given(@"I am a registered user")]
        public void GivenIAmARegisteredUser()
        {

            TestUser user = new TestUser
            {
                UserName = "johndoe@email.com",
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@email.com",
                Password = Configuration["userTestingPassword"]
            };
            if (user.Password == null)
            {
                throw new Exception("Did you forget to set the admin password in user-secrets?");
            }
            Debug.WriteLine("Password = " + user.Password);
            _scenarioContext["CurrentUser"] = user;
        }

        [Given(@"I am on the ""([^""]*)"" page")]
        public void GivenIAmOnThePage(string pageName)
        {
            _loginPage.GoTo(pageName);
        }

        [When(@"I login")]
        public void WhenILogin()
        {

            // Go to the login page
            _loginPage.GoTo();
            //Thread.Sleep(3000);
            // Now (attempt to) log them in.  Assumes previous steps defined the user
            TestUser u = (TestUser)_scenarioContext["CurrentUser"];
            _loginPage.EnterEmail(u.Email);
            _loginPage.EnterPassword(u.Password);
            _loginPage.Login();
        }
    }
}
