using System;
using System.ComponentModel.DataAnnotations;

namespace Netopes.Core.Helpers.Extensions
{
    public class RequiredGuidAttribute : ValidationAttribute
    {
        public RequiredGuidAttribute() => ErrorMessage = "{0} is required.";

        public override bool IsValid(object? value)
            => value is Guid && !Guid.Empty.Equals(value);
    }
}