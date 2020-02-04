using System;
using FluentValidation;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Validation
{
    public partial class ApplicationCreateModelValidator
        : AbstractValidator<ApplicationCreateModel>
    {
        public ApplicationCreateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
