using System.ComponentModel.DataAnnotations;

namespace FinalProject.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        private readonly int _minFileSize;

        public FileSizeAttribute(int minfileSize, int maxfileSize)
        {
            _maxFileSize = maxfileSize;
            _minFileSize = minfileSize;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Value can't be null");
            }

            if( value is IFormFile file)
            {
                if (file.Length >= _maxFileSize)
                {
                    return new ValidationResult(GetErrorMaxSizeMessage());
                }
                else if (file.Length <= _minFileSize)
                {
                    return new ValidationResult(GetErrorMinSizeMessage());
                }
            }

            return ValidationResult.Success;
        }

        private string GetErrorMaxSizeMessage()
        {
            return $"Maximum allowed file size is {_maxFileSize} bytes";
        }

        private string GetErrorMinSizeMessage()
        {
            return $"Minimus allowed file size is {_minFileSize} bytes";
        }

    }
}
