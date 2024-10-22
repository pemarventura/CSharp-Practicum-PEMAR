using Application.Entities;

namespace ApplicationTests
{
    [TestFixture]
    public class DishManagerTests
    {
        private Server _server;
        private DishManager _dishManager;

        [SetUp]
        public void Setup()
        {
            _dishManager = new DishManager(new Dish());
            _server = new Server(_dishManager);
        }

            [Test]
        public void ValidOrderWithSingleSelectionReturnsCorrectOutput()
        {
            // Arrange
            var order = "1"; // steak
            string expected = "steak"; // Expected output

            // Act
            var actual = _server.TakeOrder(order);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ValidOrderWithMultipleSelectionsReturnsCorrectOutput()
        {
            // Arrange
            var order = "1,2,3,4"; // steak, potato, wine, cake
            string expected = "steak, potato, wine, cake"; // Expected output in order

            // Act
            var actual = _server.TakeOrder(order);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ValidOrderWithDuplicateDishReturnsCorrectOutput()
        {
            // Arrange
            var order = "2,2"; // potato, potato
            string expected = "potato(x2)"; // Expected output for multiple potatoes

            // Act
            var actual = _server.TakeOrder(order);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void InvalidSelectionReturnsError()
        {
            // Arrange
            var order = "1,2,3,5"; // Includes an invalid dish type (5)
            string expected = "error"; // Expected output for invalid selection

            // Act
            var actual = _server.TakeOrder(order);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ErrorReturnedWhenNoSelectionsAreMade()
        {
            // Arrange
            var order = ""; // No selections made
            string expected = "error"; // Expected output for no input

            // Act
            var actual = _server.TakeOrder(order);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ErrorReturnedWhenTryingToOrderMoreThanOneTypeOfDish()
        {
            // Arrange
            var order = "1,1,2,3,5"; // More than one steak and an invalid dish (5)
            string expected = "error"; // Expected output for invalid selection

            // Act
            var actual = _server.TakeOrder(order);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ErrorReturnUnformattedString()
        {
            // Arrange
            var order = ",1,,3,4";
            string expected = "error";

            //Act
            var actual = _server.TakeOrder(order);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));

        }
    }
}
