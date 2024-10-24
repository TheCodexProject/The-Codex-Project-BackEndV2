using domain.models.resource;
using domain.models.user;

namespace UnitTests.models.organization
{
    public class OrganizationModelTests
    {
        // # 1 - Create a new Organization
        [Fact]
        public void Organisation_can_be_created()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();

            // Act

            // Assert
            Assert.NotNull(organisation);
        }

        #region Organization Name Tests

        // # 2 - Update the name of the organisation
        [Fact]
        public void Organisation_can_update_name()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var name = "Tech Corp";

            // Act
            var result = organisation.UpdateTitle(name);

            // Assert
            Assert.True(result.IsSuccess);
        }

        // # 2A - Name cannot be null or empty
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Organisation_cannot_update_name_with_invalid_value(string name)
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();

            // Act
            var result = organisation.UpdateTitle(name);

            // Assert
            Assert.True(result.IsFailure);
        }

        // # 2B - Name must be at least 2 characters long
        [Theory]
        [InlineData("A")]
        public void Organisation_cannot_update_name_with_less_than_2_characters(string name)
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();

            // Act
            var result = organisation.UpdateTitle(name);

            // Assert
            Assert.True(result.IsFailure);
        }

        // # 2C - Name cannot be longer than 100 characters
        [Fact]
        public void Organisation_cannot_update_name_with_more_than_100_characters()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var name = new string('A', 101);

            // Act
            var result = organisation.UpdateTitle(name);

            // Assert
            Assert.True(result.IsFailure);
        }

        // # 2D - Name can be updated with valid values
        [Theory]
        [InlineData("Tech Solutions")]
        [InlineData("Innovative Enterprises")]
        public void Organisation_can_update_name_with_valid_values(string name)
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();

            // Act
            var result = organisation.UpdateTitle(name);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Organization Owner Tests

        // # 3 - Add an owner to the organisation
        [Fact]
        public void Organisation_can_add_owner()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var owner = User.Create();

            // Act
            var result = organisation.AddOwner(owner);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Contains(owner, organisation.Owners);
        }

        // # 3A - Cannot add a duplicate owner
        [Fact]
        public void Organisation_cannot_add_duplicate_owner()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var owner = User.Create();
            organisation.AddOwner(owner);

            // Act
            var result = organisation.AddOwner(owner);

            // Assert
            Assert.True(result.IsFailure);
        }

        // # 3B - Remove an owner from the organisation
        [Fact]
        public void Organisation_cannot_remove_owner_if_there_is_only_one()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var owner = User.Create();
            organisation.AddOwner(owner);

            // Act
            var result = organisation.RemoveOwner(owner);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Contains(owner, organisation.Owners);
        }

        // # 3C - Cannot remove an owner that does not exist
        [Fact]
        public void Organisation_cannot_remove_nonexistent_owner()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var owner = User.Create();

            // Act
            var result = organisation.RemoveOwner(owner);

            // Assert
            Assert.True(result.IsFailure);
        }

        // # 3D - Remove an owner from the organization (with multiple owners)
        [Fact]
        public void Organisation_can_remove_owner()
        {
            // Arrange
            var organization = domain.models.organization.Organization.Create();
            var owner1 = User.Create();
            var owner2 = User.Create();
            organization.AddOwner(owner1);
            organization.AddOwner(owner2);

            // Act
            var result = organization.RemoveOwner(owner1);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.DoesNotContain(owner1, organization.Owners);
        }

        #endregion

        #region Organization Resource Tests

        // # 4 - Add a resource to the organisation
        [Fact]
        public void Organisation_can_add_resource()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var resource = Resource.Create();

            // Act
            var result = organisation.AddResource(resource);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Contains(resource, organisation.Resources);
        }

        // # 4A - Cannot add a duplicate resource
        [Fact]
        public void Organisation_cannot_add_duplicate_resource()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var resource = Resource.Create();
            organisation.AddResource(resource);

            // Act
            var result = organisation.AddResource(resource);

            // Assert
            Assert.True(result.IsFailure);
        }

        // # 4B - Remove a resource from the organisation
        [Fact]
        public void Organisation_can_remove_resource()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var resource = Resource.Create();
            organisation.AddResource(resource);

            // Act
            var result = organisation.RemoveResource(resource);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.DoesNotContain(resource, organisation.Resources);
        }

        // # 4C - Cannot remove a resource that does not exist
        [Fact]
        public void Organisation_cannot_remove_nonexistent_resource()
        {
            // Arrange
            var organisation = domain.models.organization.Organization.Create();
            var resource = Resource.Create();

            // Act
            var result = organisation.RemoveResource(resource);

            // Assert
            Assert.True(result.IsFailure);
        }

        #endregion
    }
}