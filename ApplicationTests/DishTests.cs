using Application.Entities;
using NUnit.Framework;
using System;

namespace Application.Tests
{
    [TestFixture]
    public class DishTests
    {
        private Dish _dish;

        [SetUp]
        public void Setup()
        {
            _dish = new Dish();
        }

        [Test]
        public void ValidateAndTrimDishesStringFormat_ValidInput_ReturnsCleanedString()
        {
            // Arrange
            string input = " 1, 2, 3 ";

            // Act
            var result = _dish.ValidateAndTrimDishesStringFormat(input);

            // Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }

        [Test]
        public void ValidateAndTrimDishesStringFormat_EmptyInput_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _dish.ValidateAndTrimDishesStringFormat(""));
            Assert.That(ex.Message, Is.EqualTo("error"));
        }

        [Test]
        public void ValidateAndTrimDishesStringFormat_WhitespaceInput_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _dish.ValidateAndTrimDishesStringFormat("   "));
            Assert.That(ex.Message, Is.EqualTo("error"));
        }

        [Test]
        public void ValidateAndTrimDishesStringFormat_InvalidFormat_ThrowsArgumentException()
        {
            // Arrange
            string input = "1, 2, a"; // Invalid input

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _dish.ValidateAndTrimDishesStringFormat(input));
            Assert.That(ex.Message, Is.EqualTo("error"));
        }

        [Test]
        public void GenerateDishAndConvertToString_ValidInput_ReturnsFormattedString()
        {
            // Arrange
            string dishName = "potato";
            int dishCount = 2;

            // Act
            var result = _dish.GenerateDishAndConvertToString(dishName, dishCount);

            // Assert
            Assert.That(result, Is.EqualTo("potato(x2)"));
        }

        [Test]
        public void GenerateDishAndConvertToString_EmptyDishName_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _dish.GenerateDishAndConvertToString("", 1));
            Assert.That(ex.Message, Is.EqualTo("error"));
        }

        [Test]
        public void GenerateDishAndConvertToString_NonPositiveCount_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _dish.GenerateDishAndConvertToString("potato", 0));
            Assert.That(ex.Message, Is.EqualTo("error"));
        }

        [Test]
        public void ToString_OneOccurrence_ReturnsCorrectString()
        {
            // Arrange
            _dish = new Dish("potato", 1);

            // Act
            var result = _dish.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("potato"));
        }

        [Test]
        public void ToString_MultipleOccurrences_ReturnsCorrectString()
        {
            // Arrange
            _dish = new Dish("potato", 2);

            // Act
            var result = _dish.ToString();

            // Assert
            Assert.That(result, Is.EqualTo("potato(x2)"));
        }
    }
}
