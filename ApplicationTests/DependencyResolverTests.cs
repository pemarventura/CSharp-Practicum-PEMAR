using NUnit.Framework;
using Application.Entities;

namespace ApplicationTests
{
    [TestFixture]
    public class DependencyResolverTests
    {

        [Test]
        public void CreateServer_ShouldReturnNonNullServer()
        {
            // Act
            var server = DependencyResolver.CreateServer();

            // Assert
            Assert.That(server, Is.Not.Null, "Expected server instance to be non-null.");
        }

        [Test]
        public void CreateServer_ShouldReturnServerWithNonNullDishManager()
        {
            // Act
            var server = DependencyResolver.CreateServer();

            // Assert
            Assert.That(server, Is.Not.Null, "Expected server instance to be non-null.");
            Assert.That(server.HasValidComposition(), Is.True, "Expected DishManager instance to be non-null.");
        }
    }
}
