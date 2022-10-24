namespace CSprj.Service.Validation
{
    public interface IValidator
    {
        ValidationResult Validate<T>(T obj);
    }
}