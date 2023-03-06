using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_CapstoneProject.Areas.Identity.Data;

namespace OtterProductions_Tests
{
    public class MapAppUserTests
    {
        private MapAppUser ValidTestingItems()
        {
            MapAppUser user = new MapAppUser();
            {
                user.Id = 1;
                user.AspnetIdentityId = "1234";
                //user.FirstName = "John";
                //user.LastName = "Doe";

            };

            return user;
        }



        [Test]
        public void ValidUser_IsValid()
        {
            //Arrange
            MapAppUser user = ValidTestingItems();

            //Act
            ModelValidator modelValidator = new ModelValidator(user);

            //Assert
            Assert.That(modelValidator.Valid, Is.True);
        }     

        [Test]
        public void User_WithFirstName_Between2and50Characters_IsValid()
        {
            //Arrange
            MapAppUser user = ValidTestingItems();
            //user.LastName = "John";

            //Act
            ModelValidator modelValidator = new ModelValidator(user);


            //Assert
            Assert.That(modelValidator.Valid, Is.True);

        }

        [Test]
        public void User_WithLastName_Between2and50Characters_IsValid()
        {
            //Arrange
            MapAppUser user = ValidTestingItems();
            //user.LastName = "Doe";

            //Act
            ModelValidator modelValidator = new ModelValidator(user);


            //Assert
            Assert.That(modelValidator.Valid, Is.True);
            
        }

        [Test]
        public void User_WithTooLongFirstName_IsNotValid()
        {
            // Arrange
            MapAppUser user = ValidTestingItems();
            //user.FirstName = "Thisitemnameiswaytoolongtobeconsideredvalid.Thisitemnameiswaytoolongtobeconsideredvalid.Thisitemnameiswaytoolongtobeconsideredvalid.Infactitisover100characters";

            // Act
            ModelValidator modelValidator = new ModelValidator(user);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(modelValidator.Valid, Is.False);
                Assert.That(modelValidator.ContainsFailureFor("FirstName"), Is.True);
            });
        }

        [Test]
        public void User_WithTooLongLastName_IsNotValid()
        {
            // Arrange
            MapAppUser user = ValidTestingItems();
            //user.LastName = "Thisitemnameiswaytoolongtobeconsideredvalid.Thisitemnameiswaytoolongtobeconsideredvalid.Thisitemnameiswaytoolongtobeconsideredvalid.Infactitisover100characters";

            // Act
            ModelValidator modelValidator = new ModelValidator(user);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(modelValidator.Valid, Is.False);
                Assert.That(modelValidator.ContainsFailureFor("LastName"), Is.True);
            });
        }
    }
}
