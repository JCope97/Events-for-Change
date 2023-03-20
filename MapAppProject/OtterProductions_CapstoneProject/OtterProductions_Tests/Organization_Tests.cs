using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtterProductions_CapstoneProject.Models;
using OtterProductions_Tests;

namespace OtterProductions_Tests
{
    public class Organization_Tests
    {
        private Organization MakeValidOrganization()
        {
            Organization organization = new Organization
            {
                Id = 1,
                Email = "org@account.com",
                OrganizationName = "name",
                OrganizationDescription = "description",
                OrganizationLocation = "location"
              
            };
            return organization;
        }

        [Test]
        public void ValidOrganization_IsValid()
        {
            // Arrange
            Organization organization = MakeValidOrganization();

            // Act
            ModelValidator mv = new ModelValidator(organization);

            // Assert
            Assert.That(mv.Valid, Is.True);
        }

        [Test]
        public void Organization_WithMissingOrganizationName_IsNotValid()
        {
            // Arrange
            Organization organization = MakeValidOrganization();
            organization.OrganizationName = null!;

            // Act
            ModelValidator mv = new ModelValidator(organization);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("OrganizationName"), Is.True);
            });
        }

        [Test]
        public void Organization_WithEmptyStringForOrganizationName_IsNotValid()
        {
            // Arrange
            Organization organization = MakeValidOrganization();
            organization.OrganizationName = "";

            // Act
            ModelValidator mv = new ModelValidator(organization);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("OrganizationName"), Is.True);
            });
        }

        [Test]
        public void Organization_WithTooLongOrganizationName_IsNotValid()
        {
            // Arrange
            Organization organization = MakeValidOrganization();
            organization.OrganizationName = "Thisitemnameiswaytoolongtobeconsideredvalid.Thisitemnameiswaytoolongtobeconsideredvalid.Thisitemnameiswaytoolongtobeconsideredvalid.Infactitisoveronehundresscharacters";

            // Act
            ModelValidator mv = new ModelValidator(organization);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("OrganizationName"), Is.True);
            });
        }


        [Test]
        public void Organization_WithTooShortOrganizationName_IsNotValid()
        {
            // Arrange
            Organization organization = MakeValidOrganization();
            organization.OrganizationName = "J";

            // Act
            ModelValidator mv = new ModelValidator(organization);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(mv.Valid, Is.False);
                Assert.That(mv.ContainsFailureFor("OrganizationName"), Is.True);
            });
        }

        // Continue on in this fashion, both positive and negative cases
    }
}