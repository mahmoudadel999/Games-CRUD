namespace GameZone.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute

    {
        private readonly int _maxSizeFile;
        public MaxFileSizeAttribute(int maxSizeAllow)
        {
            _maxSizeFile = maxSizeAllow;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                if (file.Length > _maxSizeFile)
                {
                    return new ValidationResult($"Maximum allowed size is ({_maxSizeFile / 1024 / 1024})MB");
                }
            }

            return ValidationResult.Success;
        }
    }
}
