using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Models;

namespace BreakItMakeIt_Exercises.Chapter_02_Framework_vs_Library.Library
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Age).InclusiveBetween(18, 60).WithMessage("Age must be between 18 and 60");
        }
    }
}
