using Api.PostOfficeIssuer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace PostOfficeIssuer.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task TestDynamicCredentialProvider()
        {
            // Arrange
            var provider = new DynamicCredentialProvider();

            // Act
            var credential = await provider.CreatePayloadAsync(string.Empty);

            // Assert
            Assert.IsNotNull(credential);
        }

        [TestMethod]
        public async Task TestDynamicCredentialProviderJSON()
        {
            // Arrange
            string jsonSubject = "{\"Surname\":\"Schmidt\",\"GivenNames\":\"Kasper\",\"DateOfBirth\":\"1987-05-05\",\"Telephone\":\"07700900359\",\"EmailAddress\":\"kasper.schmidt22@example.com\",\"ProfileImageUrl\":\"https://nhsuk-dsp-prototype.herokuapp.com/images/profile-pic-kasper.png\"}";
            var provider = new DynamicCredentialProvider();

            // Act
            var credential = await provider.CreatePayloadAsync(jsonSubject);

            // Assert
            Assert.IsNotNull(credential);
        }

        [TestMethod]
        public async Task TestPrimaryIdentityCredentialProvider()
        {
            // Arrange
            var provider = new PrimaryIdentityCredentialProvider();

            // Act
            var credential = await provider.CreatePayloadAsync(string.Empty);

            // Assert
            Assert.IsNotNull(credential);
        }

        [TestMethod]
        public async Task TestPrimaryIdentityCredentialProviderJSON()
        {
            // Arrange
            string jsonSubject = "{\"Surname\":\"Schmidt\",\"GivenNames\":\"Kasper\",\"DateOfBirth\":\"1987-05-05\",\"Telephone\":\"07700900359\",\"EmailAddress\":\"kasper.schmidt22@example.com\",\"ProfileImageUrl\":\"https://nhsuk-dsp-prototype.herokuapp.com/images/profile-pic-kasper.png\"}";
            var provider = new PrimaryIdentityCredentialProvider();

            // Act
            var credential = await provider.CreatePayloadAsync(jsonSubject);

            // Assert
            Assert.IsNotNull(credential);
        }
    }
}