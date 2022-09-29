using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSchool.Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandValidator:AbstractValidator<UpdateLanguageCommand>    
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(l => l.Id).NotEmpty();
            RuleFor(l => l.Name).NotEmpty();
        }        
    }
}
