using BreakItMakeIt_Exercises.Chapter_01_TDDFundamentals.Beginner;

namespace BreakItMakeIt_Exercises;

public class TDD_Beginner
{
    private Calculator _calculator;
    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [TestCase(1, 2, 3)]
    [TestCase(3, 4, 7)]
    public void AddSumOfTwoNumbers(int a, int b, int expectedSum)
    {
        //Arrange - setup
        //Act
        int actualSum = _calculator.Sum(a, b);
        //Assert
        Assert.That(actualSum, Is.EqualTo(expectedSum));
    }
}
