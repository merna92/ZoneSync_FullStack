namespace ZoneSync.Domain.Validation;

internal static class ValidationRules
{
    public static bool IsRequired(string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    public static bool HasPositiveValue(decimal? value)
    {
        return value.HasValue && value.Value > 0;
    }

    public static bool HasPositiveValue(int? value)
    {
        return value.HasValue && value.Value > 0;
    }

    public static bool IsEmail(string? value)
    {
        return value is not null && IsRequired(value) && value.Contains('@') && value.Contains('.');
    }

    public static bool IsPhoneNumber(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return true;

        return value.All(character => char.IsDigit(character) || character == '+' || character == '-' || character == ' ');
    }
}
