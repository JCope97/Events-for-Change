using BDD_Tests_OtterProductions.Drivers;
using BDD_Tests_OtterProductions.PageObjects;
using BDD_Tests_OtterProductions.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace BDD_Tests_OtterProductions.StepDefinitions
{
    [Binding]
    public class MA_135_ListOfPlacesStepDefinitions
    {
        private readonly MapPageObject _mapPage;
        public MA_135_ListOfPlacesStepDefinitions(BrowserDriver browserDriver)
        {
            _mapPage = new MapPageObject(browserDriver.Current);
        }

        [Then(@"the page presents a restroom button, a shelter button and a food bank button")]
        public void ThenThePagePresentsARestroomButtonAShelterButtonAndAFoodBankButton()
        {
            _mapPage.FoodBankButton.Displayed.Should().BeTrue();
            _mapPage.ShelterButton.Displayed.Should().BeTrue();
            _mapPage.RestroomButton.Displayed.Should().BeTrue();

        }


        [When(@"the address text box is filled in with ""([^""]*)""")]
        public void WhenTheAddressTextBoxIsFilledInWith(string p0)
        {
            _mapPage.EnterCity(p0);
        }


        [When(@"the ""([^""]*)"" button is clicked")]
        public void WhenTheButtonIsClicked(string buttonIdName)
        {
           var buttonId = buttonIdName;
           string restrooms = "restroom";
           string foodBanks = "Food Bank";
           string shelter = "Shelter";


            if (buttonId == restrooms)
            {
               _mapPage.ClickRestroom();
               Thread.Sleep(5000);
            } 
            if (buttonId == foodBanks) 
            {
                _mapPage.ClickFoodBank();
                Thread.Sleep(5000);

            }
            if (buttonId == shelter)
            {
                _mapPage.ClickShelter();
                Thread.Sleep(5000);

            }
        }

        [Then(@"the places list is not empty")]
        public void ThenThePlacesListIsNotEmpty()
        {
            Thread.Sleep(5000);
            _mapPage.SideBarList.Text.Should().NotBeNullOrEmpty();
        }

        [When(@"the submit button is clicked")]
        public void WhenTheSubmitButtonIsClicked()
        {
            _mapPage.SubmitCity();
            Thread.Sleep(5000);
        }

    }
}
