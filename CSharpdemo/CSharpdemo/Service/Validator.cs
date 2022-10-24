using System.ComponentModel.DataAnnotations;
namespace CSprj.Service.Validation
{
    public class Validator : IValidator
    {
        public ValidationResult Validate<T>(T obj)
        {
            var result = new ValidationResult();
            result.IsValid = true;
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                foreach (var atribute in property.GetCustomAttributes(true))
                {
                    if (atribute is ValidationAttribute validationAttribute)
                    {
                        bool valid = validationAttribute.IsValid(property.GetValue(obj));
                        if (!valid)
                        {
                            result.IsValid = false;
                            var propertyName = property.Name;
                            var message = validationAttribute.FormatErrorMessage(propertyName);
                            if (result.Errors.ContainsKey(propertyName))
                            {
                                var Errors = result.Errors[propertyName].ToList();
                                Errors.Add(message);
                                result.Errors[propertyName] = Errors.ToArray();
                            }
                            else
                            {
                                result.Errors.Add(propertyName, new string[] { message });
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}