using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using FootballTeam2.Controllers;
using FootballTeam2.Models.DTO;

namespace FootballTeam2.Validators
{
    public class TestRequestValidator : AbstractValidator<Movie>   //Change Movie
    {
        public TestRequestValidator()
        {
            //RuleFor(x => x.Id).GreaterThan(0).WithMessage("Въведи по-голямо от 0");
            //RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(2).MaximumLength(50);
            RuleFor(x => x.Number).GreaterThan(0).WithMessage("Въведи по-голямо от 0"); //Number 
            RuleFor(x => x.Player).NotNull().NotEmpty();                                //Player
        }
    }
}
