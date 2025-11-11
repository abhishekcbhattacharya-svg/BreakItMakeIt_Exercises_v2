using BreakItMakeIt_Exercises.Chapter_02_Framework_vs_Library.Library;
using FluentValidation.Results;
using WebProject.Models;

namespace BreakItMakeIt_Exercises;

public class LibraryValidationTests
{
    [Test]
    public void Should_Fail_WhenNameIsEmpty()
    {
        //Arrange
        var model = new UserModel { Name = "", Age = 25 };
        //Act
        ValidationResult result = _Validate(model);
        //Assert
        Assert.IsFalse(result.IsValid);
        Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Name is required"));
    }

    [Test]
    public void Should_Fail_WhenAgeOutOfRange()
    {
        //Arrange
        var model = new UserModel { Name = "Alice", Age = 70 };
        //Act
        ValidationResult result = _Validate(model);
        //Assert
        Assert.IsFalse(result.IsValid);
        Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Age must be between 18 and 60"));
    }

    [Test]
    public void Should_Pass_WhenModelValid()
    {
        //Arrange
        var model = new UserModel { Name = "Bob", Age = 30 };
        //Act
        ValidationResult result = _Validate(model);
        //Assert
        Assert.IsTrue(result.IsValid);
    }

    private static ValidationResult _Validate(UserModel model)
    {
        //Implement fluent style validation
        throw new NotImplementedException();
    }
}
