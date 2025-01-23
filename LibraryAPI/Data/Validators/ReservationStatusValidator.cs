using System.ComponentModel.DataAnnotations;
using LibraryAPI.Data.Enums;

namespace LibraryAPI.Data.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReservationStatusValidator: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string status)
            {
                bool isValid = Enum.TryParse(status, out ReservationStatus reservationStatus);
                if (!isValid)
                {
                    string validStatuses = string.Join(", ", Enum.GetNames(typeof(ReservationStatus)));
                    return new ValidationResult($"Reservation status must be one of the following values: {validStatuses}");
                }
            }
            return ValidationResult.Success;
        }

    }
}
