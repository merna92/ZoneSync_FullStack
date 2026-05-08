using ZoneSync.Domain.Models;

namespace ZoneSync.Domain.Validation;

public class UserValidator : IModelValidator<User>
{
    public ValidationResult Validate(User user)
    {
        ValidationResult result = new ValidationResult();

        if (!ValidationRules.IsRequired(user.UserFirstName))
            result.AddError("User first name is required.");

        if (!ValidationRules.IsRequired(user.UserLastName))
            result.AddError("User last name is required.");

        if (!ValidationRules.IsEmail(user.Email))
            result.AddError("User email is not valid.");

        if (!ValidationRules.IsPhoneNumber(user.PhoneNumber))
            result.AddError("User phone number is not valid.");

        if (user.RoleType is null)
            result.AddError("User role is required.");

        return result;
    }
}
