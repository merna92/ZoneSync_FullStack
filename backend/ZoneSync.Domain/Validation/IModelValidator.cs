namespace ZoneSync.Domain.Validation;

public interface IModelValidator<TModel>
{
    ValidationResult Validate(TModel model);
}
