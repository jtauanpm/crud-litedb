using crud_litedb.Services;
using FluentAssertions;
using Xunit;

namespace crud_litedb.unittests.Services
{
    public class UserInputServiceTests
    {
        [Fact(DisplayName = "Try to fill a valid person")]
        public void FillPerson_ValidInput_ReturnsPersonObject()
        {
            // Arrange
            var userInputService = new UserInputService();

            var fakeName = "John";
            var fakeAge = "30";

            var stringReader = new StringReader($"{fakeAge}{Environment.NewLine}{fakeName}");
            Console.SetIn(stringReader);

            // Act
            var result = userInputService.FillPerson();

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be(fakeName);
            result.Age.Should().Be(int.Parse(fakeAge));
        }

        [Fact(DisplayName = "Try to fill a invalid person")]
        public void FillPerson_InvalidAge_ReturnsNull()
        {
            // Arrange
            var userInputService = new UserInputService();

            var invalidAge = "invalid";
            var validName = "Alice";

            var stringReader = new StringReader($"{invalidAge}{Environment.NewLine}{validName}");
            Console.SetIn(stringReader);

            // Act
            var result = userInputService.FillPerson();

            // Assert
            result.Should().BeNull();
        }
        
        [Fact(DisplayName = "Try to get a person with valid id")]
        public void GetId_ValidInput_ReturnsId()
        {
            // Arrange
            var userInputService = new UserInputService();

            var fakeId = "10";

            var stringReader = new StringReader(fakeId);
            Console.SetIn(stringReader);

            // Act
            var result = userInputService.GetId();

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(int.Parse(fakeId));
        }

        [Fact(DisplayName = "Try to get a person with invalid id")]
        public void GetId_InvalidInput_ReturnsNull()
        {
            // Arrange
            var userInputService = new UserInputService();

            var invalidId = "invalid";

            var stringReader = new StringReader(invalidId);
            Console.SetIn(stringReader);

            // Act
            var result = userInputService.GetId();

            // Assert
            result.Should().BeNull();
        }
    }
}
