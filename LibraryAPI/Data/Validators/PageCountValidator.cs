using System.ComponentModel.DataAnnotations;
using LibraryAPI.Data.Enums;
using LibraryAPI.DTO.BookDTOs;

namespace LibraryAPI.Data.Validators
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PageCountValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is BookIn book) { 
                if (book.PageCount < 1)
                {
                    return new ValidationResult("Page count must be greater than 0.");
                }
                else if (book.Genre == BookGenre.Poetry.ToString() && book.PageCount > 100)
                {
                    return new ValidationResult("Poetry books cannot have more than 100 pages.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
