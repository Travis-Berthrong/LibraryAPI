using System.ComponentModel.DataAnnotations;
using LibraryAPI.Data.Enums;
using LibraryAPI.DTO.BookDTOs;

namespace LibraryAPI.Data.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PageCountValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var book = (BookIn)validationContext.ObjectInstance;
            if (book.Genre == BookGenre.Poetry && book.PageCount > 100)
            {
                return new ValidationResult("Poetry books cannot have more than 100 pages.");
            }
            return base.IsValid(value, validationContext);
        }
    }
}
