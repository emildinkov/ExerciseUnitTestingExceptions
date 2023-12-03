using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "hello";

        string expected = "olleh";

        // Act
        string result = this._exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string? input = null;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discountPrice = 50.0m;

        // Act
        decimal result = this._exceptions.ArgumentCalculateDiscount(totalPrice, discountPrice);


        // Assert
        Assert.That(result, Is.EqualTo(50));
    }

    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = -50.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] numbers = { 1, 2, 3 };
        int index = 2;

        // Act
        int result = this._exceptions.IndexOutOfRangeGetElement(numbers, index);

        // Assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 1, 2, 3 };
        int index = -1;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] numbers = { 5, 6, 7, 8, };
        int index = 5;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(numbers, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool input = true;
        string expected = "User logged in.";

        // Act
        string result = this._exceptions.InvalidOperationPerformSecureOperation(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool input = false;

        // Act & Assert
        Assert.That(() => this._exceptions.InvalidOperationPerformSecureOperation(input), Throws.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "5";
        int expected = 5;

        // Act
        int result = this._exceptions.FormatExceptionParseInt(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "abcv";

        // Act & Assert
        Assert.That(() => this._exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> input = new()
        {
            ["fist"] = 5,
            ["second"] = 10,
            ["third"] = 20
        };

        string key = "third";

        // Act
        int result = this._exceptions.KeyNotFoundFindValueByKey(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(20));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new()
        {
            ["first"] = 5,
            ["second"] = 10,
            ["third"] = 15,
            ["fourth"] = 20
        };

        string key = "fifth";

        // Act & Assert
        Assert.That(() => this._exceptions.KeyNotFoundFindValueByKey(input, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int a = 5;
        int b = 5;

        // Act
        int result = this._exceptions.OverflowAddNumbers(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MaxValue;
        int b = 1;

        // Act & Assert
        Assert.That(() => this._exceptions.OverflowAddNumbers(a,b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MinValue;
        int b = -1;

        // Act & Assert
        Assert.That(() => this._exceptions.OverflowAddNumbers(a, b), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int num1 = 10;
        int num2 = 5;

        // Act
        int result = this._exceptions.DivideByZeroDivideNumbers(num1, num2);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int num1 = 5;
        int num2 = 0;

        // Act & Assert
        Assert.That(() => this._exceptions.DivideByZeroDivideNumbers(num1, num2), Throws.InstanceOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] numbers = { 1, 2, 3, 4, 5, };
        int index = 3;

        // Act
        int result = this._exceptions.SumCollectionElements(numbers, index);

        // Assert
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[]? numbers = null;
        int index = 2;

        // Act & Assert
        Assert.That(() => this._exceptions.SumCollectionElements(numbers, index), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] numbers = { 1, 2, 3 };
        int index = 5;

        // Act & Assert
        Assert.That(() => this._exceptions.SumCollectionElements(numbers, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> numbers = new()
        {
            ["first"] = "1",
            ["second"] = "2",
            ["third"] = "3"
        };

        string key = "third";

        // Act
        int result = this._exceptions.GetElementAsNumber(numbers, key);

        // Assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> numbers = new()
        {
            ["first"] = "1",
            ["second"] = "2",
            ["third"] = "3"
        };

        string key = "fifth";

        // Act & Assert
        Assert.That(() => this._exceptions.GetElementAsNumber(numbers, key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> numbers = new()
        {
            ["first"] = "abc._2",
            ["second"] = "a_*bc",
            ["third"] = "a__b)c"
        };

        string key = "first";

        // Act & Assert
        Assert.That(() => this._exceptions.GetElementAsNumber(numbers, key), Throws.InstanceOf<FormatException>());
    }
}
