using System.ComponentModel.DataAnnotations;

namespace LogisticsCMS.Tests.Helpers;

internal static class ValidationTestHelper
{
    public static List<ValidationResult> Validate(object model)
    {
        var validationContext = new ValidationContext(model);
        var validationResults = new List<ValidationResult>();

        Validator.TryValidateObject(
            model,
            validationContext,
            validationResults,
            validateAllProperties: true
        );

        return validationResults;
    }
}
