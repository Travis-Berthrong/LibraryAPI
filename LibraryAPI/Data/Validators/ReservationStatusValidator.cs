using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Data.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReservationStatusValidator: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string status)
            {
                if (status != "Returned" && status != "Overdue" && status != "CheckedOut" && status != "OnHold")
                {
                    return new ValidationResult("Invalid reservation status.");
                }
            }
            return ValidationResult.Success;
        }

    }
}
