using System.ComponentModel.DataAnnotations;

namespace FinalProject.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtensionsAttribute(params string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Value can't be null");
            }

            if (value is IFormFile formFile)
            {
                var extension = Path.GetExtension(formFile.FileName);
                if (!_extensions.Contains(extension.ToUpper()))
                {
                    return new ValidationResult($"This image extension is not allowed. Allowed extensions: {string.Join(',', _extensions)}");
                }
            }

            return ValidationResult.Success;
        }
    }
}
