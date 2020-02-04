using System;
using FluentValidation;
using NesopsService.Domain.Models;

namespace NesopsService.Domain.Validation
{
    public partial class ApplicationUpdateModelValidator
        : AbstractValidator<ApplicationUpdateModel>
    {
        public ApplicationUpdateModelValidator()
        {
            #region Generated Constructor
            #endregion
        }

    }
}
