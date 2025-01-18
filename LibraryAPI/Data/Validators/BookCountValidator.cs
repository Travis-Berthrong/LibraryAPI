using System.ComponentModel.DataAnnotations;
using LibraryAPI.DTO.BookDTOs;

namespace LibraryAPI.Data.Validators
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BookCountValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is BookIn book)
            {
                if (book.NumAvailable > book.NumTotal)
                {
                    return new ValidationResult("Number of available books cannot be greater than the total number of books.");
                }
                else if (book.NumAvailable < 0 || book.NumTotal < 0)
                {
                    return new ValidationResult("Number of books cannot be negative.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
