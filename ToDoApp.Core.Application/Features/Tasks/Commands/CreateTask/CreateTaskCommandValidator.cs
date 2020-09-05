using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Core.Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");

        }
    }
}
