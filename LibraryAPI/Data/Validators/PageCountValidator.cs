//using System.ComponentModel.DataAnnotations;
//using LibraryAPI.Data;
//using LibraryAPI.Data.Enums;

//namespace LibraryAPI.Data.Validators
//{
//    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
//    public class PageCountValidator : ValidationAttribute
//    {
//        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//        {
//            var book = (Book)validationContext.ObjectInstance;
//            if (book.Genre == BookGenre.Poetry && book.PageCount > 100)
//            {
//                return new ValidationResult("Poetry books cannot have more than 100 pages.");
//            }
//            return base.IsValid(value, validationContext);
//        }
//    }
//}
