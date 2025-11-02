using BreakItMakeIt_Exercises.Chapter_01_TDDFundamentals.Intermediate;

namespace BreakItMakeIt_Exercises;

public class TDD_Intermediate
{
    private NumberToWords _numberToWords;

    [SetUp]
    public void Setup()
    {
        var dict = new NumberDictionary();
        _numberToWords = new NumberToWords(dict);
    }

    [TestCase(0, "zero")]
    [TestCase(19, "nineteen")]
    [TestCase(19, "nineteen")]
    [TestCase(201, "two hundred and one")]
    [TestCase(12345, "twelve thousand three hundred and forty five")]
    public void CreateWordsFromNumber(int amount, string expectedWords)
    {
        //Arrange - Setup
        //Act
        string actualWords = _numberToWords.ConvertToWord(amount);
        //Assert
        Assert.That(actualWords, Is.EqualTo(expectedWords));
    }
}
