namespace ZoneSync.Domain.Validation;

public class ValidationResult
{
    public bool IsValid { get { return Errors.Count == 0; } }
    public List<string> Errors { get; set; } = [];

    public void AddError(string error)
    {
        if (!string.IsNullOrWhiteSpace(error))
            Errors.Add(error);
    }

    public override string ToString()
    {
        return IsValid ? "Valid" : string.Join(Environment.NewLine, Errors);
    }
}
