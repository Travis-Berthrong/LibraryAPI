using System.ComponentModel.DataAnnotations;
using LibraryAPI.Data.Enums;

namespace LibraryAPI.Data.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BookGenreValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            string genreValue = value.ToString()!;

            bool isValid = Enum.TryParse(genreValue, out BookGenre genre);

            if (!isValid)
            {
                string validGenres = string.Join(", ", Enum.GetNames(typeof(BookGenre)));
                return new ValidationResult($"Genre must be one of the following values: {validGenres}");
            }

            return ValidationResult.Success;
        }
    }
}