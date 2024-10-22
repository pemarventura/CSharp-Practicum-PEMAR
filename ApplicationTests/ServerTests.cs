using Application.Entities;

[TestFixture]
public class ServerTests
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
    public void HasValidComposition_WhenDishManagerIsProvided_ReturnsTrue()
    {
        // Act
        var result = _server.HasValidComposition();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void HasValidComposition_WhenDishManagerIsNull_ReturnsFalse()
    {
        // Arrange
        var serverWithNullManager = new Server(null);

        // Act
        var result = serverWithNullManager.HasValidComposition();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void TakeOrder_ValidOrder_ReturnsDishes()
    {
        // Arrange
        string unparsedOrder = "1, 2, 3";
        string expectedDishes = "steak, potato, wine"; // Expected output from GetDishes

        // Act
        var result = _server.TakeOrder(unparsedOrder);

        // Assert
        Assert.That(result, Is.EqualTo(expectedDishes));
    }

    [Test]
    public void TakeOrder_InvalidOrder_ReturnsErrorMessage()
    {
        // Arrange
        string unparsedOrder = "invalid order"; // Invalid input

        // Act
        var result = _server.TakeOrder(unparsedOrder);

        // Assert
        Assert.That(result, Is.EqualTo("error")); // Check if the returned message matches the expected error
    }
}
